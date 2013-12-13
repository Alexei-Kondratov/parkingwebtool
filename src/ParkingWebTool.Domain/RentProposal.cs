using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ParkingWebTool.Domain
{
    public class RentProposal
    {
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        public Collection<RentRequest> Requests { get; set; }
    }
}
