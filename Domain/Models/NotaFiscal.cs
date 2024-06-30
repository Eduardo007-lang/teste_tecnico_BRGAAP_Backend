using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste_tecnico_api.Domain.Models
{
    public class NotaFiscal
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("NumeroNota")]
        public int NumeroNota { get; set; }

        [BsonElement("Valor")]
        public double Valor { get; set; }

        [BsonElement("Cliente")]
        public Cliente? Cliente { get; set; }

        [BsonElement("Fornecedor")]
        public Fornecedor? Fornecedor { get; set; }
    }
}
