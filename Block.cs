using System.Runtime;

namespace Tetris 
{
    public abstract class Block 
    {
        protected abstract Position[][] Tiles {get; }
        protected abstract Position StartOffset{get;}

        public abstract int Id {get; }

        private int currentRotationState;
        private Position currentOffset;

        public Block()
        {
            currentOffset = new Position(StartOffset.Row, StartOffset.Column); 
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach(Position p in Tiles[currentRotationState])
            {
                yield return new Position(p.Row + StartOffset.Row, p.Column + StartOffset.Column); 
            }
        }

        public void rotate90DegreesClockwise()
        {
            currentRotationState = (currentRotationState + 1) % Tiles.Length; 
        }

        public void rotate90DegreesAntiClockwise()
        {
            if(currentRotationState==0)
            {
                currentRotationState = Tiles.Length - 1; 
            }
            else
            {
                currentRotationState--; 
            }

        }

        public void Move(int r, int c)
        {
            currentOffset.Row += r; 
            currentOffset.Column += c; 
        }

        public void reset()
        {
            currentOffset.Row = StartOffset.Row; 
            currentOffset.Column = StartOffset.Column; 
            currentRotationState = 0; 
        }
    }
}