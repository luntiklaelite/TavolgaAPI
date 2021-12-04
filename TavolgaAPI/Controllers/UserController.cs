using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavolgaAPI.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Может просматривать информацию о себе (ФИО участника, фото, оцениваемые параметры, результаты участника на предыдущих этапах);
        /// </summary>
        [HttpGet("GetSelfInformation")]
        public void GetSelfInformation()
        {

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
