using ProjectForVendista.Models.ModelsCommands;
using ProjectForVendista.Models.ModelsTerminals;
using ProjectForVendista.Models.ModelsTable.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectForVendista.Models.ModelsTable;

namespace ProjectForVendista.Models
{
    public class Repository
    {
        public string Token { get; set; }
        public List<BodyCommand> Commands { get; set; }
        public BodyCommand command;
        public List<BodyTerminal> Terminals { get; set; }
        public HistoryContext History { get; set; }
        public List<History> reverseHistory { get; set; }
        public Repository(string token, List<BodyCommand> commands, List<BodyTerminal> terminals, HistoryContext history) 
        {
            Token = token;
            Commands = commands;
            Terminals = terminals;
            History = history;
        }
        public Repository(string token, List<BodyCommand> commands, List<BodyTerminal> terminals)
        {
            Token = token;
            Commands = commands;
            Terminals = terminals;
        }
        public void SetLastCommand(BodyCommand command)
        {
            this.command = command;
        }
    }
}