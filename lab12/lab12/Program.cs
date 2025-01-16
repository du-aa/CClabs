using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LexicalAnalyzerConsole
{
    class Program
    {
        static List<List<String>> SymbolTable = new List<List<String>>();
        static ArrayList LineNumber;
        static ArrayList Variables;
        static ArrayList KeyWords;
        static ArrayList Constants;
        static Regex variable_Reg;
        static Regex constants_Reg;
        static Regex operators_Reg;
        static Regex special_Reg;
        static int lexemes_per_line;
        static int ST_index;

        static void Main(string[] args)
        {
            // Initialization (similar to the Form's constructor)
            string[] k_ = { "int", "float", "begin", "end", "print", "if", "else", "String", "char", "double" };
            ArrayList key = new ArrayList(k_);
            LineNumber = new ArrayList();
            Variables = new ArrayList();
            KeyWords = new ArrayList();
            Constants = new ArrayList();
            variable_Reg = new Regex(@"^[A-Za-z|_][A-Za-z|0-9]*$");
            constants_Reg = new Regex(@"^[0-9]+([.][0-9]+)?([e]([+|-])?[0-9]+)?$");
            operators_Reg = new Regex(@"^[-*+/><&&||=]$");
            special_Reg = new Regex(@"^[.,'\[\]{}();:?]$");


            Console.WriteLine("Enter your Tiny C program (end with an empty line):");
            string userInput = "";
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                userInput += line + "\n";
            }
            AnalyzeInput(userInput);
            DisplaySymbolTable();
            Console.ReadKey();
        }
        static void AnalyzeInput(string userInput)
        {
            List<String> keywordList = new List<String>
          {
             "int","float","while","main","if","else","new","String","char","double"
           };
            int row = 1;
            int count = 1;
            int line_num = 0;
            string[,] SymbolTableArray = new string[20, 6];
            List<String> varListinSymbolTable = new List<String>();

            ArrayList finalArray = new ArrayList();
            ArrayList finalArrayc = new ArrayList();
            ArrayList tempArray = new ArrayList();
            char[] charinput = userInput.ToCharArray();

            for (int itr = 0; itr < charinput.Length; itr++)
            {
                Match Match_Variable = variable_Reg.Match(charinput[itr] + "");
                Match Match_Constant = constants_Reg.Match(charinput[itr] + "");
                Match Match_Operator = operators_Reg.Match(charinput[itr] + "");
                Match Match_Special = special_Reg.Match(charinput[itr] + "");
                if (Match_Variable.Success || Match_Constant.Success || Match_Operator.Success || Match_Special.Success || charinput[itr].Equals(' '))
                {
                    tempArray.Add(charinput[itr]);
                }
                if (charinput[itr].Equals('\n'))
                {
                    if (tempArray.Count != 0)
                    {
                        string fin = "";
                        for (int j = 0; j < tempArray.Count; j++)
                        {
                            fin += tempArray[j];
                        }
                        finalArray.Add(fin);
                        tempArray.Clear();
                    }
                }
            }
            if (tempArray.Count != 0)
            {
                string fin = "";
                for (int j = 0; j < tempArray.Count; j++)
                {
                    fin += tempArray[j];
                }
                finalArray.Add(fin);
                tempArray.Clear();
            }
            Console.WriteLine("Tokens:");

            SymbolTable.Clear();

            for (int i = 0; i < finalArray.Count; i++)
            {
                string line = finalArray[i].ToString();
                char[] lineChar = line.ToCharArray();
                line_num++;

                for (int itr = 0; itr < lineChar.Length; itr++)
                {
                    Match Match_Variable = variable_Reg.Match(lineChar[itr] + "");
                    Match Match_Constant = constants_Reg.Match(lineChar[itr] + "");
                    Match Match_Operator = operators_Reg.Match(lineChar[itr] + "");
                    Match Match_Special = special_Reg.Match(lineChar[itr] + "");
                    if (Match_Variable.Success || Match_Constant.Success)
                    {
                        tempArray.Add(lineChar[itr]);
                    }
                    if (lineChar[itr].Equals(' '))
                    {
                        if (tempArray.Count != 0)
                        {
                            string fin = "";
                            for (int j = 0; j < tempArray.Count; j++)
                            {
                                fin += tempArray[j];
                            }
                            finalArrayc.Add(fin);
                            tempArray.Clear();
                        }
                    }
                    if (Match_Operator.Success || Match_Special.Success)
                    {
                        if (tempArray.Count != 0)
                        {
                            string fin = "";
                            for (int j = 0; j < tempArray.Count; j++)
                            {
                                fin += tempArray[j];
                            }
                            finalArrayc.Add(fin);
                            tempArray.Clear();
                        }
                        finalArrayc.Add(lineChar[itr]);
                    }
                }
                if (tempArray.Count != 0)
                {
                    string fina = "";
                    for (int k = 0; k < tempArray.Count; k++)
                    {
                        fina += tempArray[k];
                    }
                    finalArrayc.Add(fina);
                    tempArray.Clear();
                }

                for (int x = 0; x < finalArrayc.Count; x++)
                {
                    Match operators = operators_Reg.Match(finalArrayc[x].ToString());
                    Match variables = variable_Reg.Match(finalArrayc[x].ToString());
                    Match digits = constants_Reg.Match(finalArrayc[x].ToString());
                    Match punctuations = special_Reg.Match(finalArrayc[x].ToString());
                    if (operators.Success)
                    {
                        Console.Write("< op, " + finalArrayc[x].ToString() + "> ");
                    }
                    else if (digits.Success)
                    {
                        Console.Write("< digit, " + finalArrayc[x].ToString() + "> ");
                    }
                    else if (punctuations.Success)
                    {
                        Console.Write("< punc, " + finalArrayc[x].ToString() + "> ");
                    }
                    else if (variables.Success)
                    {
                        if (!keywordList.Contains(finalArrayc[x].ToString()))
                        {
                            Regex reg1 = new Regex(@"^(int|float|double)\s([A-Za-z|_][A-Za-z|0-9]{0,10})\s(=)\s([0-9]+([.][0-9]+)?([e][+|-]?[0-9]+)?)\s(;)$");
                            Match category1 = reg1.Match(line);
                            Regex reg2 = new Regex(@"^(String|char)\s([A-Za-z|_][A-Za-z|0-9]{0,10})\s(=)\s[']\s([A-Za-z|_][A-Za-z|0-9]{0,30})\s[']\s(;)$");
                            Match category2 = reg2.Match(line);

                            if (category1.Success)
                            {
                                SymbolTableArray[row, 1] = row.ToString();
                                SymbolTableArray[row, 2] = finalArrayc[x].ToString();
                                SymbolTableArray[row, 3] = finalArrayc[x - 1].ToString();
                                SymbolTableArray[row, 4] = finalArrayc[x + 2].ToString();
                                SymbolTableArray[row, 5] = line_num.ToString();
                                Console.Write("<var" + count + ", " + row + "> ");

                                row++;
                                count++;
                            }

                            else if (category2.Success)
                            {
                                if (!(finalArrayc[x - 1].ToString().Equals("'") && finalArrayc[x + 1].ToString().Equals("'")))
                                {
                                    SymbolTableArray[row, 1] = row.ToString();
                                    SymbolTableArray[row, 2] = finalArrayc[x].ToString();
                                    SymbolTableArray[row, 3] = finalArrayc[x - 1].ToString();
                                    SymbolTableArray[row, 4] = finalArrayc[x + 3].ToString();
                                    SymbolTableArray[row, 5] = line_num.ToString();
                                    Console.Write("<var" + count + ", " + row + "> ");

                                    row++;
                                    count++;
                                }
                                else
                                {
                                    Console.Write("<String" + count + ", " + finalArrayc[x].ToString() + "> ");
                                }

                            }
                            else
                            {
                                string ind = "Default";
                                string ty = "Default";
                                string val = "Default";
                                string lin = "Default";
                                for (int r = 1; r <= SymbolTableArray.GetLength(0); r++)
                                {
                                    if (SymbolTableArray[r, 2] != null && SymbolTableArray[r, 2].Equals(finalArrayc[x].ToString()))
                                    {
                                        ind = SymbolTableArray[r, 1];
                                        ty = SymbolTableArray[r, 3];
                                        val = SymbolTableArray[r, 4];
                                        lin = SymbolTableArray[r, 5];
                                        Console.Write("<var" + ind + ", " + ind + "> ");
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.Write("<keyword, " + finalArrayc[x].ToString() + "> ");
                        }
                    }

                }
                Console.WriteLine();
                finalArrayc.Clear();
            }
            SymbolTable.Clear();
            for (int r = 1; r < SymbolTableArray.GetLength(0); r++)
            {
                if (SymbolTableArray[r, 1] != null)
                {
                    List<string> entry = new List<string>();
                    entry.Add(SymbolTableArray[r, 1]);
                    entry.Add(SymbolTableArray[r, 2]);
                    entry.Add(SymbolTableArray[r, 3]);
                    entry.Add(SymbolTableArray[r, 4]);
                    entry.Add(SymbolTableArray[r, 5]);
                    SymbolTable.Add(entry);
                }
            }
        }

        static void DisplaySymbolTable()
        {
            Console.WriteLine("\nSymbol Table:");
            Console.WriteLine("Index\tVariable Name\tType\tValue\tLine#");
            foreach (var entry in SymbolTable)
            {
                foreach (var item in entry)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}

