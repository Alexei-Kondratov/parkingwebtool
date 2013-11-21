using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using ParkingWebTool.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingWebTool.Data.MongoDB
{
    public class MongoClassMapper
    {
        public static void InitClassMappings()
        {
            BsonSerializer.RegisterIdGenerator(typeof(string), StringObjectIdGenerator.Instance);

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.Id));
            });
        }
    }
}
