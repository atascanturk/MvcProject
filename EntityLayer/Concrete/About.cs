using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1000)]
        public string Details1 { get; set; }

        [StringLength(1000)]
        public string Details2 { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string ImagePath2 { get; set; }
    }
}
