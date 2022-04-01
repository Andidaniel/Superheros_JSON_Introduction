using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONIntroduction.Models;
using Newtonsoft.Json;

namespace JSONIntroduction
{


    static class JSONManipulator
    {
        public static string JsonContent { get; set; }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader(".\\..\\..\\..\\superheroes.json"))
            {
                JsonContent = r.ReadToEnd();
            }
        }

        public static List<Superheroes> Deserializer()
        {
            List<Superheroes> superheroes = JsonConvert.DeserializeObject<List<Superheroes>>(JsonContent);

            return superheroes;
        }
        

        public static void Serializer(List<Superheroes> superheroes)
        {
            var serializedList = JsonConvert.SerializeObject(superheroes, Formatting.Indented);

            using (StreamWriter sr = new StreamWriter(@".\..\..\..\test.json"))
            {
                foreach (var superheroe in serializedList)
                {
                    sr.Write(superheroe);
                }
            }
        }
    }
}
