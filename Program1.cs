// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Text; 
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Tetris 
{
    class Program1 
    {
        static void Main(string[] args) //method/functions
        {
            GameGrid grid = new GameGrid(10,10); 
            grid.populateGridWithBasicData(); 
            grid.printGridContents(); 
            Console.WriteLine(); 
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine(); 
            grid.clearAllFullRows(); 
            grid.printGridContents(); 
        }
    }
}
