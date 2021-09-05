using JsonPlaceholderTests.Contracts;
using JsonPlaceholderTests.Resources;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JsonPlaceholderTests
{
    public class Tests
    {

        [Test]
        public void GetRandomUserPrintAddressVerifyCorrectEmailFormat()
        {
            Users users = new Users();
            Console.WriteLine("Executing GET ../users request");
            users.GetUsers();
            Assert.AreEqual(HttpStatusCode.OK, users.testContext.response.StatusCode, $"Expected response status code to be {HttpStatusCode.OK} but was {users.testContext.response.StatusCode}");
            Console.WriteLine("Verified that the response status code is 200 OK");
            Console.WriteLine("Deserializing users response to a .NET Class");
            List<UsersContract> usersResponse = JsonConvert.DeserializeObject<List<UsersContract>>(users.testContext.response.Content);

            Console.WriteLine("Extracting a \"random\" user id from the returned users");
            int testUserId = users.GetRandomUserId();
            List<UsersContract> userDetails = usersResponse.Where(x => x.id == testUserId).ToList();

            Console.WriteLine($"Printing address of user with ID {testUserId} " +
                $"\n Street: {userDetails.First().address.street}" +
                $"\n Suite: {userDetails.First().address.suite}" +
                $"\n City: {userDetails.First().address.city}" +
                $"\n ZipCode: {userDetails.First().address.zipcode}" +
                $"\n Geo.Lat: {userDetails.First().address.geo.lat}" +
                $"\n Geo.Lng: {userDetails.First().address.geo.lng}");
            Console.WriteLine("Verifying email address validity");
            Assert.IsTrue(Helpers.IsValidEmailAddress(userDetails.First().email), $"Expected {userDetails.First().email} to be a valid email but wasn't");
            Console.WriteLine("Email appears to be a valid email address");

        }

        [Test]
        public void GetUserPostsVerifyValidPostIdAndBody()
        {
            Console.WriteLine("Extracting a random user id to be used throughout the test");
            Users users = new Users();
            var testUserId = users.GetRandomUserId();

            Posts posts = new Posts();
            Console.WriteLine("Executing GET ../posts request");
            posts.GetPosts();
            Assert.AreEqual(HttpStatusCode.OK, posts.testContext.response.StatusCode, $"Expected response status code to be {HttpStatusCode.OK} but was {posts.testContext.response.StatusCode}");
            Console.WriteLine("Verified that the response status code is 200 OK");
            Console.WriteLine("Getting posts that belong to the test user");
            var postsFromSpecificUser = posts.GetPostsFromUser(testUserId);
            foreach (var post in postsFromSpecificUser)
            {
                Assert.Positive(post.id, "Expected post.Id to be a positive number but it wasn't");
                Assert.IsNotEmpty(post.title, "Expected post.title to not be an empty string but it was");
                Assert.IsNotEmpty(post.body, "Expected post.body to not be an empty string but it was");
            }
            Console.WriteLine("Verified that each post from our test user has its post id as a positive number");
            Console.WriteLine("Verified that each post from our test user has a non empty post title");
            Console.WriteLine("Verified that each post from our test user has a non empty post body");
        }

        [Test]
        public void CreatePostWithValidTitleAndBody()
        {
            Console.WriteLine("Extracting a random user id to be used throughout the test");
            Users users = new Users();
            var testUserId = users.GetRandomUserId();

            Posts posts = new Posts();

            Console.WriteLine("Generating a random post title and post body");
            var postTitle = Helpers.GenerateRandomString(5);
            var postBody = Helpers.GenerateRandomString(5);
            Console.WriteLine($"Generated post title: {postTitle} \n Generated post body: {postBody}");

            Console.WriteLine($"Creating a post with the above details for user with id: {testUserId}");
            posts.CreatetPost(postTitle, postBody, testUserId);
            Assert.AreEqual(HttpStatusCode.Created, posts.testContext.response.StatusCode, $"Expected response status code to be {HttpStatusCode.Created} but was {posts.testContext.response.StatusCode}");
            Console.WriteLine("Verified that the response status code is 201 Created");

        }
    }


}