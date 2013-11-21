using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ParkingWebTool.Common;
using ParkingWebTool.Data.Model;
using ParkingWebTool.Data.MongoDB.Entities;

namespace ParkingWebTool.Data.MongoDB
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ILogService _logger;

        private MongoCollection<User> _usersCollection;
        private MongoServer _dbServer;
        private MongoDatabase _parkingDb;

        public ParkingRepository(ILogService logger)
        {
            _logger = logger;
        }

        public bool Initialize()
        {
            try
            {
                _usersCollection.RemoveAll();

                IEnumerable<User> testUserData = GetTestUsers();
                foreach (var userEntity in testUserData)
                {
                    AddUser(userEntity);
                }
            }
            catch (Exception ex)
            {
                _logger.Exception(ex);
                return false;
            }

            return true;
        }

        private static IEnumerable<User> GetTestUsers()
        {
            var testUsers = new List<User>();
            for (int i = 1; i <= 10; i++)
            {
                var user = new User()
                               {
                                   FirstName = string.Format("FirstName_{0}", i),
                                   LastName = string.Format("LastName_{0}", i),
                                   Email = string.Format("User{0}@globallogic.com", i),
                                   InQueue = i > 5,
                                   ParkingPlaceNumber = i > 5 ? 0 : 300 + i,
                               };

                testUsers.Add(user);
            }

            return testUsers;
        }


        public string ConnectionString 
        {
            get { return "mongodb://localhost:27017"; } 
        }

        public User GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            IMongoQuery findByIdQuery = Query<User>.EQ(e => e.Id, id);
            return _usersCollection.FindOneAs<User>(findByIdQuery);
        }

        public User AddUser(User item)
        {
            _usersCollection.Insert<User>(item);

            return item;
        }

        public bool RemoveUser(string id)
        {
            IMongoQuery removeQuery = Query<User>.EQ(e => e.Id, id);
            WriteConcernResult result = _usersCollection.Remove(removeQuery);
            return result.DocumentsAffected == 1;
        }

        public bool UpdateUser(string id, User user)
        {
            IMongoQuery query = Query<User>.EQ(e => e.Id, id);
            IMongoUpdate update = Update.Set("Email", user.Email)
                                        .Set("FirstName", user.FirstName)
                                        .Set("LastName", user.LastName)
                                        .Set("InQueue", user.InQueue)
                                        .Set("ParkingPlaceNumber", user.ParkingPlaceNumber);
            WriteConcernResult result = _usersCollection.Update(query, update);
            return result.UpdatedExisting; 
        }

        public IEnumerable<User> GetQueueUsers()
        {
            IMongoQuery query = Query<User>.EQ(e => e.InQueue, true);
            MongoCursor<User> usersInQueue = _usersCollection.FindAs<User>(query);
            return usersInQueue;
        }

        public IEnumerable<User> GetPalaceOwners()
        {
            if (!IsDbServerAvailabel)
            {
                _logger.Warning("Can't reach the database. Please check connection.");
                return null;
            }

            IMongoQuery query = Query<User>.EQ(e => e.InQueue, false);
            MongoCursor<User> placeOwners = _usersCollection.FindAs<User>(query);
            return placeOwners;
        }

        internal bool IsDbServerAvailabel
        {
            get
            {
                if (_dbServer == null)
                {
                    ConnectToDbServer();
                    return Initialize();
                }
                
                if(!PingDbServer())
                    return false;

                return true;
            }
        }

        private bool ConnectToDbServer()
        {
            try
            {
                var client = new MongoClient(ConnectionString);
                _dbServer = client.GetServer();
                _parkingDb = _dbServer.GetDatabase("GL_ParkingDB");
                _usersCollection = _parkingDb.GetCollection<User>("Users");
            }
            catch(Exception ex)
            {
                _logger.Exception(ex);
                return false;
            }

            return true;
        }

        private bool PingDbServer()
        {
            try
            {
                if (_dbServer != null)
                    _dbServer.Ping();
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.Exception(ex);
                return false;
            }

            return true;
        }

    }
}
