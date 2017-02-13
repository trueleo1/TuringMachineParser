using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TuringMachine
    {
        public TuringMachine()
        {

        }
        public string[] States { get; set; }
        public string StartState { get; set; }

        public string AcceptState { get; set;}
        public string RejectState { get; set; }
        
        public string[] Alpha { get; set; }
        public string[] TapeAlpha { get; set; }
        public string InputTape { get; set; }

        public int HeadPos { get; set; }

        public List<Tuple<string, string, char, char, string>> AlgoList = new List<Tuple<string, string, char, char, string>>();// List of algorithm operands, (operand, currentstate, read char, write char, Transition state
    }
}
