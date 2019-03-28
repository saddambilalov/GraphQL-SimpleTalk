using GraphQL_SimpleTalk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_SimpleTalk.Services
{
    public class BlogService : IBlogService
    {
        private readonly List<Author> _authors = new List<Author>();
        private readonly List<Post> _posts = new List<Post>();
        private readonly List<SocialNetwork> _sns = new List<SocialNetwork>();
        
        public BlogService()
        {
            Build();
        }

        private void Build()
        {
            var dinoEsposito = new Author
            {
                Id = 1,
                Name = "Dino Esposito",
                Bio = "Dino Esposito has authored more than 20 books and 1,000 articles in ...",
                ImgUrl = "https://secure.gravatar.com/avatar/ace158af8dfab0e682dcc70d965514e5?s=80&d=mm&r=g",
                ProfileUrl = "https://www.red-gate.com/simple-talk/author/dino-esposito/"
            };

            var lanceTalbert = new Author
            {
                Id = 2,
                Name = "Lance Talbert",
                Bio = "Lance Talbert is a budding game developer that has been learning to program since ...",
                ImgUrl = "https://www.red-gate.com/simple-talk/wp-content/uploads/2018/01/red-gate-bio-pic.jpg",
                ProfileUrl = "https://www.red-gate.com/simple-talk/author/lancetalbert/"
            };

            _authors.Add(dinoEsposito);
            _authors.Add(lanceTalbert);

            var comment1 = new Comment
            {
                Url = "https://#",
                Description = "Bla bla bla",
                Count = 1
            };

            var comment2 = new Comment
            {
                Url = "https://#",
                Description = "Bla bla bla",
                Count = 4
            };

            var rating1 = new Rating
            {
                Percent = 98,
                Count = 1
            };

            var rating2 = new Rating
            {
                Percent = 95,
                Count = 5
            };

            var formsInVanilla = new Post
            {
                Id = 1,
                Title = "Building Better HTML Forms in Vanilla-JS",
                Description = "Creating forms is one of the most basic skills for a web developer...",
                Date = DateTime.Today,
                Url = "https://www.red-gate.com/simple-talk/dotnet/net-development/building-better-html-forms-in-vanilla-js/",
                Author = dinoEsposito,
                Comments = new List<Comment> {comment1},
                Rating = rating1,
                Categories = new[] {".NET Development"}
            };

            var voiceCommands = new Post
            {
                Id = 2,
                Title = "Voice Commands in Unity",
                Description = "Today, we use voice in many ways. We can order groceries...",
                Date = DateTime.Today,
                Url = "https://www.red-gate.com/simple-talk/dotnet/c-programming/voice-commands-in-unity/",
                Author = lanceTalbert,
                Comments = new List<Comment> {comment2},
                Rating = rating2,
                Categories = new[] {"C# programming"}
            };

            _posts.Add(formsInVanilla);
            _posts.Add(voiceCommands);

            var sn1 = new SocialNetwork
            {
                Type = SNType.INSTAGRAM,
                Author = dinoEsposito,
                NickName = "@dino",
                Url = "https://#"
            };

            var sn2 = new SocialNetwork
            {
                Type = SNType.TWITTER,
                Author = dinoEsposito,
                NickName = "@dino",
                Url = "https://#"
            };

            _sns.Add(sn1);
            _sns.Add(sn2);
        }

        public IList<Author> GetAllAuthors()
        {
            return _authors;
        }

        public Author GetAuthorById(int id)
        {
            return _authors.FirstOrDefault(author => author.Id == id);
        }

        public IList<Post> GetPostsByAuthor(int id)
        {
            return _posts.Where(post => post.Author.Id == id).ToList();
        }

        public IList<SocialNetwork> GetSNsByAuthor(int id)
        {
            return _sns.Where(sn => sn.Author.Id == id).ToList();
        }
    }
}
