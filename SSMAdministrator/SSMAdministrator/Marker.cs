using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap;
using GMap.NET;
using GMap.NET.WindowsPresentation;

namespace SSMAdministrator
{
    class Marker
    {
        public string MarkerName;
        public string Description;
        public PointLatLng CoordLatLng;
        public bool Freeware;
        public int Sim;
        public GMapMarker GmMarker;
        

        public override string ToString()
        {
            return "Name:" + MarkerName + "Description" + Description + 
                "Coords: "+ CoordLatLng.ToString() + "Is FreeWare: " + Freeware.ToString();
        }
    }
}
