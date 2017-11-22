using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseBook.DAL.ORM.Entity
{
    public class Category : BaseEntity
    {
        [Column("CategoryDescription")]
        public string Description { get; set; }
    }
}
