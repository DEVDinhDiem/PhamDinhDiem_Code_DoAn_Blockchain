using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_BlockChain
{
    class Block
    {
        public String hash;
        public String previousHash;
        private String data; 
        private long timeStamp;
        private int nonce = 0;

        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            this.timeStamp = DatetimeHandle.GetTime();
            this.hash = CalculateHash();
        }
        public String CalculateHash()
        {
            HashSha256 sha256 = new HashSha256();
            String calculatedhash = sha256.Hash(
                    previousHash +
                    timeStamp.ToString() +
                    nonce.ToString() +
                    data);
            return calculatedhash;
        }
        public void MineBlock(int difficulty)
        {
            var str = new String(new char[difficulty]);
            String target = new String(new char[difficulty]).Replace('\0', '0'); //Tạo một chuỗi với độ khó * "0"
            while (!hash.Substring(0, difficulty).Equals(target))
            {
                nonce++;
                hash = CalculateHash();
            }
            Console.WriteLine("Da khai thac : " + hash);
        }

    }
}
