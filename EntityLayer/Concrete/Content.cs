using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;

        public int TitleId { get; set; }
        public virtual Title Title { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
