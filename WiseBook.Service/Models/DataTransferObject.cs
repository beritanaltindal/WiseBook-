using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WiseBook.Service.Models
{
    //Bir servis kullanıyorsak gerek güvenlik gerekse performans anlamında bir data transfer objesi kullanmalıyız.Transfer objesi üzerinden bunları dışarıya açacağız.
  
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

        }

        public class CommentDTO : BaseDTO
        {

        }
   
}