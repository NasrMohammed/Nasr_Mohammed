using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Location
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }       
        
        
        public Location() { } // default constructor

        public Location(string locationID,
                         string locationName)                      
                        
                       
        {
            LocationID = locationID;
            LocationName = locationName;
              
        }
    }
}
