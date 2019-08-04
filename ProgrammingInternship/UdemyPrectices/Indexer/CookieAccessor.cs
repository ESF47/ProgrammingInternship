using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Indexer
{
    class CookieAccessor
    {
        HttpCookie cookie = new HttpCookie();

        public void AccessUser()
        {
            //var a = cookie[0];
            cookie.data = new HttpCookie.Data("ASdf", "asdfasdf", "asdfas", 213);
            cookie["Username"] = "ESF47";
            cookie["Real Name"] = "Ali";
            cookie["Family Name"] = "Esfahanian";
            cookie["Age"] = "twenty Four";

            string userData = cookie["Username"] + " " + cookie["Real Name"] + " " + cookie["Family Name"] + " " + cookie["Age"];

            Console.WriteLine(userData);
        }
    }
}
