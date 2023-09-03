using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ProjectForVendista.Models.ModelsCommands;
using ProjectForVendista.Models.ModelsTerminals;
using System.Text;
using System.Web.Script.Serialization;

namespace ProjectForVendista.Controllers
{
    public class ValuesController : ApiController
    {

        #region Partner
        private string pLogin = "user2";
        private string pPassword = "password2";
        #endregion
        #region Client
        private string cLogin = "user1";
        private string cPassword = "password1";
        #endregion
        private string swagger = "http://178.57.218.210:398/";
        private string token = "";

        private WebResponse Request(string server, string method,string type)
        {
            WebRequest requset = WebRequest.Create(server + method);
            if (type == "POST") 
            {
                requset.Method = type;
                requset.ContentType = "application/x-www-form-urlencoded";
            }
            
            WebResponse response = requset.GetResponse();
            return response;
        }

        [Route("api/GetToken")]
        public string GetTokenSwagger(string login, string password)
        {
            var response = Request(swagger, $"token?login={login}&password={password}","GET");
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    dynamic jsonToken = JsonConvert.DeserializeObject(streamReader.ReadToEnd());
                    return jsonToken.token;
                }
            }
        }
        [Route("api/GetCommands")]
        [HttpGet]
        public List<BodyCommand> GetCommands(string token)
        {
            var response = Request(swagger, $"commands/types?token={token}","GET");
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    List<BodyCommand> commands = new List<BodyCommand>();
                    var json = streamReader.ReadToEnd();
                    Command command = JsonConvert.DeserializeObject<Command>(json);
                    foreach (var items in command.items)
                    {
                        commands.Add(items);
                    }
                    return commands;
                }
            }
        }
        [Route("api/GetTerminals")]
        [HttpGet]
        public List<BodyTerminal> GetTerminals(string token)
        {
            var response = Request(swagger, $"terminals?token={token}","GET");
            using(Stream stream = response.GetResponseStream())
            {
                using(StreamReader streamReader = new StreamReader(stream))
                {
                    List<BodyTerminal> terminals = new List<BodyTerminal>();
                    var json = streamReader.ReadToEnd();
                    foreach(var items in JsonConvert.DeserializeObject<Terminal>(json).items)
                    {
                        terminals.Add(items);
                    }
                    return terminals;
                }
            }
        }
        [Route("api/SendCommandTerminals/{idTerminal}/{token}")]
        [HttpPost]
        public CommandTerminal SendCommandTerminals(int idTerminal, string token, MultyCommandTerminal command)
        {
            var request = (HttpWebRequest)WebRequest.CreateHttp($"{swagger}terminals/{idTerminal}/commands?token={token}") as HttpWebRequest;
            var json = JsonConvert.SerializeObject(command);
            if (!string.IsNullOrEmpty(json)) 
            {
                request.ContentType = "application/json";
                request.Method = "POST";
                using(StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(json);
                    sw.Flush();
                    sw.Close();
                }
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    dynamic jsonCommand = JsonConvert.DeserializeObject(sr.ReadToEnd());
                    return JsonConvert.DeserializeObject<CommandTerminal>(JsonConvert.SerializeObject(jsonCommand.item));
                }
            }

        }
    }
}
