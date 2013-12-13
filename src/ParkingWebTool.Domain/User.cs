using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWebTool.Domain
{
    public class User
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}
