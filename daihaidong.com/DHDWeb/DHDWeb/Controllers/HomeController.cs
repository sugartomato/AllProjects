using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DHDWeb.Models;

using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DHDWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public String Insert()
        {
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            for(Int32 i = 0;i<100;i++)
            {
                Models.SoftwareModel model = new SoftwareModel()
                {
                    Name = "测试数据" + i,
                    Author = "测试作者" + i
                };
                DataAdapter.MongoDBHelper<Models.SoftwareModel>.Insert(model);
                //DataAdapter.MongoDBHelper<Models.ModelBase.Insert(model);
                //System.Threading.Thread.Sleep(1000);
            }
            sw.Stop();
            return "添加完成，耗时：" + sw.ElapsedMilliseconds.ToString();
        }

        public String All()
        {

            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            StringBuilder sb = new StringBuilder();
            List<Models.SoftwareModel> list = DataAdapter.MongoDBHelper<Models.SoftwareModel>.GetAll();
            if(list != null && list.Count > 0)
            { 
                foreach(var model in list)
                {
                    sb.AppendLine($"{model.ID},{model.Name}");
                }
            }
            sw.Stop();
            sb.AppendLine("耗时：" + sw.ElapsedMilliseconds.ToString());
            return sb.ToString();
        }

        public String Clear()
        {
            Boolean result = DataAdapter.MongoDBHelper<Models.SoftwareModel>.Clear();
            return result.ToString();
        }

        public String First()
        {

            FindOptions o = new FindOptions();
            //new FilterDefinitionBuilder<Models.SoftwareModel>().
            var filter = "{Name:/1/}";
            Models.SoftwareModel model = DataAdapter.MongoDBHelper<Models.SoftwareModel>.GetFirst(filter, o);
            return $"{model.Name}, {model.Author}";



        }

        public String Update()
        {
            var update = Builders<Models.SoftwareModel>.Update.Set(x => x.Name, "修改");
            var filter = Builders<Models.SoftwareModel>.Filter.Regex(x => x.Name, "88");
            Boolean result = DataAdapter.MongoDBHelper<Models.SoftwareModel>.Update(update, filter);
            return result.ToString();
        }
    }
}
