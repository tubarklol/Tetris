namespace Tetris
{
    class GameState
    {
        private Block currentBlock; 

        public Block CurrentBlock
        {
            get => currentBlock; 
            private set
            {
                currentBlock = value; 
                currentBlock.reset(); 
            }
        }

        public GameGrid GameGrid {get;}
        public BlockQueue BlockQueue {get;}

        public bool GameOver {get; private set;} 

        public GameState()
        {   
            GameGrid = new GameGrid(22,10); 
            BlockQueue = new BlockQueue(); 
            currentBlock = BlockQueue.GetAndUpdate(); 
        } 

        private bool BlockFits()
        {
            foreach(Position p in currentBlock.TilePositions())
            {
                if(!GameGrid.isEmpty(p.Row, p.Column))
                {
                    return false; 
                }
            }
            return true; 
        }

        public void rotateBlockClockwise()
        {
            currentBlock.rotate90DegreesClockwise(); 

            if(!BlockFits())
            {
                currentBlock.rotate90DegreesAntiClockwise(); 
            }
        }

        public void rotateBlockAnticlockwise()
        {
            currentBlock.rotate90DegreesAntiClockwise(); 

            if(!BlockFits())
            {
                currentBlock.rotate90DegreesClockwise(); 
            }
        }

        public void moveBlockLeft()
        {
            currentBlock.Move(0, -1); 
            if(!BlockFits())
            {
                currentBlock.Move(0,1);
            }
        }

        public void moveBlockRight()
        {
            currentBlock.Move(0, 1); 
            if(!BlockFits())
            {
                currentBlock.Move(0,-1);
            }
        }

        private bool IsGameOver()
        {   
            return !(GameGrid.isEntireRowEmpty(0) && GameGrid.isEntireRowEmpty(1)); 
        }

        private void PlaceBlock()
        {
            foreach(Position p in currentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = currentBlock.Id; 
            }

            GameGrid.clearAllFullRows();

            if(IsGameOver())
            {
                GameOver = true; 
            } 
            else
            {
                currentBlock = BlockQueue.GetAndUpdate(); 
            }
        }

        public void moveDown()
        {
            currentBlock.Move(1,0); 
            if(!BlockFits())
            {
                currentBlock.Move(-1,0);
                PlaceBlock(); 
            }
        }
    }
}