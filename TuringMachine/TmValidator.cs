using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TmValidator
    {
        public TmValidator()
        { }
        public List<string> TmParser(string[] TM)
        {
            List<string> TmpStringList = new List<string>();
            foreach (string line in TM)
            {
                string templine = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '-' && line[i + 1] == '-')
                    {
                        break;
                    }
                    else if (line[i] == ';')
                    {
                        break;
                    }
                    else
                    {
                        templine += line[i];
                    }

                }
                if (templine != "")
                {
                    TmpStringList.Add(templine);
                }
            }
            return TmpStringList;
        } // End of Method
        public TuringMachine TMBuilder(string[] TM)
        {
            TuringMachine TempTM = new TuringMachine();
            TempTM.InputTape = Console.ReadLine();
            TempTM.InputTape += '_';

            TempTM.HeadPos = 0;

            foreach (string s in TM)
            {
                if (s.Contains("states:"))   //Checking and establishing States
                {
                    string Tstates = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { Tstates += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TempTM.States = Tstates.Split(',');
                }

                else if (s.Contains("start:"))   //Checking and establishing Start State
                {
                    string Tstartstates = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { Tstartstates += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TempTM.StartState = Tstartstates;
                }
                else if (s.Contains("accept:"))   //Checking and establishing Accept State
                {
                    string Tacceptstate = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { Tacceptstate += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TempTM.AcceptState = Tacceptstate;
                }
                else if (s.Contains("reject:"))   //Checking and establishing Reject State
                {
                    string Trejectstate = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { Trejectstate += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TempTM.RejectState = Trejectstate;
                }
                else if (s.Contains("tape-alpha:"))   //Checking and establishing tape-alpha States
                {
                    string TTapeAlpha = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { TTapeAlpha += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TTapeAlpha += ",_";
                    TempTM.TapeAlpha = TTapeAlpha.Split(',');
                }
                else if (s.Contains("alpha:"))   //Checking and establishing alpha States
                {
                    string TAlphastates = "";
                    bool startrecording = false;

                    for (int i = 0; i < s.Length; i++)
                    {


                        if (startrecording == true)
                        {
                            if (s[i] == '}' || s[i] == ' ')
                            {

                            }
                            else { TAlphastates += s[i]; }
                        }

                        if (s[i] == ':')
                        { startrecording = true; }


                    }
                    TAlphastates += ",_";
                    TempTM.Alpha = TAlphastates.Split(',');
                }
                else if (s.Contains("rwRt"))   //Checking and establishing Algorithm "READ - WRITE - RIGHT MOVE - TRANSITION"
                {
                    string TrwRtAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrwRtAlgo += s[i];
                        }
                    }
                    tempalgo = TrwRtAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[3][0], tempalgo[4]);


                    TempTM.AlgoList.Add(item);

                }
                else if (s.Contains("rwLt"))   //Checking and establishing Algorithm "READ - WRITE - LEFT MOVE - TRANSITION"
                {
                    string TrwLtAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrwLtAlgo += s[i];
                        }
                    }
                    tempalgo = TrwLtAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[3][0], tempalgo[4]);


                    TempTM.AlgoList.Add(item);

                }
                else if (s.Contains("rRl"))   //Checking and establishing Algorithm "READ - RIGHT MOVE - LOOP
                {
                    string TrRlAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrRlAlgo += s[i];
                        }
                    }
                    tempalgo = TrRlAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[2][0], tempalgo[1]);


                    TempTM.AlgoList.Add(item);

                }
                else if (s.Contains("rLl"))   //Checking and establishing Algorithm "READ - LEFT MOVE - LOOP 
                {
                    string TrLlAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrLlAlgo += s[i];
                        }
                    }
                    tempalgo = TrLlAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[2][0], tempalgo[1]);


                    TempTM.AlgoList.Add(item);

                }
                else if (s.Contains("rRt"))   //Checking and establishing Algorithm "READ - RIGHT MOVE - TRANSITION
                {
                    string TrRtAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrRtAlgo += s[i];
                        }
                    }
                    tempalgo = TrRtAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[2][0], tempalgo[3]);


                    TempTM.AlgoList.Add(item);

                }
                else if (s.Contains("rLt"))   //Checking and establishing Algorithm "READ - LEFT MOVE - TRANSITION
                {
                    string TrRtAlgo = "";
                    string[] tempalgo;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != ';')
                        {
                            TrRtAlgo += s[i];
                        }
                    }
                    tempalgo = TrRtAlgo.Split(' ');
                    Tuple<string, string, char, char, string> item = new Tuple<string, string, char, char, string>(tempalgo[0], tempalgo[1], tempalgo[2][0], tempalgo[2][0], tempalgo[3]);


                    TempTM.AlgoList.Add(item);

                }
                else
                {
                    Console.WriteLine("There is a invalid line in your turing machine, the following line can not be parsed:");
                    Console.WriteLine(s);
                    throw new Exception();
                }
            }

            return TempTM;
        } //end of Method
        public void TuringMachineValidator(TuringMachine TM)
        {
            //Checking Nulls
            if (TM.AcceptState == "" || TM.RejectState == "" || TM.StartState == "" || TM.States.Length == 0 || TM.Alpha.Length == 0 || TM.TapeAlpha.Length == 0 || TM.AlgoList.Count == 0)
            {
                Console.WriteLine("Part of your Tuple was Empty or Null ");
                throw new Exception();
            }
            // Checking Start State is in The Set of states
            bool startSvalid = false;
            bool acceptSvalid = false;
            bool rejectSvalid = false;
            foreach (string s in TM.States)
            {
                if (s == TM.StartState)
                    startSvalid = true;
                if (s == TM.RejectState)
                    rejectSvalid = true;
                if (s == TM.AcceptState)
                    acceptSvalid = true;

            }
            if (startSvalid == false || acceptSvalid == false || rejectSvalid == false)
            {
                Console.WriteLine("Your Start, Accept, or Reject State are not in you set of States");
                throw new Exception();
            }

            // Check input tape
            if (TM.InputTape == "")
            {
                Console.WriteLine("You did not enter a Input Tape!");
                throw new Exception();
            }

            foreach (char c in TM.InputTape)
            {
                bool inputvalid = false;
                foreach (string ac in TM.Alpha)
                {
                    if (c.ToString() == ac)
                    {
                        inputvalid = true;
                    }
                }
                if (inputvalid == false)
                {
                    Console.WriteLine("Invalid Input, Your Input is not in your alphabet");
                    throw new Exception();
                }
            }


            //Checking Algorithm Validity
            foreach (Tuple<string, string, char, char, string> T in TM.AlgoList)
            {
                bool CurrentStateValid = false;
                bool ReadCharValid = false;
                bool WriteCharValid = false;
                bool TransStateValid = false;
                foreach (string Cstate in TM.States) //Checking Current State Tuple is Valid Against States
                {
                    if (Cstate == T.Item2)
                    { CurrentStateValid = true; }
                }
                foreach (string Transtate in TM.States) //Checking Transition State Tuple is Valid Against States
                {
                    if (Transtate == T.Item5)
                    { TransStateValid = true; }
                }
                foreach (string RChar in TM.TapeAlpha) //Checking Readable Char is Valid against Tape-Alpha
                {
                    if (RChar == T.Item3.ToString())
                    { ReadCharValid = true; }
                }
                foreach (string WChar in TM.TapeAlpha) //Checking Writeable Char is Valid against Tape-Alpha
                {
                    if (WChar == T.Item4.ToString())
                    { WriteCharValid = true; }
                }
                if (CurrentStateValid == false || ReadCharValid == false || WriteCharValid == false || TransStateValid == false) //If Tuple Function Algorithm is invalid, Print Tuple but Continue
                {
                    Console.WriteLine(" The algorithm line {0} is invalid", T.ToString());
                    throw new Exception();
                }
            }
        } // End of Method
        public void TMProcessor(ref TuringMachine TM)
        {

            string CurrentState = TM.StartState; // Establishing Head Reader State which is the Start State


            PrintCurrentLine(TM, CurrentState);

            while (CurrentState != TM.AcceptState && CurrentState != TM.RejectState)
            {
                bool PerformOperand = false;
                bool FoundOperand = false;
                foreach (Tuple<string, string, char, char, string> AlgoToRun in TM.AlgoList) //Looking for Algorithm to run
                {

                    if (PerformOperand == false)
                    {
                        if (AlgoToRun.Item2 == CurrentState && AlgoToRun.Item3 == TM.InputTape[TM.HeadPos]) // Comparing Correct Algorithm
                        {
                            CurrentState = AlgoToRun.Item5; //Changing State; Changing to Same State if not changed
                            TM.InputTape = ChangeReadChar(TM.InputTape, AlgoToRun.Item4, TM.HeadPos); //Replacing Character to Tape at Reader Position; Writing Same State if not changed

                            if (AlgoToRun.Item1.Contains('L')) //Moving Head Based on Operand 
                            { TM.HeadPos--; }
                            else if (AlgoToRun.Item1.Contains('R'))
                            { TM.HeadPos++; }
                            else
                            {
                                Console.WriteLine("Your Reader Broke, oop!");
                                throw new Exception();
                            }
                            FoundOperand = true;
                            PerformOperand = true;

                        }
                    }
                    if (PerformOperand == true)
                        break;
                }

                if (FoundOperand == false)
                {
                    CurrentState = TM.RejectState;
                    
                }

                if (CurrentState == TM.AcceptState || CurrentState == TM.RejectState)
                {
                    if (CurrentState == TM.AcceptState)
                    {

                        Console.Write("Accepted: ");
                        PrintCurrentLine(TM, CurrentState);

    
                    }
                    else if (CurrentState == TM.RejectState)
                    {
                        Console.Write("Rejected: ");
                        PrintCurrentLine(TM, CurrentState);
                    }
                    else
                    {
                        Console.WriteLine("A huge mistake was made in processing the algorithm");
                        throw new Exception();

                    }
                    break;
                }

                PrintCurrentLine(TM, CurrentState);
                PerformOperand = false;
            }



        } //End of Method
        public void PrintCurrentLine(TuringMachine TM, string CurrentState)
        {
            StringBuilder PrintCurrent = new StringBuilder();
            bool HeadPrinted = false;
            for (int i = 0; i < (TM.InputTape.Length); i++) //Building Printable String without the end of tapes Underscore
            {
                
                if (i == TM.HeadPos)
                {
                    PrintCurrent.Append('[');
                    PrintCurrent.Append(CurrentState);
                    PrintCurrent.Append(']');
                    HeadPrinted = true;
                }

                if (TM.InputTape[i] == '_')
                { }
                else
                    PrintCurrent.Append(TM.InputTape[i]);
            }
            if (HeadPrinted == false)
            { PrintCurrent.Append('[' + CurrentState + ']'); }
            Console.WriteLine(PrintCurrent);
        } // End Of Method
        public string ChangeReadChar(string InputTape, char ChangeToChar, int AtPsotiion)
        {
            string TempString = "";

            for (int i = 0; i < InputTape.Length; i++)
            {
                if (i == AtPsotiion)
                { TempString += ChangeToChar; }
                else { TempString += InputTape[i]; }
            }

            return TempString;
        }
    } //end of Class
} // end of Namespace
