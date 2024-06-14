// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Text; 
using System.Threading.Tasks; 

namespace Tetris 
{
    class Program1 
    {
        static void Main(string[] args) //method/functions
        {
            bool on = true; 
            GameGrid grid = new GameGrid(20,10); 
            for(int i = 0; i<grid.Rows; i++)
            {
                if(i%2==0)
                {
                    for(int j = 0; j<grid.Columns; j++)
                    {
                        grid[i,j] = 1; 
                    }
                }
                else
                {
                    for(int j = 0; j<grid.Columns; j++)
                    {
                        if(on==true)
                        {
                            grid[i,j] = 1; 
                            on = false; 
                        }
                        else
                        {
                            grid[i,j] = 0; 
                            on = true; 
                        }
                    }
                }
            }
            grid.printGridContents(); 
            grid.clearRowMoveDown(19); 
            Console.WriteLine(); 
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine(); 
            grid.printGridContents(); 

            // Console.WriteLine(grid.isEntireRowFull(0)); 
            // Console.WriteLine(grid.isEntireRowFull(1));
            // Console.WriteLine(grid.isEntireRowEmpty(0));  
            // Console.WriteLine(grid[0,0]);
            // Console.WriteLine(grid.isEmpty(0,0));
            // Console.WriteLine(grid[0,1]); 
            // Console.WriteLine(grid.isEmpty(0,1)); 
        }
    }
}
