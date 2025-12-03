using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public interface ILimitProfileRepository
    {
        void AddLimitProfile(LimitProfile limitProfile);
        LimitProfile GetLimitProfileById(int id);
        List<LimitProfile> GetAllLimitProfiles();

        List<LimitProfile> GetLimitProfilesByUserId(int userId);
    }
}