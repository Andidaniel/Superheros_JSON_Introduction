using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using JSONIntroduction.Models;

namespace JSONIntroduction
{
    class Program
    {

        static void HowManyHeroes(List<Superheroes> superheroes) //1
        {
            Console.WriteLine($"There are {superheroes.Count} heroes in the file");
        }
        static void CategorizeHeroes( List<Superheroes> allHeroes) //2
        {
            List<Superheroes> goodS = new List<Superheroes>();
            List<Superheroes> badS = new List<Superheroes>();
            List<Superheroes> neutralS = new List<Superheroes>();
            foreach (Superheroes hero in allHeroes)
            {
                switch (hero.Biography.Alignment)
                {
                    case "good":
                        goodS.Add(hero);
                        break;
                    case "bad":
                        badS.Add(hero);
                        break;
                    case "neutral":
                        neutralS.Add(hero);
                        break;
                    default:
                      // Console.WriteLine(hero.Name); // There are heroes that have "-" as alignment
                        break;
                }
            }
            Console.WriteLine($"Good: {goodS.Count}");
            Console.WriteLine($"Bad: {badS.Count}");
            Console.WriteLine($"Neural: {neutralS.Count}");
        }

        static void OrderHeroes(List<Superheroes> superheroes) //3
        {
            List<Superheroes> orderedHeroes = superheroes
                .OrderByDescending(s => s.Powerstats.Speed)
                .ThenByDescending(s => s.Powerstats.Power)
                .ToList();

            foreach (Superheroes superheroe in orderedHeroes)
            {
                if (superheroe.Appearance.Race != null)
                {
                    Console.WriteLine($"Name: {superheroe.Name}\n" +
                                      $"Gender: {superheroe.Appearance.Gender}\n" +
                                      $"Race: {superheroe.Appearance.Race}\n");
                }
                else
                {
                    Console.WriteLine($"Name: {superheroe.Name}\n" +
                                      $"Gender: {superheroe.Appearance.Gender}\n" +
                                      $"Race: undefined\n");
                }
            }

        }

        static void DisplayBaldHeroes(List<Superheroes> superheroes) //4
        {
            foreach (var superhero in superheroes)
            {
                if (superhero.Appearance.HairColor == "No Hair")
                {
                    Console.WriteLine(superhero.Name);
                    Console.WriteLine();
                }
            }
        }
        static void NoAlterEgo(List<Superheroes> superheroes) //5
        {
            var count = 0;

            foreach (var superhero in superheroes)
            {
                if (superhero.Biography.AlterEgos.Equals("No alter egos found."))
                {
                    count++;
                }
            }
            Console.WriteLine("Number of heroes without alter egoes: " + count);
        }

        static void SameFirstAppearance(List<Superheroes> superheroes) //6
        {
            var groupByFirstAppearance =
                from superhero in superheroes
                group superhero by superhero.Biography.FirstAppearance
                into newGroup
                orderby newGroup.Key
                select newGroup;
            foreach (var group in groupByFirstAppearance)
            {
                if (group.Count() > 1 && group.Key!="-")
                {
                    Console.WriteLine($"First appearance: {group.Key}\n");
                    foreach (var superhero in group)
                    {
                        Console.WriteLine('\t'+superhero.Name+'\n');
                    }
                }

            }
        }
        static void UpdateHeroBasedOnName(List<Superheroes> superheroes, string heroName, string newFirstAppearence, string newRace) //7
        {
            foreach (var superhero in superheroes)
            {
                if (superhero.Name == heroName)
                {
                    superhero.Biography.FirstAppearance = newFirstAppearence;
                    superhero.Appearance.Race = newRace;
                    break;
                }
            }
        }

