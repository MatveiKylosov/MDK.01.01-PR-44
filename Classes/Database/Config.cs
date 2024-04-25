using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager_Kylosov.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;" + "uid=root;" + "pwd=root" + "database=TaskManager;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
