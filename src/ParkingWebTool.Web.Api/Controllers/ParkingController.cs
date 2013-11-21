using ParkingWebTool.Data;
using ParkingWebTool.Data.Model;
using ParkingWebTool.Web.Api.Models;
using ParkingWebTool.Web.Api.TypeMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingWebTool.Web.Api.Controllers
{
    public class ParkingController : ApiController
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IParkingUserMapper _parkingUserMapper;

        public ParkingController(IParkingRepository parkingRepository, IParkingUserMapper parkingUserMapper)
        {
            _parkingRepository = parkingRepository;
            _parkingUserMapper = parkingUserMapper;
        }

        // GET api/values
        public IEnumerable<ParkingUser> Get()
        {
            List<ParkingUser> resultUsers = new List<ParkingUser>();
            IEnumerable<User> placeOwners = _parkingRepository.GetPalaceOwners();

            foreach (User placeOwner in placeOwners)
            {
                resultUsers.Add(_parkingUserMapper.CreateUser(placeOwner));
            }

            return resultUsers;
        }

        // GET api/values/5
        public ParkingUser Get(int id)
        {
            return null;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
