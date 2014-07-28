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
        public GMapMarker GmMarker;
        public string MarkerName;
        public string Description;
        public bool Freeware;
        public int Sim;
        
        

        public override string ToString()
        {
            return "Name:" + MarkerName + "Description" + Description + 
                "Is FreeWare: " + Freeware.ToString();
        }
    }
}
