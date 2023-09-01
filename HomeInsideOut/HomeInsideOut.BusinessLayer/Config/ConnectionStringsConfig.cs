using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.BusinessLayer.Config
{
    public class ConnectionStringsConfig : IConfig
    {
        public static string SectionPath { get; set; } = "ConnectionStrings";
        public string DbConnectionString { get; set; }
    }
}
