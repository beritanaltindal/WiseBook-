using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseBook.DAL.ORM.Entity
{
    public class Story : BaseEntity
    {
        [MaxLength(30000)]
        public string Content { get; set; }
        [MaxLength(400)]
        public string Title { get; set; }

        [ForeignKey("User")]
        public int Author { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
