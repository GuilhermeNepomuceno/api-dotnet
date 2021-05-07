using API.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace API.Data
{
    public class MongoDB
    {
        public IMongoDatabase database { get; set; }

        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                database = client.GetDatabase(configuration["Database"]);
                MapClasses();
            }
            catch (System.Exception)
            {
                
                throw new MongoException("Failed to access the DataBase.");
            }
        }

        private void MapClasses()
        {
            var convetionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", convetionPack, t => true);

            if(!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(infectado =>
                    {
                        infectado.AutoMap();
                        infectado.SetIgnoreExtraElements(true);
                    }
                );
            }
        }
    }
}