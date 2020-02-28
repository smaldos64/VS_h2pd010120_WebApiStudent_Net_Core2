using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public virtual DbSet<LogData> LogDatas { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
    }
}
