using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftCardService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftCardService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private List<Store> Stores;

        public StoreController()
        {
            CreateTestData();
        }

        [HttpGet]    
        public IActionResult Find(string search)
        {
            
            List<Store> results = new List<Store>();
            if (!string.IsNullOrEmpty(search))
            {
                var isNumeric = int.TryParse(search, out int zip);
                if (isNumeric)
                {
                    results = (from s in Stores
                               where s.ZipCode == zip
                               select s).ToList();
                }
                else
                {
                    results = (from s in Stores
                               where s.Name == search
                               select s).ToList();
                }
            }
            else
            {
                results = Stores;
            }

            if (results.Count == 0)
                return NotFound();

            return Ok(results);
            
        }       

        private void CreateTestData()
        {
            Stores = new List<Store>();
            Store s = new Store
            {
                Name = "Great Road on Main",
                PhoneNumber = "(540) 394-7200",
                ZipCode = 24073
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "The Beauty Lab",
                PhoneNumber = "(540) 200-5851",
                ZipCode = 24073
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Ultimate Touch Salon Co",
                PhoneNumber = "(540) 381-4113",
                ZipCode = 24073
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Wine Gourmet",
                PhoneNumber = "(540) 400-8466",
                ZipCode = 24018
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Hethwood Market",
                PhoneNumber = "(540) 951-0990",
                ZipCode = 24060
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "The Blue Ridge Fudge Lady",
                PhoneNumber = "(540) 509-5926",
                ZipCode = 24301
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Brugh Coffee",
                PhoneNumber = "(540) 818-7071",
                ZipCode = 24073
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Your Pie",
                PhoneNumber = "(814) 251-2702",
                ZipCode = 24060
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Campus Automotive Inc",
                PhoneNumber = "(540) 605-9657",
                ZipCode = 24060
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Quest Floor Care",
                PhoneNumber = "(540) 818-4073",
                ZipCode = 24073
            };
            Stores.Add(s);

            s = new Store
            {
                Name = "Xtreme Springz Trampoline Park",
                PhoneNumber = "(540) 251-5362",
                ZipCode = 24073
            };
            Stores.Add(s);


        }
    }
}
