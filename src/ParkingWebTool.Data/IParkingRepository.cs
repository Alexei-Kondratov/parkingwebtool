using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingWebTool.Data.Model;

namespace ParkingWebTool.Data
{
    public interface IParkingRepository
    {
        User GetUserByName(string userName);
        User GetUserById(string id);
        User AddUser(User item);
        bool RemoveUser(string id);
        bool UpdateUser(string id, User user);

        IEnumerable<User> GetQueueUsers();
        IEnumerable<User> GetPalaceOwners();
    }
}
