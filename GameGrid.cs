// See https://aka.ms/new-console-template for more information
using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 

namespace Tetris 
{
    class GameGrid 
    {
        private readonly int[,] grid; 
        public int Rows{ get;}
        public int Columns { get;}

        public int this[int r, int c]
        {
            get => grid[r,c]; 
            set => grid[r,c] = value; 
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows; 
            Columns = columns; 
            grid = new int[rows, columns]; 
        }

        public void printGridContents()
        {
            for(int i = 0; i<Rows; i++)
            {
                for(int j = 0; j<Columns; j++)
                {
                    Console.Write(grid[i,j] + " "); 
                }
                Console.WriteLine(); 
            }
        }
        public void populateGridWithBasicData()
        {
            bool on = true; 
            for(int i = Rows/2; i<Rows; i++)
            {
                if(i%2==0)
                {
                    for(int j = 0; j<Columns; j++)
                    {
                        grid[i,j] = 1; 
                    }
                }
                else
                {
                    for(int j = 0; j<Columns; j++)
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
        }
        public void initializeColumnPiece(int r, int c)
        {
            if(c>Columns-4 || r>Rows-4)
            {
                Console.WriteLine("Grid for shape will not fit at current column"); 
                return; 
            }
            int[,] shapeGrid = {{0,1,0,0}, {0,1,0,0}, {0,1,0,0}, {0,1,0,0}}; 
        
        }
        public bool isInside(int r, int c)
        {
            return r<Rows && r>=0 && c<Columns && c>=0; 
        }
        public bool isEmpty(int r, int c)
        {
            return isInside(r,c) && grid[r,c]==0; 
        }
        public bool isEntireRowFull(int r)
        {
            for(int i = 0; i<Columns; i++)
            {
                if(grid[r,i]==0)
                {
                    return false; 
                }
            }
            return true; 
        }
        public bool isEntireRowEmpty(int r)
        {
            for(int i = 0; i<Columns; i++)
            {
                if(grid[r,i]!=0)
                {
                    return false; 
                }
            }
            return true; 
        }
        public void clearRow(int r)
        {
            for(int i = 0; i<Columns; i++)
            {
                grid[r,i]=0;
            }
        }
        public void moveDown(int r, int numRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c]; 
                grid[r, c] = 0; 
            }
        }
        public int clearAllFullRows()
        {
            int cleared = 0; 
            for(int r = Rows-1; r>-1; r--)
            {
                if(isEntireRowFull(r))
                {
                    clearRow(r); 
                    cleared++; 
                }
                else if(cleared>0)
                {
                    moveDown(r, cleared); 
                }
            }  
            return cleared;         
        }
    }
}
