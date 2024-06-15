using System; 

namespace Tetris 
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[] 
        {
            new IBlock(), 
            new JBlock(), 
            new LBlock(), 
            new OBlock(), 
            new SBlock(), 
            new TBlock(), 
            new ZBlock()
        }; 

        private readonly Random random = new Random(); 

        public Block nextBlock {get; private set;}

        public Block getRandomBlock()
        {
            return blocks[random.Next(blocks.Length)]; 
        }

        public BlockQueue()
        {
            nextBlock = getRandomBlock(); 
        }

        public Block GetAndUpdate()
        {
            Block block = nextBlock; 
            while(block.Id == nextBlock.Id)
            {
                nextBlock = getRandomBlock(); 
            }
            return block; 
        }
    }
}