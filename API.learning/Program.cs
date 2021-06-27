using API.learning.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.learning
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //var httpClient = new HttpClient();

            //var httpResponce = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            //if (httpResponce.IsSuccessStatusCode)
            //{
            //    var contentString = await httpResponce.Content.ReadAsStringAsync();

            //    var posts = JsonConvert.DeserializeObject<List<Post>>(contentString);

            //    // filtered with linq
            //    var filteredPosts = posts.Where(posts => posts.Id <= 30);

            //    // view list with foreach 
            //    //foreach (var post in filteredPosts)
            //    //{
            //    //    Console.WriteLine($"Post Id is: {post.Id} and post title is: {post.Title}");
            //    //}

            //    // view list with linq
            //    posts.ForEach(posts => Console.WriteLine($"Post Id is: {posts.Id} and post title is: {posts.Title}"));

            //}

            var httpClient = new HttpClient();

            var httpResponce = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (httpResponce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentString = await httpResponce.Content.ReadAsStringAsync();

                var users = JsonConvert.DeserializeObject<List<User>>(contentString);

                var SamanthaUserId = users.Where(u => u.Username == "Samantha").Select(u => u.Id).FirstOrDefault();
            }

        }
    }
}
