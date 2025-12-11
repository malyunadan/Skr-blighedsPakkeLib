using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib
{
    public interface ISensorEventRepository
    {
        void AddSensorEvent(SensorEvent sensorEvent);
        List<SensorEvent> GetAllSensorEvents();
        SensorEvent GetEventById(int id);
        public List<SensorEvent> GetEventsByPackageId(int packageId);
    }
}
