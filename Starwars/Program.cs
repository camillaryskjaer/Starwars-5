using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> planets = LoadData();
            Console.ReadKey();

            //task 1 get all planets that starts with M
            Console.WriteLine("opgave 1");
            
            //Hvad var der sket, hvis man var kommet til at taste forkert og bruge et lille M når man skulle oprette planeten?
            
            List<Planet> planetsR = planets.Where(p => p.Name.StartsWith("M")).ToList();
            foreach(Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 2 get all planets that contains y
            Console.WriteLine();
            Console.WriteLine("opgave 2");
            planetsR = planets.Where(p => p.Name.ToLower().Contains("y")).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 3 get all planets where the name is over 6 and under 15 in lenght
            Console.WriteLine();
            Console.WriteLine("opgave 3");
            planetsR = planets.Where(p => p.Name.Length > 9 && p.Name.Length < 15).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 4 get all planets that has a "a" in 2nd and ends with "e"
            Console.WriteLine();
            Console.WriteLine("opgave 4");
            planetsR = planets.Where(p => p.Name.Substring(1, 1) == "a" && p.Name.EndsWith("e")).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 5 get all planets that has a RotationPeriod over 40 and order them by that
            Console.WriteLine();
            Console.WriteLine("opgave 5");
            planetsR = planets.Where(p => p.RotationPeriod > 40).OrderBy(p => p.RotationPeriod).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 6 get all planets that has a RotationPeriod over 10 but under 20 and order them by name
            Console.WriteLine();
            Console.WriteLine("opgave 6");
            planetsR = planets.Where(p => p.RotationPeriod > 10 && p.RotationPeriod < 20).OrderBy(p => p.Name).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 7 get all planets that has a RotationPeriod over 30 and order them by name and then by RotationPeriod
            Console.WriteLine();
            Console.WriteLine("opgave 7");
            planetsR = planets.Where(p => p.RotationPeriod > 30).OrderBy(p => p.Name).ThenBy(p => p.RotationPeriod).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 8 get all planets that has a RotationPeriod less then 30 or SurfaceWater is over 50 and the name contains ba,
            //order by name, SurfaceWater, RotationPeriod
            Console.WriteLine();
            Console.WriteLine("opgave 8");
            //overvej om det ikke er bedst at bryde dine lange linier, det gør din kode mere læsevenlig
            planetsR = planets.Where(p => (p.RotationPeriod < 30 || p.SurfaceWater > 50) && p.Name.Contains("ba"))
                              .OrderBy(p => p.Name).ThenBy(p => p.SurfaceWater)
                              .ThenBy(p => p.RotationPeriod)
                              .ToList();
      
            
            planetsR = planets.Where(p => (p.RotationPeriod < 30 || p.SurfaceWater > 50) && p.Name.Contains("ba")).OrderBy(p => p.Name).ThenBy(p => p.SurfaceWater).ThenBy(p => p.RotationPeriod).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 9 get all planets that SurfaceWater over 0 and order in falling order
            
            //Falling betyder at falde - altså at man falder ned fra en skrænt :) Når man vil sige faldende orden på engelsk angiver med det som decending (nedstigning) :) 
            Console.WriteLine();
            Console.WriteLine("opgave 9");
            planetsR = planets.Where(p => p.SurfaceWater > 0).OrderByDescending(p => p.SurfaceWater).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 10 get all planets where diameter and population is known and order by how many km2 each person has in rising order
            Console.WriteLine();
            Console.WriteLine("opgave 10");
            planetsR = planets.Where(p => p.Diameter != 0 && p.Population != 0).OrderBy(p =>
            {
                double area = 4 * Math.PI * Math.Pow(p.Diameter / 2, 2);
                return area / p.Population;
            }).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 11 remove all planets with RotationPeriod over 0 using Except
            Console.WriteLine();
            Console.WriteLine("opgave 11");
            planetsR = planets.Except(planets.Where(p => p.RotationPeriod > 0)).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 12 make a list using link where the plannets starts with "e" or ends with "s"
            //then use linq to get all planets with terrain "rainforrest"
            Console.WriteLine();
            Console.WriteLine("opgave 12");
            List<Planet> planetsUsingLink = planets.Where(p => p.Name.ToLower().StartsWith("a") || p.Name.ToLower().EndsWith("s")).ToList();
            List<Planet> planetsusinglinq = (from planet in planets
                        where planet.Terrain != null && planet.Terrain.Contains("rainforests")
                        select planet).ToList();
            planetsR = planetsUsingLink.Union(planetsusinglinq).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 13 get all planets with Climate is deserts
            Console.WriteLine();
            Console.WriteLine("opgave 13");
            planetsR = planets.Where(p => p.Terrain != null && p.Terrain.Any(t => t.ToLower().Contains("desert"))).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 14 get all planets with Climate is swamp
            Console.WriteLine();
            Console.WriteLine("opgave 14");
            planetsR = planets.Where(p => p.Terrain != null && p.Terrain.Any(t => t.ToLower().Contains("swamp"))).OrderBy(p => p.RotationPeriod).ThenBy(p => p.Name).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 15 get all planets where there are double vowels
            Regex regex = new Regex(@"([aeyiuo])\1");
            Console.WriteLine();
            Console.WriteLine("opgave 15");
            planetsR = planets.Where(p => regex.Matches(p.Name).Count > 0).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }

            //task 16 get all planets where ”kk”, ”ll”, ”rr” or ”nn” is in the name
            regex = new Regex(@"([klrn])\1");
            Console.WriteLine();
            Console.WriteLine("opgave 16");
            planetsR = planets.Where(p => regex.Matches(p.Name).Count > 0).OrderByDescending(p => p.Name).ToList();
            foreach (Planet planet in planetsR)
            {
                Console.WriteLine(planet.Name);
            }
            Console.ReadLine();
        }



        static List<Planet> LoadData()
        {
            List<Planet> planets = new List<Planet>()
            {
                new Planet { Name="Corellia", Terrain= new List<string>{ "plains", "urban", "hills", "forests" },RotationPeriod=25,SurfaceWater=70, Diameter=11000, Population=3000000000},
                new Planet { Name="Rodia", Terrain= new List<string>{ "jungles", "oceans", "urban", "swamps" },RotationPeriod=29,SurfaceWater=60, Diameter=7549, Population=1300000000},
                new Planet { Name="Nal Hutta", Terrain= new List<string>{ "urban", "oceans", "bogs", "swamps" },RotationPeriod=87, Diameter=12150, Population=7000000000},
                new Planet { Name="Dantooine",Terrain= new List<string>{ "savannas", "oceans", "mountains", "grasslands" },RotationPeriod=25, Diameter=9830,Population=1000},
                new Planet { Name="Bestine IV",Terrain= new List<string>{ "rocky islands", "oceans" },RotationPeriod=26,SurfaceWater=98, Diameter=6400,Population=62000000},
                new Planet { Name="Ord Mantell",Terrain= new List<string>{ "plains", "seas","mesas" },RotationPeriod=26,SurfaceWater=10, Diameter=14050, Population=4000000000},
                new Planet { Name="Trandosha",Terrain= new List<string>{ "mountains", "seas","grasslands" ,"deserts"},RotationPeriod=25, Diameter=0, Population=42000000},
                new Planet { Name="Socorro", Terrain= new List<string>{ "mountains", "deserts"},RotationPeriod=20, Population=300000000},
                new Planet { Name="Mon Cala",Terrain= new List<string>{ "oceans", "reefs","islands"},RotationPeriod=21,SurfaceWater=100,Diameter=11030,Population=27000000000},
                new Planet { Name="Chandrila", Terrain= new List<string>{ "plains", "forests"},RotationPeriod=20,SurfaceWater=40,Diameter=13500,Population=1200000000},
                new Planet { Name="Sullust", Terrain= new List<string>{ "mountains", "volcanoes","rocky deserts"},RotationPeriod=20,SurfaceWater=5, Diameter=12780, Population=18500000000},
                new Planet { Name="Toydaria", Terrain= new List<string>{ "swamps", "lakes"},RotationPeriod=21, Diameter=7900, Population=11000000},
                new Planet { Name="Malastare",Terrain= new List<string>{ "swamps", "deserts","jungles","mountains"},RotationPeriod=26, Diameter=18880, Population=2000000000},
                new Planet { Name="Dathomir",Terrain= new List<string>{ "forests", "deserts","savannas"},RotationPeriod=24, Diameter=10480, Population=5200},
                new Planet { Name="Ryloth",Terrain= new List<string>{ "mountains", "valleys","deserts","tundra"},RotationPeriod=30,SurfaceWater=5,Diameter=10600, Population=1500000000 },
                new Planet { Name="Aleen Minor"},
                new Planet { Name="Vulpter",Terrain= new List<string>{ "urban", "barren"} ,RotationPeriod=22, Diameter=14900, Population=421000000},
                new Planet { Name="Troiken",Terrain= new List<string>{ "desert", "tundra","rainforests","mountains"} },
                new Planet { Name="Tund",Terrain= new List<string>{ "barren", "ash"} ,RotationPeriod=48, Diameter=12190},
                new Planet { Name="Haruun Kal",Terrain= new List<string>{ "toxic cloudsea", "plateaus","volcanoes"},RotationPeriod=25,Diameter=10120,Population=705300},
                new Planet { Name="Cerea",Terrain= new List<string>{ "verdant"},RotationPeriod=27,SurfaceWater=20,Population=450000000},
                new Planet { Name="Glee Anselm",Terrain= new List<string>{ "islands","lakes","swamps", "seas"},RotationPeriod=33,SurfaceWater=80, Diameter=15600,Population=500000000},
                new Planet { Name="Iridonia",Terrain= new List<string>{ "rocky canyons","acid pools"},RotationPeriod=29},
                new Planet { Name="Tholoth"},
                new Planet { Name="Iktotch",Terrain= new List<string>{ "rocky"},RotationPeriod=22},
                new Planet { Name="Quermia",},
                new Planet { Name="Dorin",RotationPeriod=22, Diameter=13400},
                new Planet { Name="Champala",Terrain= new List<string>{ "oceans","rainforests","plateaus"},RotationPeriod=27, Population=3500000000},
                new Planet { Name="Mirial",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Serenno",Terrain= new List<string>{ "rivers","rainforests","mountains"}},
                new Planet { Name="Concord Dawn",Terrain= new List<string>{ "jungles","forests","deserts"}},
                new Planet { Name="Zolan" },
                new Planet { Name="Ojom",Terrain= new List<string>{ "oceans","glaciers"},SurfaceWater=100, Population=500000000},
                new Planet { Name="Skako", Terrain = new List<string>{ "urban","vines"},RotationPeriod=27, Population=500000000000},
                new Planet { Name="Muunilinst",Terrain= new List<string>{ "plains","forests","hills","mountains"} ,RotationPeriod=28,SurfaceWater=25, Diameter=13800, Population=5000000000},
                new Planet { Name="Shili",Terrain= new List<string>{ "cities","savannahs","seas","plains"}},
                new Planet { Name="Kalee",Terrain= new List<string>{ "rainforests","cliffs","seas","canyons"},RotationPeriod=23, Diameter=13850, Population=4000000000},
                new Planet { Name="Umbara"},
                new Planet { Name="Tatooine",Terrain= new List<string>{ "deserts"},RotationPeriod=23,SurfaceWater=1, Diameter=10465, Population=200000 },
                new Planet { Name="Jakku",Terrain= new List<string>{ "deserts"}},
                new Planet { Name="Alderaan",Terrain= new List<string>{ "grasslands","mountains"},RotationPeriod=24,SurfaceWater=40, Diameter=12500, Population= 2000000000},
                new Planet { Name="Yavin IV", Terrain= new List<string>{ "rainforests","jungle"},RotationPeriod=24,SurfaceWater=8,Diameter=10200,Population=     1000},
                new Planet { Name="Hoth", Terrain= new List<string>{ "tundra","ice caves","mountain ranges"},RotationPeriod=23,SurfaceWater=100},
                new Planet { Name="Dagobah",Terrain= new List<string>{ "swamp","jungles"},RotationPeriod=23,SurfaceWater=8},
                new Planet { Name="Bespin",Terrain= new List<string>{ "gas giant"},RotationPeriod=12, Diameter=118000,Population=  6000000},
                new Planet { Name="Endor",Terrain= new List<string>{ "forests","mountains","lakes"},RotationPeriod=18,SurfaceWater=8, Diameter=4900, Population= 30000000},
                new Planet { Name="Naboo",Terrain= new List<string>{ "grassy hills","swamps","forests","mountains"},RotationPeriod=26,SurfaceWater=12, Diameter=12120, Population=  4500000000},
                new Planet { Name="Coruscant",Terrain= new List<string>{ "cityscape","mountains"},RotationPeriod=24,Diameter=12240,Population=1000000000000},
                new Planet { Name="Kamino",Terrain= new List<string>{ "ocean"},RotationPeriod=27,SurfaceWater=100,Diameter=19720, Population=1000000000},
                new Planet { Name="Geonosis",Terrain= new List<string>{ "rock","desert","mountain","barren"},RotationPeriod=30,SurfaceWater=5,Diameter=11370, Population=100000000000},
                new Planet { Name="Utapau",Terrain= new List<string>{ "scrublands","savanna","canyons","sinkholes"},RotationPeriod=27,SurfaceWater=0.9f,Diameter=12900,Population=  95000000},
                new Planet { Name="Mustafar",Terrain= new List<string>{ "volcanoes","lava rivers","mountains","caves"},RotationPeriod=36,  Diameter=4200, Population=20000},
                new Planet { Name="Kashyyyk",Terrain= new List<string>{ "jungle","forests","lakes","rivers"},RotationPeriod=26 ,SurfaceWater=60,Diameter=12765, Population=45000000},
                new Planet { Name="Polis Massa",Terrain= new List<string>{ "airless","asteroid"},RotationPeriod=24, Diameter=0, Population=1000000},
                new Planet { Name="Mygeeto",Terrain= new List<string>{ "glaciers","mountains","ice canyons"},RotationPeriod=12, Diameter=10088, Population=  19000000},
                new Planet { Name="Felucia",Terrain= new List<string>{ "fungus","forests"},RotationPeriod=34, Diameter=9100,Population=8500000},
                new Planet { Name="Cato Neimoidia",Terrain= new List<string>{ "mountains","fields","forests","rock arches"},RotationPeriod=25, Population=10000000},
                new Planet { Name="Saleucami",Terrain= new List<string>{ "caves", "deserts","mountains","volcanoes"},RotationPeriod=26, Population=1400000000, Diameter=14920},
                new Planet { Name="Stewjon",Terrain= new List<string>{ "grass"}},
                new Planet { Name="Eriadu",Terrain= new List<string>{ "cityscape"},RotationPeriod=24, Diameter=13490  , Population= 22000000000},
             };
          return planets;
        }
    }
}
