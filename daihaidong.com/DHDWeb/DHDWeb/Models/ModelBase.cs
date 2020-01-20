using System;
using System.ComponentModel;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DHDWeb.Models
{
    public abstract class ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String ID { get; set; }

        public ModelBase()
        {


        }
    }
}
