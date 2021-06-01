using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string From { get; set; }
        [StringLength(50)]
        public string To { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(100)]
        public string Content { get; set; }
        public DateTime Date { get; set; }


    }
}
