using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavolgaAPI.Models;
using TavolgaAPI.Models.Entityes;

namespace TavolgaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        EfModel model;
        public NominationController(EfModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// Возвращает доступные для жюри/ассессора номинации
        /// </summary>
        [HttpGet("GetAvailableNominations")]
        public IEnumerable<Nomination> GetAvailableNominations()
        {
            return model.Nominations;
        }

        /// <summary>
        /// Изменить номинацию
        /// </summary>
        [HttpPut]
        public void ChangeNomination()
        {

        }
    }
}
