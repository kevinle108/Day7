using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            //string expression = "32 + 5.2 * ((4.6 ^ 2 – 20 / 3)) – 4 * 2";
            List<string> tokens = TokensFromString(Console.ReadLine());
            OutputTokens(tokens);

            /// FUNCTIONS ///
            static List<string> TokensFromString(string expression)
            {
                List<string> tokensList = new List<string>();
                string token = "";
                bool insideNum = false;
                for (int i = 0; i < expression.Length; i++)
                {
                    char c = expression[i];
                    if (CharType(expression[i]) == "digit" || CharType(expression[i]) == "decimal") 
                    {
                        insideNum = true;
                        token += expression[i];
                        continue;         
                    }
                    else
                    {
                        if (CharType(expression[i]) == "space") continue;
                        if (insideNum)
                        {
                            tokensList.Add(token);
                            token = "";
                            insideNum = false;
                        }
                        tokensList.Add(expression[i].ToString());
                    }
                }
                if (token != "")
                {
                    tokensList.Add(token);
                }
                return tokensList;
            }

            static string CharType(char c)
            {

                if (c == ' ') return "space";
                else if (c == '+' || c == '-' || c == '–' || c == '*' || c == '/' || c == '^' || c == '%') return "operand";
                else if (c == '(' || c == ')' || c == '{' || c == '}') return "parenthesis";
                else if (c == '.') return "decimal";
                else return "digit";
            }

            static void OutputTokens(List<string> tokens) {
                tokens.ForEach(token => Console.WriteLine(token));
            }
        }
    }
}
