using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Indexer
{
    class HttpCookie
    {
        public class Data
        {
            private string username;
            private string name;
            private string family;
            private int age;
            public Data(string _username, string _name, string _family, int _age)
            {
                username = _username;
                name = _name;
                family = _family;
                age = _age;
            }
        }
        public Data data;
        public Dictionary<string, string> usersData = new Dictionary<string, string>();

        public string this [string key]
        {
            get {return usersData[key] ; }
            set {usersData[key] = value; }
        }
    }
}
