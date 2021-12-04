using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EventController : ControllerBase
    {
        EfModel DbModel;
        public EventController(EfModel model)
        {
            this.DbModel = model;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public List<Event> GetAllEvents()
        {
            return DbModel.Events
                .Include(i => i.Nominations)
                    .ThenInclude(i => i.Criteries).ToList();
        }
    }
}
