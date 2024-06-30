using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace teste_tecnico_api.Domain.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; }
    }
}
