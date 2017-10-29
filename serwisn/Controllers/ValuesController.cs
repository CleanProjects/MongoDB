using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectDataBase;
using ChainOfResponsibility;
namespace serwisn.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult Index()
        {
            RedirectToRoute("api /[controller]");
            DB db = new DB();
    //       db.AddTool();
            View(db.GetTool());
          
            return View();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("Home")]
        public ViewResult p()
        {
            DB dB = new DB();
            dB.AddTool();
            View(dB.GetTool());
            ViewBag.myData = "Wgrano tabele";
          
           
            return View("Index");


        }
        [HttpPost]
        public ActionResult tlumaczenie(string w,string choosetranslate)
        {

          GetData  COF = new GetData();
            string result = COF.GetItems(w, choosetranslate);

            ViewBag.Translate = result;
            return View("Index");
        }
     
     
    }
    
    
}
