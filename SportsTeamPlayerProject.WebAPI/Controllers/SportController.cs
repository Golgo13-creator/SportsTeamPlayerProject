using Microsoft.AspNet.Identity;
using SportsTeamPlayerProject.Models;
using SportsTeamPlayerProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsTeamPlayerProject.WebAPI.Controllers
{
    public class SportController : ApiController
    {
        private SportService CreateSportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var sportService = new SportService(userId);
            return sportService;
        }
        //Post Sport
        public IHttpActionResult Post(PostSport sport)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSportService();
            if (!service.CreateSport(sport))
                return InternalServerError();
            return Ok("Sport was added.");
        }
        //Get Sport
        public IHttpActionResult Get()
        {
            SportService sportService = CreateSportService();
            var sports = sportService.GetSport();
            return Ok(sports);
        }
        //Update Sport
        public IHttpActionResult Put(PutSport sport)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSportService();
            if (!service.UpdateSport(sport))
                return InternalServerError();
            return Ok("Sport was added.");
        }
        //Delete Sport
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSportService();
            if (!service.DeleteSport(id))
                return InternalServerError();
            return Ok("Sport Was Delted.");
        }
    }
}
