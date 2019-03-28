using GraphQL_SimpleTalk.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_SimpleTalk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public AuthorsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(_blogService.GetAllAuthors());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return new ObjectResult(_blogService.GetAuthorById(id));
        }

        [HttpGet("{id}/posts")]
        public IActionResult GetPostsByAuthor(int id)
        {
            return new ObjectResult(_blogService.GetPostsByAuthor(id));
        }

        [HttpGet("{id}/socials")]
        public IActionResult GetSocialsByAuthor(int id)
        {
            return new ObjectResult(_blogService.GetSNsByAuthor(id));
        }
    }
}
