using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace _35_APIs
{
    public class MP
    {
        string NameFullTitle;
        string Party;

        public MP(string nameFullTitle, string party)
        {
            NameFullTitle = nameFullTitle;
            Party = party;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {NameFullTitle} Party: {Party}");
        }
    }
}
