using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SkrøblighedsPakkeLib
{
    public class PackageRepository : IPackageRepository
    {
        private readonly string _connectionString;

        public PackageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tilføj en pakke til databasen
        public void AddPackage(Package package)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO Packages (Id, Description, LimitProfileId) VALUES (@Id, @Description, @LimitProfileId)",
                connection);
            command.Parameters.AddWithValue("@Id", package.Id);
            command.Parameters.AddWithValue("@Description", package.Description);
            command.Parameters.AddWithValue("@LimitProfileId", package.LimitProfileId);
            command.ExecuteNonQuery();
        }

        public Package GetPackageById(int Id)
        {
            throw new NotImplementedException();
        }

        // Hent en pakke baseret på ID (string, da NVARCHAR i SQL)
        public Package GetPackageById(string id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Packages WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Package
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    LimitProfileId = Convert.ToInt32(reader["LimitProfileId"])
                };
            }
            return null;
        }

        // Hent alle pakker
        public List<Package> GetAllPackages()
        {
            var result = new List<Package>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Packages", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Package
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Description = reader["Description"].ToString(),
                    LimitProfileId = Convert.ToInt32(reader["LimitProfileId"])
                });
            }
            return result;
        }
    }
}

