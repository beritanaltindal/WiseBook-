using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WiseBook.Admin.UI.Models
{
    public class BaseDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class CategoryDTO : BaseDTO
    {
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }

    public class StoryDTO : BaseDTO
    {
     
    }

    public class UserDTO : BaseDTO
    {
        public string Lastname { get; set; }

        public string Email{ get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        //public bool IsDeleted { get; set; }
    }

    public class CommentDTO : BaseDTO
    {

    }
}