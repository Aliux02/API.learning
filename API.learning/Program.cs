using API.learning.Models;
using Newtonsoft.Json;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
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

            var httpClient = new HttpClient();

            var httpResponce = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (httpResponce.IsSuccessStatusCode)
            {
                var contentString = await httpResponce.Content.ReadAsStringAsync();

                var posts = JsonConvert.DeserializeObject<List<Post>>(contentString);

                // filtered with linq
                var filteredPosts = posts.Where(posts => posts.Id <= 30);

                // view list with foreach 
                //foreach (var post in filteredPosts)
                //{
                //    Console.WriteLine($"Post Id is: {post.Id} and post title is: {post.Title}");
                //}

                // view list with linq
                posts.ForEach(filteredPosts => Console.WriteLine($"Post Id is: {posts.Id} and post title is: {posts.Title}"));

            }


            // Another Endpoint


            var httpClientSecondEndpoint = new HttpClient();

            var httpResponceSecondEndpoint = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (httpResponceSecondEndpoint.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var contentStringSecondEndpoint = await httpResponceSecondEndpoint.Content.ReadAsStringAsync();

                var users = JsonConvert.DeserializeObject<List<User>>(contentStringSecondEndpoint);

                // filter with linq
                var SamanthaUserId = users.Where(u => u.Username == "Samantha").Select(u => u.Id).FirstOrDefault();

                var SamanthaUserId2 = users.FirstOrDefault(u => u.Username == "Samantha");

                var FilteredEmailUsers = users.Where(u => u.Email == "Shanna@melissa.tv");

                var FilteredEmailUsersByEnd = users.Where(u => u.Email.Contains("net"));

                foreach (var user in FilteredEmailUsersByEnd)
                {
                    Console.WriteLine($"User name: {user.Username}, user email: {user.Email}");
                }

            }


            // From page without API; instal scrapysharp from nugets packeges

            ScrapingBrowser browser = new ScrapingBrowser();

            WebPage homePage = browser.NavigateToPage(new Uri("https://www.cvonline.lt/lt/search?limit=20&offset=0&categories%5B0%5D=INFORMATION_TECHNOLOGY&towns%5B0%5D=540&isHourlySalary=false&isRemoteWork=false"));

            var html = homePage.Html;

            var nodes = html.CssSelect(".jsx-3752991021 a span");

            var professionNames = nodes.Where(n => n.InnerText.Contains(".NET")).Select(n => n.InnerText);


        }
    }
}
