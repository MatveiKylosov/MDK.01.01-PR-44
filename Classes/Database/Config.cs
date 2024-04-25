using Microsoft.EntityFrameworkCore;
using System;

namespace TaskManager_Kylosov.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;" + "uid=root;" + "pwd=;" + "database=TaskManager;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
