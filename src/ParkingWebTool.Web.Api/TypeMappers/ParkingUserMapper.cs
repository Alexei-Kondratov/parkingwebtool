using ParkingWebTool.Data.Model;
using ParkingWebTool.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingWebTool.Web.Api.TypeMappers
{
    public class ParkingUserMapper : IParkingUserMapper
    {
        public ParkingUser CreateUser(string firstname, string lastname, string email, int parkingPlaceNum, bool isInQueue, string userId)
        {
            return new ParkingUser
                   {
                       FirstName = firstname,
                       LastName = lastname,
                       Email = email,
                       ParkingPlaceNumber = parkingPlaceNum,
                       InQueue = isInQueue,
                       Id = userId
                   };
        }

        public ParkingUser CreateUser(User modelUser)
        {
            return CreateUser(modelUser.FirstName,
                              modelUser.LastName,
                              modelUser.Email,
                              modelUser.ParkingPlaceNumber,
                              modelUser.InQueue,
                              modelUser.Id);
        }
    }
}