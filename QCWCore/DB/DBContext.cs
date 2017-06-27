using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWCore.DB
{
    public class DBContext : Database<DBContext>
    {
        public Table<dynamic> Frame_User { get; set; }
    }
}
