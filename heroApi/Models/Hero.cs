using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace heroApi.Models
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public static List<Hero> HeroList = new List<Hero>();
        private static int maxId = 0;
        
        
        public Hero(int _id,string _name)
        {
            id = _id;
            name = _name;
            if(_id > maxId)
            {
                maxId = _id;
            }
            HeroList.Add(this);
        }
        [JsonConstructor]
        public Hero(string _name)
        {
            name = _name;
            id = -1;
            HeroList.Add(this);
        }
        //check if max id taken if id not passed
        private int checkMaxID()
        {
            for(int i = 0;i < HeroList.Count; i++)
            {
                if (HeroList[i].id == maxId)
                {
                    maxId++;
                    return maxId;
                }
            }

            return maxId;
        }

        public static Hero FindHero(int _id)
        {
            for (int i = 0; i < HeroList.Count; i++)
            {
                if (HeroList[i].id == _id)
                {
                    return HeroList[i];
                }
            }

            return null;
        }

        public static void LogHeroes()
        {
            foreach (Hero hero in HeroList)
            {
                Console.WriteLine($"{hero.id} : {hero.name}");
            }
        }
    }
}
