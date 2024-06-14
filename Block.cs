using System.Runtime;
using Tetris;

namespace Block 
{
    public abstract class Block 
    {
        protected abstract Position[][] Tiles {get; }
        protected abstract Position StartOffset{get;}

        public abstract int Id {get; }
    }
}