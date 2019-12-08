using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using heroApi.Models;
using System.Runtime.Remoting;
using Newtonsoft.Json;

namespace heroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        //private ModelDB heroDb = new ModelDB();
       
        // GET: api/Hero
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            foreach(Hero hero in ModelDB.Heroes)
            {
                Console.WriteLine($"{hero.id} : {hero.name}");
            }
            
            return ModelDB.Heroes;
        }
        [Route("bulk-add/{num}")]
        public IEnumerable<Hero> CreateHeroes(int numHeroes)
        {
            ModelDB.CreateHeroes(20);

            return ModelDB.Heroes;
        }

        // GET: api/Hero/5
        [Route("{id}")]
        public Hero Get(int id)
        {
            
            return Hero.FindHero(id);
        }

        // POST: api/Hero
        [HttpPost]
        public void Post([FromBody] dynamic value)
        {
            string json = value.ToString();
            Hero newHero = JsonConvert.DeserializeObject<Hero>(json);
            ModelDB.AddHero(new Hero(newHero.name));
            Console.WriteLine(newHero.name + " " + newHero.id);
            Console.WriteLine($"heroes size {ModelDB.Heroes.Count} {Hero.HeroList.Count}");
            ModelDB.LogHeroes();
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

    }
}
