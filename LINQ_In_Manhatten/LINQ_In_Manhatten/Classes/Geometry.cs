using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LINQ_In_Manhatten.Classes
{
    public class Geometry
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }
    }
}
