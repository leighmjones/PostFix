using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostFix

                                                            
{
    class Program
    {
        static void Main(string[] args)
        {
            //DECLARE STACK
            Stack<double> stkPostFix = new Stack<double>();

            //Loops whole program again
            while (true)
            {
                Console.Write("Please enter a Post Fix expression:   ");
                //Stores user's input into an array and splits on spaces
                string[] userInput = Console.ReadLine().Split(' ');

                //Goes through user's input 
                foreach (string token in userInput)
                {   
                    //Declare variable to hold numbers
                    double value;

                    //IF THE USERINPUT IS A NUMBER...
                    if (double.TryParse(token, out value))
                    {

                        //PUSH TO THE STACK
                        stkPostFix.Push(value);

                    }
                    else//IF NOT A NUMBER...EVALUATE
                    {
                        double rhs = stkPostFix.Pop();//right-hand side
                        double lhs = stkPostFix.Pop();//left-hand side

                        switch (token)
                        {
                            //checks for the operators and performs math
                            case "+":
                                stkPostFix.Push(lhs + rhs);
                                break;
                            case "-":
                                stkPostFix.Push(lhs - rhs);
                                break;
                            case "*":
                                stkPostFix.Push(lhs * rhs);
                                break;
                            case "/":
                                stkPostFix.Push(lhs / rhs);
                                break;
                            default:
                                throw new Exception("invalid operator");

                        }
                    }

                }
                //Display final result using POP or PEEK
                Console.Write(stkPostFix.Pop());
                Console.WriteLine(" ");
            }
            

            Console.ReadKey();

        }//end main

        static double RunOperand(double Operand1, double Operand2, string strOperator)
        {
            if (strOperator == "+") return Operand1 + Operand2;
            if (strOperator == "*") return Operand1 * Operand2;
            if (strOperator == "-") return Operand1 - Operand2;
            if (strOperator == "/") return Operand1 / Operand2;
            return 0;
        }

    }//end class
}
