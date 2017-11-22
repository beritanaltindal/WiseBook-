using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseBook.DAL.ORM.Entity;

namespace WiseBook.BLL.Repository.Entity
{
    public class CategoryRepo : Base.BaseRepository<Category>
    {
        [Column("CategoryDescription")]
        public string Description { get; set; }
    }
}
