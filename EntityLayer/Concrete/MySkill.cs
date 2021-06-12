using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MySkill :IEntity
    {
        public int Id { get; set; }
        public string Skill { get; set; }
        public int Level { get; set; }
        
    }
}
