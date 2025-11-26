using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class LimitProfile
    {
        public bool IsFragile { get; set; } // Angiver om pakken er skrøbelig

        // Mulighed for at ændre status via webinterface
        public void SetFragile(bool fragile)
        {
            IsFragile = fragile;
        }
    }
}
