using Microsoft.AspNetCore.Authorization;
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
using TavolgaAPI.Extensions;
using TavolgaAPI.Models.Entityes.Users;
using TavolgaAPI.Models.DTOs;

namespace TavolgaAPI.Controllers
{
    [Authorize]
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
        public BaseUser GetSelfInformation()
        {
            int userId = this.GetCurrentUserId();
            return DbModel.BaseUsers.FirstOrDefault(c => c.Id == userId);
        }
        /// <summary>
        /// Может изменять свою фотографию;
        /// </summary>
        [HttpPost("ChangeSelfPhoto")]
        public void ChangeSelfPhoto()
        {
            
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] AuthorizationModel auth)
        {
            var identity = GetIdentity(auth.Email, auth.Password);
            if (identity == null)
            {
                return BadRequest("Invalid username or password");
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
                username = identity.Name,
                role = identity.FindFirst(ClaimsIdentity.DefaultRoleClaimType).Value
            };

            return Ok(response);
        }

        [NonAction]
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            BaseUser user = DbModel.BaseUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.FIO),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
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
