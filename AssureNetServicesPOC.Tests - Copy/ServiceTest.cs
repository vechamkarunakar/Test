using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssureNetServicesPOC;
using AssureNetServicesPOC.DAL;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AssureNetServicesPOC.Tests
{
    [TestClass]
    public class ServiceTest
    {
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string aadSecret = ConfigurationManager.AppSettings["ida:Secret"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        Uri redirectUri = new Uri(ConfigurationManager.AppSettings["ida:RedirectUri"]);
        private static string assureNetResourceId = ConfigurationManager.AppSettings["ResourceId"];
        private static string assureNetBaseAddress = ConfigurationManager.AppSettings["todo:TodoListBaseAddress"];


        private static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        private HttpClient httpClient = new HttpClient();
        private AuthenticationContext authContext = null;

        

        

        [TestMethod]
        public void Test_ReconDetails()
        {
            AuthenticationResult result = null;
            authContext = new AuthenticationContext(authority);

            List<string> strList = new List<string>();
            strList.Add("1010");
            strList.Add("1098");
            strList.Add("1190");

            string oDataQuery = GenerateODataURI("http://localhost:5647/ReconAccounts?", strList);

            oDataQuery = "http://vecham.fareast.corp.microsoft.com:5647/ActiveUsers";

            oDataQuery = "http://localhost:5647/ReconDetails";

            oDataQuery = @"http://localhost:5647/ReconDetails/AssureNetServicesPOC.Models.DownloadFile?fileName='RF-53407-501904.xlsx'&ReconId=470735";

            try
            {
                ClientCredential cred = new ClientCredential(clientId, aadSecret);
                result = authContext.AcquireTokenAsync(assureNetResourceId, cred).Result;
            }
            catch (AdalException ex)
            {
                return;
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);



            HttpResponseMessage response = httpClient.GetAsync(oDataQuery).Result;
            string s = response.Content.ReadAsStringAsync().Result;

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, oDataQuery)
            //{
            //    Content = new StringContent("key=1")
            //};

            oDataQuery = "http://localhost:5647/ReconDetails/GetFile";

            HttpResponseMessage res = httpClient.PostAsync(oDataQuery, new StringContent("key=1")).Result;
            string s1 = res.Content.ReadAsStringAsync().Result;
            //var reconAccounts = JsonConvert.DeserializeObject<ODataResponse<RecondDetail>>(s);
        }

        

        private string GenerateODataURI(string baseAddress, List<string> companyCodes)
        {
            string strResult = string.Empty;
            string strFilter = string.Empty;

            int i = 0;

            var filter = companyCodes.Select(cc => string.Format("(CompanyCode eq '{0}')", cc));
            strFilter = string.Join(" or ", filter);

            strResult = string.Format("{0}$filter=({1})", baseAddress, strFilter);


            return strResult;
        }

        [TestMethod]
        public void TestUser()
        {
            string loginName = "fareast\\kavecham";
            string[] un = loginName.Split("\\".ToCharArray());

            UserInfo ui = Utils.GetNames().Where(s => s.FirstName.ToLower() == un[1].ToLower()).SingleOrDefault<UserInfo>();



        }
    }

    public class UserInfo
    {
        public string FirstName { get; set; }
        public bool isAdmin { get; set; }
    }


    public static class Utils
    {
        public static IQueryable<UserInfo> GetNames()
        {
            List<UserInfo> lst = new List<UserInfo>();
            lst.Add(new UserInfo() { FirstName = "kavecham", isAdmin = true });
            lst.Add(new UserInfo() { FirstName = "somename", isAdmin = false });
            return lst.AsQueryable();
        }
    }

    internal class ODataResponse<T>
    {
        public List<T> Value { get; set; }
    }

    public class ReconAccount
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDesc { get; set; }
        public string Status { get; set; }
        public string CompanyCode { get; set; }
        public DateTime FiscalMonth { get; set; }
        public Decimal EndingBalance { get; set; }
        public string Reconciler { get; set; }
        public string Reviewer { get; set; }
        public string Approver { get; set; }
        public string Attachment { get; set; }
    }


    public class ContextData
    {
        public string UserAlias { get; set; }
        public string AppID { get; set; }
        public string TopicID { get; set; }
        public string OtherData { get; set; }
    }

}

