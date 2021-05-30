using Glomil.Core.Repositories;
using Glomil.Entities.Entities.BaseEntityFolder;
using System;
using System.Collections.Generic;

namespace Glomil.Entities.Entities
{
    public class Users : BaseEntityClass, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        //Nav
        public virtual List<QuestionAnswer> Questions { get; set; }
    }
}
