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
    [Authorize]
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }
        //get all teams
        public IHttpActionResult Get()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }
        //post a team
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.CreateTeam(team))
                return InternalServerError();
            return Ok("Team was added");
        }
        //get team by sport
        public IHttpActionResult Get(string sport)
        {
            TeamService teamService = CreateTeamService();
            var team = teamService.GetTeamBySport(sport);
            return Ok(team);
        }
        //update team
        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            if (!service.UpdateTeam(team))
                return InternalServerError();
            return Ok("Team was updated!");
        }
        //delete team
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();
            if (!service.DeleteTeam(id))
                return InternalServerError();
            return Ok("Team was deleted.");
        }
    }
}

