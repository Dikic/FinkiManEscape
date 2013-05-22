using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace FinkiManEscape
{
    public class SaveLevelsContext:DbContext
    {
        public DbSet<Level> Level { set; get; }
        public DbSet<Levels> Levels { get; set; }
    }
}
