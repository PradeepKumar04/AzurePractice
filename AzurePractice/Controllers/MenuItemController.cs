using AzurePractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzurePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        List<MenuItem> items = new List<MenuItem>()
        {
            new MenuItem(){Id=1,Name="Biriyani",Active=true,DateOfLaunch=DateTime.Now,Price=250.12,FreeDelivery=true},
            new MenuItem(){Id=2,Name="Burger",Active=true,DateOfLaunch=DateTime.Now,Price=150.12,FreeDelivery=true},
            new MenuItem(){Id=3,Name="Tiger Rice(Karthik)",Active=true,DateOfLaunch=DateTime.Now,Price=100.12,FreeDelivery=true},
            new MenuItem(){Id=4,Name="Pizza",Active=true,DateOfLaunch=DateTime.Now,Price=100.12,FreeDelivery=true},

        };

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(items);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            MenuItem item = items.Find(s=>s.Id==id);
            if(item!=null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound("Not Found");
            }
        }



    }
}
