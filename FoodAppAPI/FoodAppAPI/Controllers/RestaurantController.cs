using FoodAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FoodAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly FoodAppDbContext _context;
        public RestaurantController(FoodAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var res = await _context.Restaurants.ToListAsync();

            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMenu([FromRoute] int id)
        {
            //select d.d_name, c.cat_name, r.r_name, price from
            //menus m join restaurants r on m.r_id = r.r_id
            //join dishes d on m.d_id = d.d_id
            //join categories c on c.cat_id = d.d_categ
            //where r.r_id = 1;
            var query = from m in _context.Menus join
                        r in _context.Restaurants on m.RId equals r.RId
                        join d in _context.Dishes on m.DId equals d.DId
                        join c in _context.Categories on d.DCateg equals c.CatId
                        where r.RId == id
                        select new
                        {
                            DName = d.DName,
                            CatName = c.CatName,
                            Price = m.Price,
                            RName = r.RName
                        };

            var query2 = _context.Menus
                          .Where(m => m.RId == id)
                          .Select(m => new
                          {
                              DName = m.DIdNavigation.DName,
                              CatName = m.DIdNavigation.DCategNavigation.CatName,
                              Price = m.Price,
                              RName = m.RIdNavigation.RName
                          });

            var res = await query2.ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetRestaurantByName([FromRoute] string name)
        {
            //var res = await _context.Restaurants
            //                        .Where(x => EF.Functions.Like(x.RName, "%"+name+"%"))
            //                        .ToListAsync();

            var res = await _context.Restaurants
                                    .Where(x => x.RName.ToLower().Contains(name.ToLower()))
                                    .ToListAsync();

            //Console.WriteLine(res);
            return Ok(res);
        }

        [HttpGet]
        [Route("{rId:int}/{dishName}")]
        public async Task<IActionResult> GetFoodByNameByRestaurant([FromRoute] int rId, [FromRoute] string dishName)
        {
            var res = await _context.Menus
                             .Where(m => m.RId == rId && m.DIdNavigation.DName.ToLower().Contains(dishName.ToLower()))
                             .Select(m => new
                             {
                                 dId = m.DId,
                                 dName = m.DIdNavigation.DName,
                                 RName = m.RIdNavigation.RName,
                                 price = m.Price,
                                 isNonVeg = m.DIdNavigation.IsNonVeg,
                                 Categ = m.DIdNavigation.DCategNavigation.CatName,
                             }).ToListAsync();

            return Ok(res);
        }
    }
}
