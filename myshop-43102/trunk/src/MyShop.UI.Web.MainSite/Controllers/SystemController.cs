using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using MyShop.UI.Web.MainSite.Core;

namespace MyShop.UI.Web.MainSite.Controllers
{
    public class SystemController : MyShopController
    {
        public ActionResult Log()
        {
            string logFileName = Server.MapPath("/") + "log.txt";
            var lines = GetLogLines(logFileName);

            return View(lines);
        }

        public ActionResult EventLog()
        {
            string logFileName = Server.MapPath("/") + "events.txt";
            var lines = GetLogLines(logFileName);

            return View(lines);
        }

        private static IEnumerable<String> GetLogLines(string logFileName)
        {
            var buffer = new List<String>();
            if (System.IO.File.Exists(logFileName))
            {
                using (var reader = new StreamReader(System.IO.File.Open(logFileName,
                                                     FileMode.Open, FileAccess.Read,
                                                     FileShare.ReadWrite)))
                {
                    String line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        buffer.Add(line);
                    }

                }
            }

            return buffer;
        }
    }
}
