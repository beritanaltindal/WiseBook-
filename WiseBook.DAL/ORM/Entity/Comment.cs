using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseBook.DAL.ORM.Entity
{
    public class Comment : BaseEntity
    {
        [MaxLength(200)]
        public string Content { get; set; }

        [ForeignKey("Story")]
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }


        public int Commentator { get; set; }
    }
}
