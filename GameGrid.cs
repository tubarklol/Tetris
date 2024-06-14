// See https://aka.ms/new-console-template for more information
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
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

        protected void clearRow(int r)
        {
            for(int i = 0; i<Columns; i++)
            {
                grid[r,i]=0;
            }
        }

        protected void moveDown(int r)
        {
            for(int i = r; i>0; i--)
            {
                for(int j = 0; j<Columns; j++)
                {
                    grid[i,j] = grid[i-1,j]; 
                }
            }
        }

        public void clearRowMoveDown(int r)
        {
            clearRow(r);
            moveDown(r); 
            clearRow(0); 
        }
    }
}
