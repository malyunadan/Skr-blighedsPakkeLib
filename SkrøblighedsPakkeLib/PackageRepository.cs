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

        // Helper: Tjek om LimitProfileId findes i databasen
        private bool LimitProfileExists(int limitProfileId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("SELECT COUNT(*) FROM LimitProfiles WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = limitProfileId;

            return (int)command.ExecuteScalar() > 0;
        }

        // Tilføj en pakke til databasen
        public bool AddPackage(Package package)
        {
            if (!LimitProfileExists(package.LimitProfileId))
                return false; // eller throw new Exception(...) hvis du vil stoppe hårdt

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(
                "INSERT INTO Packages_TEMP (Id, Description, LimitProfileId) VALUES (@Id, @Description, @LimitProfileId)",
                connection);

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = package.Id;
            command.Parameters.Add("@Description", System.Data.SqlDbType.NVarChar, 100).Value = package.Description;
            command.Parameters.Add("@LimitProfileId", System.Data.SqlDbType.Int).Value = package.LimitProfileId;

            command.ExecuteNonQuery();
            return true;
        }

        // Hent en pakke baseret på ID
        public Package GetPackageById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(
                "SELECT Id, Description, LimitProfileId FROM Packages_TEMP WHERE Id = @Id",
                connection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Package
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    LimitProfileId = reader.GetInt32(reader.GetOrdinal("LimitProfileId"))
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

            using var command = new SqlCommand(
                "SELECT Id, Description, LimitProfileId FROM Packages_TEMP",
                connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Package
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    LimitProfileId = reader.GetInt32(reader.GetOrdinal("LimitProfileId"))
                });
            }

            return result;
        }
    }
}
