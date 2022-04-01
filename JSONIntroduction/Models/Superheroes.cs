using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thursday_Course;

namespace JSONIntroduction.Models
{
    class Superheroes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public Powerstats Powerstats { get; set; }

        public Appearence Appearance { get; set; }

        public Biography Biography { get; set; }

        public Work Work { get; set; }

        public Connections Connections { get; set; }

        public Images Images { get; set; }
    }
}
