using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWebTool.Web.Api.Models
{
    public class ParkingUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ParkingPlaceNumber { get; set; }
        public bool InQueue { get; set; }
    }
}
