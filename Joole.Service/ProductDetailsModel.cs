using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Joole.Service
{
    public class ProductDetailsModel
    {
        public int Product_ID { get; set; }
        //DESCRIPTION
        public string Manufacture { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        //Type
        public string UseType { get; set; }
        public string Application { get; set; }
        public string MountingLocation { get; set; }
        public string Accessories { get; set; }
        public string ModelYear { get; set; }
        //TECHNICAL SPECIFICATIONS
        public string AirFlow { get; set; }
        public string PowerMin { get; set; }
        public string PowerMax { get; set; }
        public string OperatingVoltageMin { get; set; }
        public string OperatingVoltageMax { get; set; }
        public string FanSpeedMin { get; set; }
        public string FanSpeedMax { get; set; }
        public string NumberOfFanSpeed {get;set;}
        public string SoundAtMaxSpeed { get; set; }
        public string FanSweepDiameter { get; set; }
        public string HeightMin { get; set; }
        public string HeightMax { get; set; }
        public string Weight { get; set; }
        
    }
}
