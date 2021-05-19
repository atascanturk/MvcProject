using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Title : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}
