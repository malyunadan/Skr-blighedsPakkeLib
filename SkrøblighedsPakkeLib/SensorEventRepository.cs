using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SkrøblighedsPakkeLib
{
    public class SensorEventRepository : ISensorEventRepository
    {
        private readonly string _connectionString;

        public SensorEventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tilføj en sensorhændelse
        public void AddSensorEvent(SensorEvent sensorEvent)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO SensorEvents (Tilt, PackageId) VALUES (@Tilt, @PackageId)",
                connection);
            command.Parameters.AddWithValue("@Tilt", sensorEvent.Tilt);
            command.Parameters.AddWithValue("@PackageId", sensorEvent.PackageId);
            command.ExecuteNonQuery();
        }

        // Hent en sensorhændelse baseret på ID
        public SensorEvent GetEventById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM SensorEvents WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new SensorEvent
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    Tilt = (double)Convert.ToDecimal(reader["Tilt"]),
                    PackageId = reader["PackageId"].ToString()
                };
            }
            return null;
        }

        // Hent alle sensorhændelser
        public List<SensorEvent> GetAllSensorEvents()
        {
            var result = new List<SensorEvent>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM SensorEvents", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new SensorEvent
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    Tilt = (double)Convert.ToDecimal(reader["Tilt"]),
                    PackageId = reader["PackageId"].ToString()
                });
            }
            return result;
        }

        // Hent alle events for en bestemt pakke
        public List<SensorEvent> GetEventsByPackageId(string packageId)
        {
            var result = new List<SensorEvent>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("SELECT * FROM SensorEvents WHERE PackageId = @PackageId", connection);
            command.Parameters.AddWithValue("@PackageId", packageId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new SensorEvent
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    Tilt = (double)Convert.ToDecimal(reader["Tilt"]),
                    PackageId = reader["PackageId"].ToString()
                });
            }
            return result;
        }
    }
}
