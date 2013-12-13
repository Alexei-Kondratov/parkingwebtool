using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWebTool.Domain
{
    public class ParkingPlace
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public User Owner { get; set; }

        public RentProposal RentProposal { get; set; }
    }
}
