using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace FinkiManEscape
{
    public class LevelsContext : DbContext
    {
        public DbSet<Levels> Levels { set; get; }
        public DbSet<Level> Level { set; get; }
    }
}
