using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;// Til JSON serialization, fordi vi kun har getters og det betyder vi måske får problemer med rest API'et, da det ikke kan sætte værdierne.

namespace SkrøblighedsPakkeLib
{
    public class LimitProfile
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public double MaxTiltDegrees { get; set; }
        public bool IsFragile { get; set; }

        // Konstruktør sætter værdierne én gang
        public LimitProfile(int id, string name, double maxTiltDegrees, bool isFragile)
        {
            Id = id;
            Name = name;
            MaxTiltDegrees = maxTiltDegrees;
            IsFragile = isFragile;
        }
        public LimitProfile() { }
    }
}