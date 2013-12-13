
using System;

namespace ParkingWebTool.Domain
{
    public class RentRequest
    {
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        public User Requestor { get; set; }
    }
}
