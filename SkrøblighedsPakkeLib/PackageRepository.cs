using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class PackageRepository : IPackageRepository
    {
        private readonly List<Package> packages = new List<Package>();
        // Tilføj en pakke til repository
        public void AddPackage(Package package)
        {
            packages.Add(package);
        }
        // Hent en pakke baseret på ID
        public Package GetPackageById(string id)
        {
            return packages.FirstOrDefault(p => p.Id == id);
        }
        // Hent alle pakker
        public List<Package> GetAllPackages()
        {
            return packages;
        }

    }
}
