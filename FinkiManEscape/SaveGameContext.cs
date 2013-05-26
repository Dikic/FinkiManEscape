using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace FinkiManEscape
{
    class SaveGameContext:DbContext
    {
        public DbSet<Level> Level { set; get; }
        public DbSet<Levels> Levels { set; get; }
    }
}
