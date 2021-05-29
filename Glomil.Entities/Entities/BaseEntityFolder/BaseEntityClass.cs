using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.Entities.Entities.BaseEntityFolder
{
    public abstract class BaseEntityClass
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime? UpdatedTime { get; set; }
    }
}
