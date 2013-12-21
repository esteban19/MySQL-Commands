using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestDatabase
{
    class MySqlMainClass
    {
        static void Main(string[] args)
        {
            CmndCentral cmdcntrl = new CmndCentral();
            cmdcntrl.RunCommands();
        }
    }
}
