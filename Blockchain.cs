using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpBlockchain
{
    public class Blockchain
    {
        private List<Block> _chain;
        public List<Block> chain { 
            get{
                return _chain;
            }
        }
        public Blockchain()
        {
            _chain=new List<Block>();
            Block genesisBlock=CreateGenesis();
            _chain.Add(genesisBlock);
        }

        public Block CreateGenesis()
        {
            return new Block(0,DateTime.UtcNow,"Genesis Block","0");
        }

        public Block GetLastestBlock()
        {
            return _chain[_chain.Count-1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.previoushash=GetLastestBlock().hash;
            newBlock.hash=newBlock.CalculateHash();
            this._chain.Add(newBlock);
        }

        public bool CheckValid()
        {
            for(int i=1; i<this._chain.Count;i++)
            {
                Block currentBlock = this._chain[i];
                Block previousBlock =this._chain[i-1];

                if(currentBlock.hash != currentBlock.CalculateHash())
                return false;

                if(currentBlock.previoushash != previousBlock.hash)
                return false;
            }
            return true;
        }
    }
}