using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCParser
{
    class Program
    {
        // Symbol Table to store variable types
        static Dictionary<string, string> symbolTable = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            // 1. Define the SLR(1) Parsing Table (as a Dictionary) - same as before

            var parsingTable = new Dictionary<(string, string), string>()
            {
             { ("I0", "int"), "s5" },    { ("I0", "float"), "s6" },  {("I0", "program"), "1"},
                {("I0", "declarations"), "2" }, {("I0", "declaration"), "3"}, {("I0", "type"), "4"},
              { ("I1", "$"), "acc" },
                {("I2", "int"), "s5"},   { ("I2", "float"), "s6" },  { ("I2", "id"), "s11" },   {("I2", "statements"), "7"}, {("I2","statement"),"8"},
                 {("I3", "int"), "s5"}, {("I3", "float"), "s6"}, {("I3", "declarations"), "9"},{("I3","declaration"),"3"}, {("I3", "type"),"4"},
                {("I4", "id"),"s10"},
                 {("I5", null), "r4"},{("I6", null), "r4"},
                 {("I7", "$"), "r1"},
                {("I8","id"), "s11"}, {("I8", "$"), "r5"}, {("I8", "statement"), "8"},
                 {("I9","$"),"r2"}, {("I9","id"),"r2"}, {("I9","int"),"r2"},{("I9","float"),"r2"},
                 {("I10", ";"), "s17"},
                 {("I11", "="), "s12"},
                {("I12", "id"), "s14"}, { ("I12", "int_const"), "s15" }, {("I12", "float_const"), "s16"}, {("I12","expr"),"13"},
                {("I13", ";"), "s18"},
                 {("I14", ";"), "r7"},
                 {("I15", ";"), "r7"},
                 {("I16", ";"), "r7"},
                 {("I17", "$"), "r3"},
                 {("I17", "id"), "r3"},
                 {("I17", "int"), "r3"},
                {("I17", "float"), "r3"},
                 {("I18", "$"), "r6"}, {("I18", "id"),"r6"},
            };
            // 2. Define the grammar rules
            var grammarRules = new Dictionary<int, (string, string[])>()
            {
                { 1, ("program", new[] { "declarations", "statements" }) },
                { 2, ("declarations", new[] { "declaration", "declarations" }) },
                { 3, ("declaration", new[] { "type", "id", ";" }) },
                 { 4, ("type", new[] { "int" }) },
                 { 5, ("type", new[] { "float" }) },
                { 6, ("statements", new[] { "statement", "statements" }) },
                { 7, ("statement", new[] { "id", "=", "expr", ";" }) },
                 { 8, ("expr", new[] { "id" }) },
                  { 9, ("expr", new[] { "int_const" }) },
                 { 10, ("expr", new[] { "float_const" }) },
            };

            Console.WriteLine("Enter a TINY C program (tokens separated by spaces):");
            string input = Console.ReadLine() + " $";
            Queue<string> tokenQueue = new Queue<string>(input.Split(" ").Where(token => !string.IsNullOrWhiteSpace(token)));

            var stack = new Stack<string>();
            stack.Push("I0");

            while (tokenQueue.Count > 0)
            {
                string currentToken = tokenQueue.Peek();
                string currentState = stack.Peek();

                Console.WriteLine($"Current state: {currentState}, Token: {currentToken}");

                if (parsingTable.TryGetValue((currentState, currentToken), out string action))
                {
                    if (action.StartsWith("s")) // shift action
                    {
                        stack.Push(currentToken);
                        stack.Push(action.Substring(1));
                        tokenQueue.Dequeue();
                    }
                    else if (action.StartsWith("r"))//reduce action
                    {
                        int ruleNumber = int.Parse(action.Substring(1));
                        var rule = grammarRules[ruleNumber];

                        // Perform semantic actions during reduction
                        PerformSemanticAnalysis(rule, stack, parsingTable, tokenQueue, currentToken);

                        for (int i = 0; i < rule.Item2.Length; i++)
                        {
                            stack.Pop(); // remove the states added by the rule
                            stack.Pop(); //remove the grammar symbols from stack added by the rules
                        }

                        string nextState = stack.Peek();

                        if (parsingTable.TryGetValue((nextState, rule.Item1), out string gotoState))
                        {
                            stack.Push(rule.Item1); // Push left hand non-terminal to stack
                            stack.Push(gotoState);  //push state to stack
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid syntax at " + currentToken);
                            return;
                        }
                    }
                    else if (action == "acc")
                    {
                        Console.WriteLine("Parsing and Semantic Analysis successful!");
                        return;
                    }

                }
                else if (parsingTable.TryGetValue((currentState, null), out string nullAction))
                {
                    if (nullAction.StartsWith("r")) // handles reduce rules on non terminals.
                    {
                        int ruleNumber = int.Parse(nullAction.Substring(1));
                        var rule = grammarRules[ruleNumber];

                        // Perform semantic actions during reduction
                        PerformSemanticAnalysis(rule, stack, parsingTable, tokenQueue, currentToken);

                        for (int i = 0; i < rule.Item2.Length; i++)
                        {
                            stack.Pop(); // remove the states added by the rule
                            stack.Pop(); //remove the grammar symbols from stack added by the rules
                        }

                        string nextState = stack.Peek();

                        if (parsingTable.TryGetValue((nextState, rule.Item1), out string gotoState))
                        {
                            stack.Push(rule.Item1); // Push left hand non-terminal to stack
                            stack.Push(gotoState);  //push state to stack
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid syntax at " + currentToken);
                            return;
                        }
                    }

                    else
                    {
                        Console.WriteLine($"Error: Invalid input token '{currentToken}' in state '{currentState}'.");
                        return;
                    }

                }
                else
                {
                    Console.WriteLine($"Error: Invalid input token '{currentToken}' in state '{currentState}'.");
                    return;
                }
            }
            Console.WriteLine("Error: Input not fully processed.");

        }

        static void PerformSemanticAnalysis((string, string[]) rule, Stack<string> stack, Dictionary<(string, string), string> parsingTable, Queue<string> tokenQueue, string currentToken)
        {
            switch (rule.Item1)
            {
                case "declaration":
                    // Process declaration and add type of the variable to symbol table.
                    string type = stack.ElementAt(1);
                    string id = stack.ElementAt(2);
                    if (symbolTable.ContainsKey(id))
                    {
                        Console.WriteLine($"Error: variable '{id}' already declared.");
                        Environment.Exit(1);
                    }
                    symbolTable[id] = type;
                    break;
                case "statement":

                    //Perform assignment type check

                    string idVariable = stack.ElementAt(3);
                    string exprType = GetExpressionType(stack.ElementAt(1), parsingTable, tokenQueue);

                    if (symbolTable.ContainsKey(idVariable))
                    {
                        string variableType = symbolTable[idVariable];

                        if (!IsTypeCompatible(variableType, exprType))
                        {
                            Console.WriteLine($"Error: Type mismatch in assignment.  Variable '{idVariable}' is of type '{variableType}' but expression is of type '{exprType}'.");
                            Environment.Exit(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: undeclared variable '{idVariable}'.");
                        Environment.Exit(1);
                    }
                    break;
            }
        }

        // Get type of expression
        static string GetExpressionType(string expressionToken, Dictionary<(string, string), string> parsingTable, Queue<string> tokenQueue)
        {
            if (expressionToken == "id" || parsingTable.ContainsKey((expressionToken, "id")))
            {
                if (symbolTable.TryGetValue(tokenQueue.ElementAt(0), out string type))
                {
                    return type;
                }
                else
                {
                    Console.WriteLine($"Error: undeclared identifier '{tokenQueue.ElementAt(0)}'.");
                    Environment.Exit(1);
                }
            }
            else if (expressionToken == "int_const" || parsingTable.ContainsKey((expressionToken, "int_const")))
            {
                return "int";
            }
            else if (expressionToken == "float_const" || parsingTable.ContainsKey((expressionToken, "float_const")))
            {
                return "float";
            }
            return "unknown";
        }
        // Check compatibility
        static bool IsTypeCompatible(string varType, string exprType)
        {
            if (varType == exprType)
            {
                return true;
            }
            if (varType == "float" && exprType == "int")
            {
                return true; // int can be implicitly converted to float
            }

            return false;
        }
    }
}