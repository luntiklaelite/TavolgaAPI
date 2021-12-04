using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TavolgaAPI.Core;
using TavolgaAPI.Models;
using TavolgaAPI.Models.Entityes.Users;

namespace TavolgaAPI.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EfModel DbModel;
        public UserController(EfModel model)
        {
            this.DbModel = model;
        }
        
        /// <summary>
        /// Может просматривать информацию о себе (ФИО участника, фото, оцениваемые параметры, результаты участника на предыдущих этапах);
        /// </summary>
        [HttpGet("GetSelfInformation")]
        public BaseUser GetSelfInformation(int id)
        {
            return DbModel.Contestants.FirstOrDefault(c => c.Id == id);
        }
        /// <summary>
        /// Может изменять свою фотографию;
        /// </summary>
        [HttpPost("ChangeSelfPhoto")]
        public void ChangeSelfPhoto()
        {
           /* var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return BadRequest("User not Found!");

            Convert.ToInt32(identity.FindFirst("UserId").Value);*/
        }

        [HttpPost]
        public object Auth(string email, string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var expies = now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME));
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: expies,
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires = expies,
                username = identity.Name
            };

            return response;
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            BaseUser user = DbModel.BaseUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.FIO),
                    new Claim("UserId", user.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
