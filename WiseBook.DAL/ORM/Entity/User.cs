using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseBook.DAL.ORM.Entity
{
    public class User : BaseEntity
    {
        [MaxLength(30)]
        public string Lastname { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Role { get; set; }
    }
}
