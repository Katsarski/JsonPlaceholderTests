using JsonPlaceholderTests.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JsonPlaceholderTests.Resources
{
    public class Posts : BaseApi
    {

        public Posts(string endpointUrl = "https://jsonplaceholder.typicode.com/posts") : base(endpointUrl)
        {
        }

        public void GetPosts()
        {
            Get();
        }

        public void CreatetPost(string title, string body, int userId)
        {
            var requestPayload = new JObject(
                     new JProperty("title", title),
                         new JProperty("body", body),
                         new JProperty("userId", userId));
            Post(JsonConvert.SerializeObject(requestPayload));
        }

        public IEnumerable<PostsContract> GetPostsFromUser(int userId)
        {
            List<PostsContract> postsResponse = JsonConvert.DeserializeObject<List<PostsContract>>(testContext.response.Content);
            var postsFromSpecificUser = postsResponse.Where(x => x.userId == userId);
            return postsFromSpecificUser;
        }
    }
}
