using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uvprototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ui.display_instructions();
            ui.get_Input();
            uvsim.runProgram();
            uvsim.memdump();
            Console.Read();
        }
    }
}
