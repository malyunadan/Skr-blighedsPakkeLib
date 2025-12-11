using System;
using System.Collections.Generic;
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
            using var command = new SqlCommand(
                "INSERT INTO SensorEvents (Tilt, PackageId) VALUES (@Tilt, @PackageId)",
                connection);

            // Use explicit types to avoid AddWithValue pitfalls
            command.Parameters.Add(new SqlParameter("@Tilt", System.Data.SqlDbType.Float) { Value = sensorEvent.Tilt });
            command.Parameters.Add(new SqlParameter("@PackageId", System.Data.SqlDbType.Int) { Value = sensorEvent.PackageId });

            command.ExecuteNonQuery();
        }

        // Hent en sensorhændelse baseret på ID
        public SensorEvent GetEventById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM SensorEvents WHERE Id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id });

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return MapFromReader(reader);
            }
            return null;
        }

        // Hent alle sensorhændelser
        public List<SensorEvent> GetAllSensorEvents()
        {
            var result = new List<SensorEvent>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM SensorEvents", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(MapFromReader(reader));
            }
            return result;
        }

        // Hent alle events for en bestemt pakke
        public List<SensorEvent> GetEventsByPackageId(int packageId)
        {
            var result = new List<SensorEvent>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM SensorEvents WHERE PackageId = @PackageId", connection);
            command.Parameters.Add(new SqlParameter("@PackageId", System.Data.SqlDbType.Int) { Value = packageId });

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(MapFromReader(reader));
            }
            return result;
        }

        // Small helper to map a DataReader row to SensorEvent (avoid duplication)
        private static SensorEvent MapFromReader(SqlDataReader reader)
        {
            var Id = reader.GetOrdinal("Id");
            var Timestamp = reader.GetOrdinal("Timestamp");
            var Tilt = reader.GetOrdinal("Tilt");
            var packageId = reader.GetOrdinal("PackageId");

            return new SensorEvent
            {
                Id = reader.GetInt32(Id),
                Timestamp = reader.GetDateTime(Timestamp),
                Tilt = reader.GetDouble(Tilt),
                PackageId = reader.GetInt32(packageId)
            };
        }
    }
}