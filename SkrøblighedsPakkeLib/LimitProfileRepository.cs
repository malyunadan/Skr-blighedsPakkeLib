using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class LimitProfileRepository : ILimitProfileRepository
    {
        private readonly List<LimitProfile> limitProfiles = new List<LimitProfile>();

        // Tilføj en profil (fx ved opstart af systemet)
        public void AddLimitProfile(LimitProfile limitProfile)
        {
            limitProfiles.Add(limitProfile);
        }

        // Hent en profil baseret på ID
        public LimitProfile GetLimitProfileById(int id)
        {
            return limitProfiles.FirstOrDefault(lp => lp.Id == id);
        }

        // Hent alle profiler
        public List<LimitProfile> GetAllLimitProfiles()
        {
            return limitProfiles;
        }
    }
}

