using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace SkrøblighedsPakkeLib
{
    public class LimitProfileRepository : ILimitProfileRepository
    {
        private readonly string _connectionString;

        public LimitProfileRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tilføj en profil
        public void AddLimitProfile(LimitProfile limitProfile)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO LimitProfiles (Name, MaxTiltDegrees, IsFragile) VALUES (@Name, @MaxTiltDegrees, @IsFragile)",
                connection);
            command.Parameters.AddWithValue("@Name", limitProfile.Name);
            command.Parameters.AddWithValue("@MaxTiltDegrees", limitProfile.MaxTiltDegrees);
            command.Parameters.AddWithValue("@IsFragile", limitProfile.IsFragile);
            command.ExecuteNonQuery();
        }

        // Hent en profil baseret på ID
        public LimitProfile GetLimitProfileById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM LimitProfiles WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new LimitProfile
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    MaxTiltDegrees = (double)Convert.ToDecimal(reader["MaxTiltDegrees"]),
                    IsFragile = Convert.ToBoolean(reader["IsFragile"])
                };
            }
            return null;
        }

        // Hent alle profiler
        public List<LimitProfile> GetAllLimitProfiles()
        {
            var result = new List<LimitProfile>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM LimitProfiles", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new LimitProfile
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    MaxTiltDegrees = (double)Convert.ToDecimal(reader["MaxTiltDegrees"]),
                    IsFragile = Convert.ToBoolean(reader["IsFragile"])
                });
            }
            return result;
        }
    }
}

