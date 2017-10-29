using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectDataBase
{
    public class DB
    {

        public List<Tool> GetTool()
        {
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");


            return collection.AsQueryable<Tool>().ToList();

        }

        public static string FindSpecificTranslate(string code, string language)
        {
            string result = null;

            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");

            var tools = (from t in collection.AsQueryable<Tool>() where t.CodeTool == code select t);

            if (!tools.Any())
            {
                return null;
            }

            Tool tool = tools.First();


            foreach (ToolTranslate toolTr in tool.Tanslate)

            {

                switch (language)
                {
                    case ("Polski"):
                        return toolTr.PL;
                        
                    case ("Angielski"):
                        return toolTr.EN;
                        
                    case ("Szwedzki"):
                        return toolTr.SE;
                   

                }
            }
            return null;
        }

        public static string FindTranslateEN(string code)
        {

            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");

            var tools = (from t in collection.AsQueryable<Tool>() where t.CodeTool == code select t);
            if (!tools.Any())
            {
                return null;
            }

            Tool tool = tools.First();

            var result = (from b in tool.Tanslate where b.EN != null select b.EN);

            if (result.Any())
            {
                return result.First();
            }
            return null;

        }

        public static string FindTranslatePL(string code)
        {

            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");

            var tools = (from t in collection.AsQueryable<Tool>() where t.CodeTool == code select t);
            if (!tools.Any())
            {
                return null;
            }

            Tool tool = tools.First();

            var result = (from b in tool.Tanslate where b.PL != null select b.PL);

            if (result.Any())
            {
                return result.First();
            }
            return null;
        }

        public static string FindAnyTranslate(string code)
        {
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");

            var tools = (from t in collection.AsQueryable<Tool>() where t.CodeTool == code select t);

            if (!tools.Any())
            {
                return null;
            }

            Tool tool = tools.First();

            
            foreach (ToolTranslate toolTr in tool.Tanslate)

            {
               
                if (toolTr.ES != null)
                    return toolTr.ES;
                if (toolTr.SE != null)
                    return toolTr.SE;
            }

            return null;

        }

    


        public void AddTool()
        {
              var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var datebase = client.GetDatabase("Slownik");
            var collection = datebase.GetCollection<Tool>("Narzędzia");
            var filter = new BsonDocument();
            filter.Set("EN", "Hamer");

          Tool t1 = new Tool();
            t1.CodeTool = "001";
           
            ToolTranslate f = new ToolTranslate();

          

            ICollection<ToolTranslate> tt = new List<ToolTranslate>
                {
             new ToolTranslate() { EN="Hamer",PL = "Młotek" }
            };
            t1.Tanslate = tt;
            collection.InsertOne(t1);
            Tool t2 = new Tool();
            t2.CodeTool = "002";

            ToolTranslate f1 = new ToolTranslate();



            ICollection<ToolTranslate> tt2 = new List<ToolTranslate>
                {
             new ToolTranslate() { PL="śrubokrętr",EN = "screwdriver",SE="skruvmejsel" }
            };
            t2.Tanslate = tt2;
            collection.InsertOne(t2);

            Tool t3 = new Tool();
            t3.CodeTool = "003";

            ToolTranslate f2 = new ToolTranslate();



            ICollection<ToolTranslate> tt3= new List<ToolTranslate>
                {
             new ToolTranslate() { PL="Wiertarka" }
            };
            t3.Tanslate = tt3;
            collection.InsertOne(t3);


            Tool t4 = new Tool();
            t4.CodeTool = "004";

            ToolTranslate f3 = new ToolTranslate();



            ICollection<ToolTranslate> tt4 = new List<ToolTranslate>
                {
             new ToolTranslate() { ES="vicio" }
            };
            t4.Tanslate = tt4;
            collection.InsertOne(t4);

            var te = from t in collection.AsQueryable<Tool>() where t.Tanslate.Any(c => c.PL == "Młotek") select t;

            foreach (Tool t in te)
            {
                string name = t.CodeTool;
                int g = 0;

            }
           
        
        }

    }
}

