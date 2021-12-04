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
using TavolgaAPI.Repositories;
using System.Security.Cryptography;
using System.Text;
using TavolgaAPI.Services;

namespace TavolgaAPI.Controllers
{
    [Authorize]
    [Route("api/Account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EfModel DbModel;
        private readonly ImageRepository _imageRepository;
        private readonly EmailService _emailService;
        public UserController(EfModel model, ImageRepository imageRepository, EmailService emailService)
        {
            this.DbModel = model;
            this._imageRepository = imageRepository;
            this._emailService = emailService;
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
        /// Возвращает фотографию пользователя
        /// </summary>
        [HttpGet("GetSelfPhoto")]
        public byte[] GetSelfPhoto()
        {
            int userId = this.GetCurrentUserId();
            return _imageRepository.GetUserImage(userId);
        }

        [HttpPost("ChangeSelfPhoto")]
        public void ChangeSelfPhoto(byte[] imgBytes)
        {
            int userId = this.GetCurrentUserId();
            _imageRepository.ChangeUserImage(userId, imgBytes);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] BaseUser user)
        {
            if (DbModel.BaseUsers.Any(u => u.Email == user.Email))
                return BadRequest("Пользователь с таким email уже сущестует");
            DbModel.Contestants.Add(new Contestant
            {
                FIO = user.FIO,
                Email = user.Email,
                Password = GetMD5String(user.Password)
            });
            DbModel.SaveChanges();
            _emailService.SendMessage(user.Email, "Регистрация в платформе Таволга", "Здравствуйте! Вы были зарегестрировваны на конкурсной платформе \"Таволга\"."
                + "\nВаши данные для входа:"
                + "\nЛогин (Email): " + user.Email
                + "\nПароль: " + user.Password);
            return Ok();
        }

        [NonAction]
        private string GetMD5String(string value)
        {
            var hashes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value)).Select(b => b.ToString("x2"));
            return string.Concat(hashes);
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
