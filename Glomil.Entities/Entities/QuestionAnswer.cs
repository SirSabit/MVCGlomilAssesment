using Glomil.Core.Repositories;
using Glomil.Entities.Entities.BaseEntityFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.Entities.Entities
{
    public class QuestionAnswer:BaseEntityClass,IEntity
    {
        public string Question { get; set; }

        public string Answer { get; set; }

        public int UserId { get; set; }
        
        //Nav
        public virtual Users User { get; set; }

    }
}
