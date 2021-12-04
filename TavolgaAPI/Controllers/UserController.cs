using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        }

        [HttpPost]
        public void Auth(string email, string password)
        { 
            
        }
    }
}
