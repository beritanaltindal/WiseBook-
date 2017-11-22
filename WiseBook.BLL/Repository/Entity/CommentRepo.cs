using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseBook.DAL.ORM.Entity;

namespace WiseBook.BLL.Repository.Entity
{
    public class CommentRepo : Base.BaseRepository<Comment>
    {
        [MaxLength(200)]
        public string Content { get; set; }

        [ForeignKey("Story")]
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }

        
        public int Commentator { get; set; }
    }
}
