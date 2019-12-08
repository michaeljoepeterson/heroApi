using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using heroApi.Models;

namespace heroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private List<Hero> Heroes = CreateHeroes(20);

        // GET: api/Hero
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            foreach(Hero hero in Heroes)
            {
                Console.WriteLine($"{hero.id} : {hero.name}");
            }
            
            return Heroes;
        }

        // GET: api/Hero/5
        [Route("{id}")]
        public Hero Get(int id)
        {
            
            return Hero.FindHero(id);
        }

        // POST: api/Hero
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Hero/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static List<Hero> CreateHeroes(int numHeroes)
        {

            List<Hero> heroes = new List<Hero>();
            for(int i = 0;i < numHeroes; i++)
            {
                heroes.Add(new Hero(i, "Hero " + i));
            }
            return heroes;
        }
    }
}
