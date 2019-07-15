using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uvprototype
{
    public static class uvsim
    {

        const int MEM_SIZE = 100;

        public static string[] memory = new string[MEM_SIZE];
        public static int accumilator, pc = 0, operand = 0, opcode = 0, count = 0;

        //I/O Operations
        public static void read(int op)
        {
            Console.Write("Enter an Integer: ");
            string input = Console.ReadLine();
            memory[op] = input;

        }
        public static void write(int op)
        {
            Console.WriteLine("Contents of location {0}: {1}", op, memory[op]);
        }

        //Load/Store Operations
        public static void load(int op)
        {
            accumilator = int.Parse(memory[op]);
        }

        public static void store(int op)
        {
            memory[op] = accumilator.ToString();
        }

        //ALU
        public static void add(int op) { accumilator += int.Parse(memory[op]); }
        public static void subtract(int op) { accumilator -= int.Parse(memory[op]); }
        public static void divide(int op) { accumilator /= int.Parse(memory[op]); }
        public static void multiply(int op) { accumilator *= int.Parse(memory[op]); }

        //Control Operations
        //using op -1 because after the command runs the pc will be incremented by 1
        public static void branch(int op) { pc = op - 1; }
        public static void branchNeg(int op) { if (accumilator < 0) { pc = op - 1; } }
        public static void branchZero(int op) { if (accumilator == 0) { pc = op - 1;} }
        public static void halt() { pc = 101; }

        //Debugging Operations




        public static void memdump()
        {
            Console.WriteLine("\nAccumilator: {0:d2}\nOpcode: {1:d2}\nOperand: {2:d2}\n\nMemory Dump: ", accumilator, opcode, operand);
            for (int i = 0; i < MEM_SIZE; i++)
            {
                Console.WriteLine("{0:d2}: {1}", i, memory[i]);
            }
        }


        public static void runProgram()
        {
            Console.WriteLine("*** Running Program ***");
            //run code in memory 
            while (pc < MEM_SIZE)
            {
               if(memory[pc] != null)
                {
                    opcode = int.Parse(memory[pc].Substring(0, 2));
                    operand = int.Parse(memory[pc].Substring(2));

                    switch (opcode)
                    {
                        case 10:
                            read(operand);
                            break;
                        case 11:
                            write(operand);
                            break;
                        case 20:
                            load(operand);
                            break;
                        case 21:
                            store(operand);
                            break;
                        case 30:
                            add(operand);
                            break;
                        case 31:
                            subtract(operand);
                            break;
                        case 32:
                            divide(operand);
                            break;
                        case 33:
                            multiply(operand);
                            break;
                        case 40:
                            branch(operand);
                            break;
                        case 41:
                            branchNeg(operand);
                            break;
                        case 42:
                            branchZero(operand);
                            break;
                        case 43:
                            halt();
                            break;
                    }
                }

                //increment program counter
                pc += 1;
                

            }
        }
    }
}

