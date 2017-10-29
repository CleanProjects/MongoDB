using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectDataBase
{
 public   class Tool
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string CodeTool { get; set; }

        public ICollection<ToolTranslate> Tanslate { get; set; }
    }
    public class ToolTranslate
    {
        public string PL { get; set; }
        public string EN { get; set; }
        public string SE { get; set; }
        public string ES { get; set; }
    }
}

