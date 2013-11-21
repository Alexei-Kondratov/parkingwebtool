using ParkingWebTool.Data.Model;
using ParkingWebTool.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingWebTool.Web.Api.TypeMappers
{
    public interface IParkingUserMapper
    {
        ParkingUser CreateUser(string firstname, string lastname, string email, int parkingPlaceNum, bool isInQueue, string userId);
        ParkingUser CreateUser(User modelUser);
    }
}