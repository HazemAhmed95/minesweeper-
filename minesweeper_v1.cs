using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineswapers
{
    class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game \n choose your grid size :) : ");
          int Row = int.Parse(Console.ReadLine());
            int Coll = int.Parse(Console.ReadLine());

        
            char[,] array = new char[Row, Coll];
            //set all of the map as unrevealed 

            for (int i = 0; i< array.GetLength(0) ; i++)
            {
                for (int j = 0; j <Coll; j++)
                {
                    array[i, j] = '-';
                    array2[i, j] = '-';
                }
            }

            //set bombs 
            Console.WriteLine(" enter the boombs number and locations");
            int bombs_number = int.Parse(Console.ReadLine());
            for (int i = 0; i < bombs_number; i++)
            {
                Console.WriteLine("the bomb number {0} in form of [i.j]",i);
                
                int bombrow = int.Parse(Console.ReadLine());
                
                int bombcoll = int.Parse(Console.ReadLine());

                array[bombrow, bombcoll] = 'B';

            }
            bool end = true;
            while (end)

            {   Console.WriteLine("enter state then the cell cord");
                char state = char.Parse(Console.ReadLine());
                 int gamerow = int.Parse(Console.ReadLine());
                
                int gamecoll = int.Parse(Console.ReadLine());
                PlayerAction(state, ref array[gamerow,gamecoll]);
                Print(array);
                end = Gameover(array);            
            }

        }



        public static void PlayerAction(char state,ref char value)
        {

            if(state == 'F')
            {
                // if its un flaged falg it 
                if (value!=state)
                {
                    value = state;
                }
                else
                {

                    value = '-';
                }

            }

            if (state == 'R')
            {
                //if its boombed == gameover
                if (value == 'B')
                {
                    value = 'G';
                    Console.WriteLine("game OVER");
                 
                }
                else
                {

                    value = 'R';
                }
                
            }
            
        }

        public static bool Gameover (char[,]arr)
        { int counter = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <arr.GetLength(1); j++)
                {

                    if (arr[i, j] == 'G')
                    {
                        Console.WriteLine("game over ");
                        return false; //for gameover
                    }

                    else if (arr[i, j] != '-')
                    {
                        counter++;
                        return true;
                    }
                    
                    if (counter == arr.Length)
                    {
                        Console.WriteLine("you won");
                        return false;

                    }
                
                }
            }

            return true;
        }
        
        //the print method 
        public static void Print(char[,]Arr){
            int counter = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    counter++;
                    Console.Write(Arr[i,j]+" ");
                    if (counter== Arr.GetLength(0))
                    {
                        Console.WriteLine();
                        counter = 0;
                    }
                    
                }
            }
        }


    }
}
