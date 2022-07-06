using ProjectForVendista.Models;
using ProjectForVendista.Models.Auth;
using ProjectForVendista.Models.Auth.Context;
using ProjectForVendista.Models.ModelsCommands;
using ProjectForVendista.Models.ModelsTerminals;
using ProjectForVendista.Models.ModelsTable.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectForVendista.Models.ModelsTable;

namespace ProjectForVendista.Controllers
{
    [Authorize]
    public class CommandController : Controller
    {
        private static ValuesController values = new ValuesController();
        private static UserContext uContext = new UserContext();
        private static string commandName;
        private static string token;
        private BodyCommand GetCommand(string commandName,string token) 
        {
            return values.GetCommands(token).FirstOrDefault(c => c.name == commandName);
        }
        public Repository HandleData(string commandName, string token)
        {
            Repository repos = new Repository(token, values.GetCommands(token), values.GetTerminals(token), new HistoryContext());
            repos.SetLastCommand(repos.Commands.FirstOrDefault(c => c.name == commandName));
            return repos;
        }
        public Repository UnboxingUser(string name, string pass)
        {
            var token = values.GetTokenSwagger(name, pass);
            Repository modelRepos = new Repository(token, values.GetCommands(token), values.GetTerminals(token), new HistoryContext());
            return modelRepos;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var repository = UnboxingUser(User.Identity.Name,
                uContext.users.FirstOrDefault(u => u.Name == User.Identity.Name).Password);
            repository.reverseHistory = new List<History>();
            return View(repository);
        }
        [HttpPost]
        public ActionResult Index(string value)
        {
            var tempArray = value.Split(',');
            commandName = tempArray[0];
            token = tempArray[1];
            return View(HandleData(commandName, token));
        }
        private void BuildMultyCommand(MultyCommandTerminal mct , string commandParameterName1, string commandParameterName2, string commandParameterName3)
        {
            BodyCommand command = GetCommand(commandName, token);
            mct.command_id = command.id;
            mct.parameter1 = Convert.ToInt32(commandParameterName1);
            mct.parameter2 = Convert.ToInt32(commandParameterName2);
            mct.parameter3 = Convert.ToInt32(commandParameterName3);
        }
        private void BuildHistory(History history,CommandTerminal answer)
        {
            history.DateTime = DateTime.Now;
            history.Command = commandName;
            history.Param1 = answer.parameter1.ToString();
            history.Param2 = answer.parameter2.ToString();
            history.Param3 = answer.parameter3.ToString();
            history.Status = answer.state_name;
        }
        public ActionResult SendDataDB(string userIdTerminals, string Param1, string Param2, string Param3)
        {
            using(HistoryContext db = new HistoryContext()) 
            {
                MultyCommandTerminal mct = new MultyCommandTerminal();
                BuildMultyCommand(mct, Param1, Param2, Param3);
                CommandTerminal answer = values.SendCommandTerminals(Convert.ToInt32(userIdTerminals), token, mct);
                
                History history = new History();
                BuildHistory(history, answer);
                db.histories.Add(history);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}