using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string About { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool Status { get; set; }

        public ICollection<Title> Titles { get; set; }
        public ICollection<Content> Contents  { get; set; }
    }
}
