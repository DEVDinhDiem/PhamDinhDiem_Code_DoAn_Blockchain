using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_BlockChain
{
    class Program
    {
        public static List<Block> blockchain = new List<Block>();
        public static int difficulty = 5;

        static void Main(string[] args)
        {

            blockchain.Add(new Block("Day la do an Blockchain dau tien", "0"));
            Console.WriteLine("Dang dao khoi 1... ");
            blockchain.ElementAt(0).MineBlock(difficulty);

            blockchain.Add(new Block("minh ten la Dinh Diem", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Dang dao khoi 2... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            blockchain.Add(new Block("Minh là sinh vien nam 3", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Dang dao khoi 3... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            string printBlockChain = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(blockchain);
            Console.WriteLine(printBlockChain);

            Console.ReadLine();
        }


        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            //lặp qua blockchain để kiểm tra hàm băm:
            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain.ElementAt(i);
                previousBlock = blockchain.ElementAt(i - 1);

                //so sánh hàm băm đã đăng ký và hàm băm được tính toán:
                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }

                //so sánh hàm băm trước đó và hàm băm trước đó đã đăng ký
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
            }
            return true;
        }

    }
}
