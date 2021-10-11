using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Data;
using System.Configuration;
namespace MongoTuts.DBController
{
    public class MongoDBController
    {
        public dynamic DBList() {

            string ConnString = ConfigurationManager.AppSettings["MongoConn"].ToString();
            MongoClient dbClient = new MongoClient(ConnString);

            List<MongoDB.Bson.BsonDocument> dbList = dbClient.ListDatabases().ToList();

            return dbList;
        }
        public int Insert(MongoDB.Bson.BsonDocument bsonDocument, string collectionName) {
            try
            {
                string ConnString = ConfigurationManager.AppSettings["MongoConn"].ToString();
                MongoClient dbClient = new MongoClient(ConnString);
                var database = dbClient.GetDatabase("testDB");//DateBaseName

                var collection = database.GetCollection<MongoDB.Bson.BsonDocument>(collectionName);
                collection.InsertOne(bsonDocument);
                return 1;
            }
            catch (Exception e) { throw e; }
            return -99;

        }
    }
}