        static void UpdateHeroBasedOnId(List<Superheroes> superheroes, int _id)//8
        {
            string val;

            Console.WriteLine("What's the new ID?");
            val = Console.ReadLine();
            int id = Convert.ToInt32(val);

            Console.WriteLine("What's the new name?");
            string name = Console.ReadLine();

            Console.WriteLine("What's the new slug?");
            string slug = Console.ReadLine();

            Console.WriteLine("What's the new intelligence?");
            val = Console.ReadLine();
            int intelligence = Convert.ToInt32(val);

            Console.WriteLine("What's the new strength?");
            val = Console.ReadLine();
            int strength = Convert.ToInt32(val);

            Console.WriteLine("What's the new speed?");
            val = Console.ReadLine();
            int speed = Convert.ToInt32(val);

            Console.WriteLine("What's the new durability?");
            val = Console.ReadLine();
            int durability = Convert.ToInt32(val);

            Console.WriteLine("What's the new power?");
            val = Console.ReadLine();
            int power = Convert.ToInt32(val);

            Console.WriteLine("What's the new combat?");
            val = Console.ReadLine();
            int combat = Convert.ToInt32(val);

            Console.WriteLine("What's the new gender?");
            string gender = Console.ReadLine();

            Console.WriteLine("What's the new race?");
            string race = Console.ReadLine();

            Console.WriteLine("What's the new heightAsInch?");
            string heightAsInch = Console.ReadLine();

            Console.WriteLine("What's the new heightAsCM?");
            string heightAsCM = Console.ReadLine();
            string weightAsLB;
           Console.WriteLine("Enter new weight(as lb): ");
           weightAsLB = Console.ReadLine();

           string weightAsKG;
           Console.WriteLine("Enter new weight(as kg): ");
           weightAsKG = Console.ReadLine();

            string eyeColor;
            Console.WriteLine("Enter new Eye Color: ");
            eyeColor = Console.ReadLine();

           string hairColor;
           Console.WriteLine("Enter new Hair Color: ");
           hairColor = Console.ReadLine();

           string fullName;
           Console.WriteLine("Enter new Full Name: ");
           fullName = Console.ReadLine();
                

           string alterEgos;
           Console.WriteLine("Enter new Alter Egos: ");
           alterEgos = Console.ReadLine();

           int numberOfAliases;
           Console.WriteLine("Enter new number of Aliases: ");
            int.TryParse(Console.ReadLine(),out numberOfAliases);

            List<string> aliases = new List<string>();
            for (int i = 0; i < numberOfAliases; i++)
            {
                string alias;
                Console.WriteLine($"Enter new alias ({i}): ");
                alias = Console.ReadLine();
                aliases.Add(alias);
            }

           string placeOfBirth;
           Console.WriteLine("Enter new Place of birth: ");
            placeOfBirth = Console.ReadLine();


           string firstAppearance;
           Console.WriteLine("Enter new First Appearance: ");
           firstAppearance = Console.ReadLine();

           string publisher;
           Console.WriteLine("Enter new Publisher: ");
           publisher = Console.ReadLine();


            string alignment;
            Console.WriteLine("Enter new Alignment: ");
            alignment = Console.ReadLine();

            string occupation;
            Console.WriteLine("Enter new Occupation: ");
            occupation = Console.ReadLine();


            string Base;
            Console.WriteLine("Enter new Base: ");
            Base = Console.ReadLine();

            string groupAffiliation;
            Console.WriteLine("Enter new Group Affiliation: ");
            groupAffiliation = Console.ReadLine();

            string relatives;
            Console.WriteLine("Enter new Relatives: ");
            relatives = Console.ReadLine();



            int left = 0;
            int right = superheroes.Count - 1;
            while (left<=right)
            {
                if (superheroes[(left + right) / 2].Id == _id)
                {
                    superheroes[(left + right) / 2].Id = id;
                    superheroes[(left + right) / 2].Name = name;
                    superheroes[(left + right) / 2].Slug = slug;
                    superheroes[(left + right) / 2].Powerstats.Intelligence = intelligence;
                    superheroes[(left + right) / 2].Powerstats.Strength = strength;
                    superheroes[(left + right) / 2].Powerstats.Speed = speed;
                    superheroes[(left + right) / 2].Powerstats.Durability = durability;
                    superheroes[(left + right) / 2].Powerstats.Power = power;
                    superheroes[(left + right) / 2].Powerstats.Combat = combat;
                    superheroes[(left + right) / 2].Appearance.Gender = gender;
                    superheroes[(left + right) / 2].Appearance.Race = race;
                    superheroes[(left + right) / 2].Appearance.Height.Clear();
                    superheroes[(left + right) / 2].Appearance.Height.Add(heightAsCM);
                    superheroes[(left + right) / 2].Appearance.Height.Add(heightAsInch);
                    superheroes[(left + right) / 2].Appearance.Weight.Clear();
                    superheroes[(left + right) / 2].Appearance.Weight.Add(weightAsKG);
                    superheroes[(left + right) / 2].Appearance.Weight.Add(weightAsLB);
                    superheroes[(left + right) / 2].Appearance.EyeColor = eyeColor;
                    superheroes[(left + right) / 2].Appearance.HairColor = hairColor;
                    superheroes[(left + right) / 2].Biography.FullName = fullName;
                    superheroes[(left + right) / 2].Biography.AlterEgos = alterEgos;
                    superheroes[(left + right) / 2].Biography.Aliases = aliases;
                    superheroes[(left + right) / 2].Biography.PlaceOfBirth = placeOfBirth;
                    superheroes[(left + right) / 2].Biography.FirstAppearance = firstAppearance;
                    superheroes[(left + right) / 2].Biography.Publisher = publisher;
                    superheroes[(left + right) / 2].Biography.Alignment = alignment;
                    superheroes[(left + right) / 2].Work.Occupation = occupation;
                    superheroes[(left + right) / 2].Work.Base = Base;
                    superheroes[(left + right) / 2].Connections.GroupAffiliation = groupAffiliation;
                    superheroes[(left + right) / 2].Connections.Relatives = relatives;
                    break;
                }
                else if (superheroes[(left + right) / 2].Id < _id)
                {
                    left = (left + right) / 2 + 1;
                }
                else
                {
                    right = (left + right) / 2 - 1;
                }
            }

          
        }

        static void Main(string[] args)
        {
            List<Superheroes> superheroes = new List<Superheroes>();


            JSONManipulator.LoadJson();

            superheroes = JSONManipulator.Deserializer();


            JSONManipulator.Serializer(superheroes);

            // HowManyHeroes(superheroes);  //1
            // CategorizeHeroes(superheroes); //2
            // OrderHeroes(superheroes);//3
            // DisplayBaldHeroes(superheroes);//4
            // NoAlterEgo(superheroes);//5
            // SameFirstAppearance(superheroes);//6
            // UpdateHeroBasedOnName(superheroes,"Spiderman","The Amazing Spider-Man","Humanoid");//7
            // UpdateHeroBasedOnId(superheroes, 5);//8  --- CHECK THE TEST.JSON ON ID 5
        }
    }
}
