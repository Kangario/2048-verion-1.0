using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2048
{
    class Map
    {


        
        public static string[] Nums = { "", "2", "4", "8", "16", "32", "64", "128", "512", "1024", "2048" };


       
        private int[,] pos = new int[4, 4] ;
        public int[,] Pos
        {
            get { return pos; }
            set { pos = value; }
        }

      
        private string[] showStr = new string[12];
        public string[] ShowStr
        {
            get { return showStr; }
            set { showStr = value; }
        }
    }
}
