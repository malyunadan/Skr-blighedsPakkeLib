using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public class SensorEventRepository
    {
        private readonly List<SensorEvent> sensorEvents = new List<SensorEvent>();
        // Tilføj en sensorhændelse til repository
        public void AddSensorEvent(SensorEvent sensorEvent)
        {
            sensorEvents.Add(sensorEvent);
        }
        // Hent alle sensorhændelser
        public List<SensorEvent> GetAllSensorEvents()
        {
            return sensorEvents;
        }
    }
}
