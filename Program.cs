using System.Diagnostics.Metrics;
using System.Reflection;
using System;

namespace interpeter;

class program
{
    public static void Main(string[] args)
    {
        // write your code here
        string code = "++++++++++\r\n[\r\n\t>++++++++\r\n\t>++++++++++\r\n\t>+++++++++++\r\n\t>++++++++++\r\n\t>+++++++++++\r\n\t>++++++++++\r\n\t>++++++++++\r\n\t<<<<<<<-\r\n]\r\n\r\n>+++\r\n>---\r\n>---\r\n>+\r\n>----\r\n>++++\r\n>---\r\n\r\n";   
        int[] memory = new int[30000];

        executeInput(code.ToCharArray());
        for (int i = 0 ; i < 8 ; i++)
        {
            Console.Write(" [{0}] " , memory[i]);
        }  
        

        void executeInput(char[] input)
        {
            int pointer = 0;

            int i = 0;
            int j = 0;

            char[] loop = new char[input.Length];

            while (i < input.Length)
            {
                switch (input[i])
                {
                    case '+':
                        memory[pointer]++;
                        break;

                    case '-':
                        memory[pointer]--;
                        break;

                    case '>':
                        pointer++;
                        if (pointer > memory.Length)
                        {
                            pointer = 0;
                        }
                        break;

                    case '<':
                        pointer--;
                        if (pointer < 0)
                        {
                            pointer = memory.Length;
                        };
                        break;

                    case '.':
                        Console.Write("At {0} : [{1}]" , pointer , memory[pointer]);
                        break;

                    case ',':
                        Console.Write("Input at {0} : " , pointer);
                        memory[pointer] = Convert.ToInt32(Console.ReadLine());
                        break;

                    case '[':
                        while (input[i] != ']')
                        {
                            loop[j] = input[i + 1];

                            j++;
                            i++;
                        }
                        while (memory[pointer] != 0)
                        {
                            executeInput(loop);
                        }

                        break;
                }
                i++;
            }
        }
    }
}