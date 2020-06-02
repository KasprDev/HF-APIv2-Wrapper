
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HFApi.Dtos;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using HFApi.Exceptions;

namespace HF_API_Wrapper
{
    class HFApi
    {
        private string ClientID { get; set; }
        private string SecretKey { get; set; }
        public string AccessToken { get; set; }
        private string URL = "https://hackforums.net/api/v2/";

        public HFApi(string clientID, string secretKey)
        {
            ClientID = clientID;
            SecretKey = secretKey;
        }

        public string AuthorizeURL()
        {
            return "https://hackforums.net/authorize?response_type=code&client_id=" + ClientID;
        }

        public async Task<string> SendPost(string path, NameValueCollection data)
        {
            WebClient client = new WebClient();
            client.Headers.Clear();

            if (AccessToken != null)
                client.Headers.Add("Authorization", "Bearer " + AccessToken);

            var response = await client.UploadValuesTaskAsync(new Uri(URL + path), "POST", data);

            string responseString = Encoding.ASCII.GetString(response);

            return responseString;
        }


        /// <summary>
        /// Generate an access token using the code returned from HF.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<HFAuthDto> GetAccessTokenAsync(string code)
        {
            var postParams = new NameValueCollection();
            postParams.Add("grant_type", "authorization_code");
            postParams.Add("client_id", ClientID);
            postParams.Add("client_secret", SecretKey);
            postParams.Add("code", code);
            
            var response = await SendPost("authorize", postParams);

            Console.WriteLine(response);

            if (string.IsNullOrEmpty(response))
                return null;
            else
            {
                var authResponse = JsonConvert.DeserializeObject<HFAuthDto>(response);

                AccessToken = authResponse.AccessToken;

                return authResponse;
            }
        }

        /// <summary>
        /// Create a thread in a specific forum.
        /// </summary>
        /// <param name="forumID">The forum ID where we want to post our thread.</param>
        /// <param name="subject">The subject of our thread.</param>
        /// <param name="message">The message we want in our thread.</param>
        /// <returns></returns>
        public async Task<HFThreadDto> CreateThreadAsync(int forumID, string subject, string message)
        {
            var postParams = new NameValueCollection();
            postParams.Add("asks", JsonConvert.SerializeObject(new
            {
                threads = new
                {
                    _fid = forumID,
                    _subject = subject,
                    _message = message
                }
            }));

            Console.WriteLine(JsonConvert.SerializeObject(new
            {
                threads = new
                {
                    _fid = forumID,
                    _subject = subject,
                    _message = message
                }
            }));


            var response = await SendPost("write", postParams);
            var responseDto = JsonConvert.DeserializeObject<HFThreadResultDto>(response);

            return responseDto.Threads.FirstOrDefault();
        }

        /// <summary>
        /// Get information on a specified thread.
        /// </summary>
        /// <param name="threadID">The thread ID of the thread we want to look up.</param>
        /// <returns></returns>
        public async Task<HFThreadDto> GetThreadAsync(long threadID)
        {
            var postParams = new NameValueCollection();
            postParams.Add("asks", JsonConvert.SerializeObject(new
            {
                threads = new
                {
                    _tid = threadID,
                    tid = true,
                    subject = true,
                    dateline = true,
                    firstpost = new
                    { 
                        pid = true,
                        message = true,
                        author = new
                        { 
                            uid = true,
                            username = true
                        }
                    }
                }
            }));

            var response = await SendPost("read", postParams);

            var threadsArray = JsonConvert.DeserializeObject<HFThreadResultDto>(response);

            return threadsArray.Threads.FirstOrDefault();
        }

        /// <summary>
        /// Get information on a post on a thread.
        /// </summary>
        /// <param name="postID">The post ID we are looking up.</param>
        /// <returns></returns>
        public async Task<HFPostDto> GetThreadPostAsync(long postID)
        {
            var postParams = new NameValueCollection();
            postParams.Add("asks", JsonConvert.SerializeObject(new
            {
                posts = new
                {
                    _pid = postID,
                    pid = true,
                    tid = true,
                    uid = true,
                    fid = true,
                    dateline = true,
                    message = true,
                    subject = true,
                    edituid = true,
                    edittime = true,
                    editreason = true,
                    author = true
                }
            }));

            var response = await SendPost("read", postParams);

            var postsArray = JsonConvert.DeserializeObject<HFPostResultDto>(response);

            return postsArray.Posts.FirstOrDefault();
        }

        /// <summary>
        /// Get a user's profile via their User ID.
        /// </summary>
        /// <param name="userID">The User ID of the profile we want to look up.</param>
        /// <returns></returns>
        public async Task<HFUserDto> GetUserProfileAsync(long userID)
        {
            var postParams = new NameValueCollection();
            postParams.Add("asks", JsonConvert.SerializeObject(new
            {
                users = new
                {
                    _uid = userID,
                    uid = true,
                    username = true,
                    usergroup = true,
                    displaygroup = true,
                    additionalgroups = true,
                    postnum = true,
                    awards = true,
                    myps = true,
                    threadnum = true,
                    avatar = true,
                    avatardimensions = true,
                    avatartype = true,
                    lastvisit = true,
                    usertitle = true,
                    website = true,
                    timeonline = true,
                    reputation = true,
                    referrals = true
                }
            }));

            var response = await SendPost("read", postParams);

            return JsonConvert.DeserializeObject<HFUserDto>(response);
        }

        /// <summary>
        /// Create a post on the specified thread.
        /// </summary>
        /// <param name="threadID">The thread ID you want to post on.</param>
        /// <param name="text">The text you want for your post.</param>
        /// <returns></returns>
        public async Task<HFPostResultDto> CreatePostAsync(long threadID, string text)
        {
            var postParams = new NameValueCollection();
            postParams.Add("asks", JsonConvert.SerializeObject(new
            {
                posts = new
                {
                    _tid = threadID,
                    _message = text
                }
            }));

            var response = await SendPost("write", postParams);

            return JsonConvert.DeserializeObject<HFPostResultDto>(response);
        }
    }
}
