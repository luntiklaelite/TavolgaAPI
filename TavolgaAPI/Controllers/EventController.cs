using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavolgaAPI.Models;
using TavolgaAPI.Models.DTOs;
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


        /// <summary>
        /// Возвращает мероприятия (ПОЛНОЕ ДЕРЕВО)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAllFull")]
        public List<Event> GetAllFullEvents()
        {
            return DbModel.Events
                .Include(i => i.Nominations)
                    .ThenInclude(i => i.Criteries).ToList();
        }

        /// <summary>
        /// Возвращает мероприятия (ПОЛНОЕ ДЕРЕВО)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAll")]
        public IEnumerable<EventDto> GetAllEvents()
        {
            return DbModel.Events.Select(s => new EventDto
            {
                Id = s.Id,
                Name = s.Name
            });
        }
    }
}
