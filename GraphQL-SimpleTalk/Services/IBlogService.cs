using System.Collections.Generic;
using GraphQL_SimpleTalk.Entities;

namespace GraphQL_SimpleTalk.Services
{
    public interface IBlogService
    {
        IList<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        IList<Post> GetPostsByAuthor(int id);
        IList<SocialNetwork> GetSNsByAuthor(int id);
    }
}