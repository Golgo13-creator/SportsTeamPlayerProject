using Microsoft.AspNet.Identity;
using SportsTeamPlayerProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsTeamPlayerProject.WebAPI.Controllers
{
    public class PlayerController : ApiController
    {
        private PlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playerService = new PlayerService(userId);
            return playerService;
            //get players

            //post

            //put

            //get by team

            //get by sport

            //delete team
        }
    }
}
