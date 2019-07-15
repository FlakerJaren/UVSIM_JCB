using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uvprototype
{
    public static class ui
    {
        public static void display_instructions()
        {
            Console.WriteLine("Welcome to JCB's UV Simulator!\nPlease enter instructions one data word at a time.\nData words are positve or negative 4 digit strings." +
            "\nWhen you are finished, enter -99999 to stop and run program.\n");
        }

        public static void get_Input()
        {

            while (true)
            {
                Console.Write("{0:D2} ? ", uvsim.count);

                string user_input = Console.ReadLine();
                if (user_input == "-99999")
                    break;

                if (user_input.Length == 5)
                {
                    if (user_input[0] == '+' || user_input[0] == '-')
                    {
                        //slice string to remove sign in front
                        uvsim.memory[uvsim.count] = (user_input.Substring(1, 4));
                        uvsim.count += 1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Instruction: Missing (+) or (-) Sign");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                
            }
        }
    

    }
}
