using System;

namespace _8Queen
{
    class Program
    {
        //定義解的個數
        int sum = 0;
        //定義皇后組數
        int[] Queens = new int[8];

        public static void Main(string[] args)
        {
            Program Pro = new Program();
            
            //開始求解
            Pro.QueenSort(0);
            Console.ReadKey();
        }

        /// <summary>
        /// 排序獲取組合（1-8）
        /// </summary>
        /// <param name="num"></param>
        public void QueenSort(int num)
        {
            for (int j = 1; j < 9; j++)
            {
                if (num == 8)
                {
                    sum++;
                    //輸出
                    Write();
                    break;
                }
                //判斷是否衝突
                if (FooConflict(num, j))
                {
                    Queens[num] = j;
                    QueenSort(num + 1);
                }
            }
        }

        /// <summary>
        /// 判斷皇后是否和之前所有的皇后衝突
        /// </summary>
        /// <param name="row">已放置完畢無衝突皇后的列數</param> 
        /// <param name="queen">新放置的皇后值</param> 
        /// <returns>是否衝突</returns>
        public bool FooConflict(int row, int queen)
        {
            if (row == 0)
            {
                return true;
            }
            else
            {
                //循環判斷與之前的皇后是否有衝突的
                for (int pionter = 0; pionter < row; pionter++)
                {
                    //如果有，返回false
                    if (!FooCompare(Queens[pionter], row - pionter, queen))
                    {
                        return false;
                    }
                }
                //與之前均無衝突，返回true
                return true;
            }
        }

        /// <summary>
        /// 對比2個皇后是否衝突
        /// </summary>
        /// <param name="i">之前的一個皇后</param> 
        /// <param name="row">2個皇后的列數之差</param> 
        /// <param name="queen">新放置的皇后</param>
        /// <returns></returns>
        public bool FooCompare(int i, int row, int queen)
        {
            //判斷2個皇后是否相等或相差等於列數之差(即處於正反對角線)
            if ((i == queen) || ((i - queen) == row) || ((queen - i) == row))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打印皇后圖案
        /// </summary>
        public void Write()
        {
            //輸出皇后的個數排序
            Console.WriteLine("第 " + sum + " 個皇后排列：");

            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (j == Queens[i])
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                //換行
                Console.Write("\n");
            }
        }
    }
}
