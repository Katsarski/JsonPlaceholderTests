using JsonPlaceholderTests.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonPlaceholderTests.Resources
{
    public class Users : BaseApi
    {

        public Users(string endpointUrl = "https://jsonplaceholder.typicode.com/users") : base(endpointUrl)
        {
        }

        public void GetUsers()
        {
            Get();
        }

        public int GetRandomUserId()
        {
            Get();
            List<UsersContract> usersResponse = JsonConvert.DeserializeObject<List<UsersContract>>(testContext.response.Content);
            int randomUserIdFromResponse = usersResponse[Helpers.GenerateRandomPositiveNumber(usersResponse.Count)].id;
            return randomUserIdFromResponse;
        }
    }
}
