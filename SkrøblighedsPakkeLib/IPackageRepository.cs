using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public interface IPackageRepository
    {
        void AddPackage(Package package);
        Package GetPackageById(string Id);
        List<Package> GetAllPackages();
    }
}
