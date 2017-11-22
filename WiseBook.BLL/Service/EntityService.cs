using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseBook.BLL.Repository.Entity;

namespace WiseBook.BLL.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _storyService = new StoryRepo();
            _categoryService = new CategoryRepo();
            _commentService = new CommentRepo();
            _userService = new UserRepo();
        }

        private UserRepo _userService;

        public UserRepo UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }
        private StoryRepo _storyService;

        public StoryRepo StoryService
        {
            get { return _storyService; }
            set { _storyService = value; }
        }

        private CategoryRepo _categoryService;

        public CategoryRepo CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }

        private CommentRepo _commentService;

        public CommentRepo CommentService
        {
            get { return _commentService; }
            set { _commentService = value; }
        }
    }

  
}
