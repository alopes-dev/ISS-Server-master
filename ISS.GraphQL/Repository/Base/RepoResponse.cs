using System.Collections.Generic;

namespace ISS.GraphQL.Repository
{
    public class RepoResponse<T> where T : class
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
