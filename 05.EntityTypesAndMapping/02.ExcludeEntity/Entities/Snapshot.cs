using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //[NotMapped]
    public class Snapshot
    {
        public DateTime LoadedAt => DateTime.Now;
        public string Version => new Guid().ToString().Substring(0, 8);
    }
}
