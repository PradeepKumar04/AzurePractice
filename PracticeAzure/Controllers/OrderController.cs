using AzurePractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PracticeAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        List<Cart> carts = new List<Cart>();

        [HttpPost("{id}")]
        public async Task<IActionResult> PostCartItem(int id)
        {
            Cart cart = new Cart();
            cart.Id = 1;
            cart.UserId = 1;
            cart.MenuItemId = id;
            cart.MenuItemName =  GetMenuItemById(id);
            carts.Add(cart);
            return Ok(cart);
        }

        [HttpGet("GetMenuItemById/{id}")]
        public string GetMenuItemById(int id)
        {
            MenuItem item = null;
            string url = "https://localhost:44332/api/MenuItem/GetById/";
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync($"{id}");
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var result1 = result.Content.ReadAsStringAsync().Result;
                    //weather = JsonConvert.DeserializeObject<WeatherData>(result, new JsonSerializerSettings() { Culture = CultureInfo.InvariantCulture });
                    item = JsonConvert.DeserializeObject<MenuItem>(result1);
                }
            }
            return item.Name;
        }
    }
}
