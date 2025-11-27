using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class LimitProfile
    {
        public int Id { get; }
        public string Name { get; }
        public double MaxTiltDegrees { get; }
        public bool IsFragile { get; }

        // Konstruktør sætter værdierne én gang
        public LimitProfile(int id, string name, double maxTiltDegrees, bool isFragile)
        {
            Id = id;
            Name = name;
            MaxTiltDegrees = maxTiltDegrees;
            IsFragile = isFragile;
        }
    }
}