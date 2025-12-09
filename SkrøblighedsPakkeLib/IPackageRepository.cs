using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public interface IPackageRepository
    {
        bool AddPackage(Package package);
        Package GetPackageById(int Id);
        List<Package> GetAllPackages();

    }
}
