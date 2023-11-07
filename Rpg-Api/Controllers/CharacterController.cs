using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rpg_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        // GET: /<controller>/
        private static Character knight = new Character();

        [HttpGet] 
        public ActionResult<Character> Get()
        {
            return Ok(knight);
        } 
    }
}


