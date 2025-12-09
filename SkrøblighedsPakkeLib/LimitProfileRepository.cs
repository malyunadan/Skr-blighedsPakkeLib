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

        // Tjek om en profil findes
        public bool LimitProfileExists(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT COUNT(*) FROM LimitProfiles WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

            return (int)command.ExecuteScalar() > 0;
        }

        // Tilføj en profil
        public void AddLimitProfile(LimitProfile limitProfile)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand(
                "INSERT INTO LimitProfiles (Name, MaxTiltDegrees, IsFragile) VALUES (@Name, @MaxTiltDegrees, @IsFragile)",
                connection);

            command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = limitProfile.Name;
            command.Parameters.Add("@MaxTiltDegrees", System.Data.SqlDbType.Decimal).Value = limitProfile.MaxTiltDegrees;
            command.Parameters.Add("@IsFragile", System.Data.SqlDbType.Bit).Value = limitProfile.IsFragile;

            command.ExecuteNonQuery();
        }

        // Hent en profil baseret på ID
        public LimitProfile GetLimitProfileById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var command = new SqlCommand("SELECT Id, Name, MaxTiltDegrees, IsFragile FROM LimitProfiles WHERE Id = @Id", connection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new LimitProfile
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    MaxTiltDegrees = (double)reader.GetDecimal(reader.GetOrdinal("MaxTiltDegrees")),
                    IsFragile = reader.GetBoolean(reader.GetOrdinal("IsFragile"))
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

            var command = new SqlCommand("SELECT Id, Name, MaxTiltDegrees, IsFragile FROM LimitProfiles", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new LimitProfile
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    MaxTiltDegrees = (double)reader.GetDecimal(reader.GetOrdinal("MaxTiltDegrees")),
                    IsFragile = reader.GetBoolean(reader.GetOrdinal("IsFragile"))
                });
            }

            return result;
        }
    }
}

