using System;

namespace CSharpBlockchain
{
    public class Block{
        private int _index;
        public int index 
        { 
            get 
            {
                return this._index;
            }
        }  
        private DateTime _timestamp;
        public DateTime timestamp 
        { 
            get
            {
                return this._timestamp;
            }        
        }
        private string _transaction, _previoushash;
        public string transaction 
        { 
            get
            {
                return this._transaction;
            } 
        } 
        public string previoushash 
        {
            get
            {
                return this._previoushash;
            }
            set
            {
                this._previoushash=value;
            }
        }
        private string _hash;
        public string hash 
        {
            get
            {
                return this._hash;
            }
            set
            {
                this._hash=value;
            }
        }
        private int _nonce;
        public int nonce 
        {
            get
            {
                return this._nonce;
            }
        }
        public Block(int index, DateTime timestamp, string transaction, string previoushash)
        {
            _index=index;
            _timestamp =timestamp;
            _transaction =transaction;
            _previoushash=previoushash;
            _hash=this.CalculateHash();
            _nonce=0;
        }
        public string CalculateHash()
        {
            return Crypto.GetHash(_index.ToString()+_timestamp.ToString()+_transaction+_previoushash);
        }


    }
}