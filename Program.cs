using System;
using Newtonsoft.Json;

namespace CSharpBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Blockchain!");
            Blockchain demoBlockchain = new Blockchain();
            demoBlockchain.AddBlock(new Block(demoBlockchain.GetLastestBlock().index+1,DateTime.UtcNow,"my first transaction",demoBlockchain.GetLastestBlock().previoushash));
            demoBlockchain.AddBlock(new Block(demoBlockchain.GetLastestBlock().index+1,DateTime.UtcNow,"my second transaction",demoBlockchain.GetLastestBlock().previoushash));

            Console.Write(JsonConvert.SerializeObject(demoBlockchain));
            Console.Write("Is this blockchain valid?  "+demoBlockchain.CheckValid());
        }
    }
}
