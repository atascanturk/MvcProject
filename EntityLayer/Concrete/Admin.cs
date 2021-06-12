using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        
        public byte[] PasswordSalt { get; set; }

       
        public byte[] PasswordHash { get; set; }

        [StringLength(1)]
        public string Role { get; set; } = "B";

    }
}
