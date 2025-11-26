using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class SensorEvent
    {
        public int Id { get; set; }                  // Primær nøgle til database
        public DateTime Timestamp { get; set; }      // Hvornår målingen blev taget
        public double Acceleration { get; set; }     // Målt acceleration
        public double Tilt { get; set; }             // Vinkelmåling (tilt)
       

        // Reference til hvilken pakke målingen hører til
        public string PackageId { get; set; }
    }
}