using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroApi.Models
{
    public class ModelDB
    {
        public static List<Hero> Heroes = new List<Hero>();
        private static int maxId = 0;

        public ModelDB()
        {
            CreateHeroes(20);
        }

        public static void AddHero(Hero hero)
        {
            int checkedId = CheckId(hero.id);
            hero.id = checkedId;
            Console.WriteLine("Adding hero, count: {0}", Heroes.Count);
            Heroes.Add(hero);
        }

        public static void CreateHeroes(int numHeroes)
        {
            for (int i = 0; i < numHeroes; i++)
            {
                Heroes.Add(new Hero(i, "Hero " + i));
            }
        }

        public string DeleteHero(int _id)
        {
            int index = -1;

            for(int i = 0;i < Heroes.Count; i++)
            {
                if(Heroes[i].id == _id)
                {
                    index = i;
                    break;
                }
           
            }
            if(index != -1)
            {
                Heroes.RemoveAt(index);
                return "Deleted hero";
            }
            else
            {
                return "No hero found";
            }
            
        }

        private static int CheckId(int _id)
        {
            for(int i = 0;i < Heroes.Count; i++)
            {
                if(_id == Heroes[i].id)
                {
                    maxId++;
                    return maxId;
                }
            }

            return maxId;
        }

        public static void LogHeroes()
        {
            foreach (Hero hero in Heroes)
            {
                Console.WriteLine($"{hero.id} : {hero.name}");
            }
        }
    }
}
