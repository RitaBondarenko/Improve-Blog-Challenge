using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class PostsController : Controller
    {

        protected readonly IPostsRepository postsRepo;
        protected readonly ICommentsRepository commentsRepo;

        public PostsController(IPostsRepository postsRepo, ICommentsRepository commentsRepo) 
        {
            this.postsRepo = postsRepo;
            this.commentsRepo = commentsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await postsRepo.GetAll<Post>();
            var vm = new PostsViewModel 
            {
                Posts = posts.ToList(),
            };

            foreach (var post in vm.Posts)
            {
                var comments = await commentsRepo.GetAll<Comment>(post.Id);
                post.NumberOfComments = comments.Count();
                post.Slug = GetSlug(post.Title);
            }

            return View(vm);
        }

        public async Task<IActionResult> Details(int id, string slug)
        {
            var post = await postsRepo.Get<Post>(id);
            var comments = await commentsRepo.GetAll<Comment>(id);
            var vm = new PostDetailsViewModel 
            {
                Post = post,
                Comments = comments.ToList(),
            };

            return View(vm);
        }

        public string GetSlug(string title)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var strippedTitle = rgx.Replace(title, "");

            var slug = strippedTitle.Replace(" ", "-");
            return slug;
        }
    }
}
