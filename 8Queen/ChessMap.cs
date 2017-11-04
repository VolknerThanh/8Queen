using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Queen
{
    class ChessMap
    {
        #region variables
        private int n;
        private int[,] map;
        private int d;
        private int c;
        private int k;
        #endregion
        #region properties
        public int N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }
        public int[,] Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }
        public int D
        {
            get
            {
                return d;
            }

            set
            {
                d = value;
            }
        }
        public int C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }
        public int K
        {
            get
            {
                return k;
            }

            set
            {
                k = value;
            }
        }
        #endregion

        public ChessMap()
        {
            k = 1;
            d = -1;
            c = -1;
            n = 8;
            map = new int[n, n];
        }
        public void CreateChessMap()
        {
            for(int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                    map[i, j] = 0;
        }
        public void Input()
        {
            Console.WriteLine("Enter the first queen location : ");
            Console.Write("Location x : ");
            d = int.Parse(Console.ReadLine());
            Console.Write("Location y : ");
            c = int.Parse(Console.ReadLine());

            map[d, c] = k;
        }
        public void SetRoad(int dong, int cot, int[,] tmp)
        {
            /* duong cheo thuan */
            int ld = dong, lc = cot;
            while (true)  // tim dinh cua duong cheo chinh
            {
                if (ld == 0 || lc == 0) break;
                ld--; lc--;
            }
            while (true)  // gan -1 cho duong cheo chinh
            {
                if (tmp[ld, lc] != k)
                    tmp[ld, lc] = -1;
                ld++; lc++;
                if (ld == n || lc == n) break;
            }
            /* duong cheo nghich */
            ld = dong; lc = cot;
            while (true)  // tim dinh cua duong cheo phu
            {
                if (ld == 0 || lc == n - 1) break;
                ld--; lc++;
            }
            while (true) // gan -1 cho duong cheo phu
            {
                if (tmp[ld, lc] != k)
                    tmp[ld, lc] = -1;
                ld++; lc--;
                if (ld == n || lc < 0) break;
            }
            /* duong ngang && duong doc */
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if ((i == dong && j != cot) || (i != dong && j ==cot))
                        tmp[i, j] = -1;
                }
            }
        }
        public void Output()
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (map[i, j] == -1)
                        Console.Write(map[i, j]+ " ");
                    else
                        Console.Write(" " + map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int[,] b = new int[8, 8];
        public void CopyChessMap()
        {
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    b[i, j] = map[i, j];
            }
        }
        public void OutputCopy()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (b[i, j] == -1)
                        Console.Write(b[i, j] + " ");
                    else
                        Console.Write(" " + b[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int CountNull(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (matrix[i, j] == 0)
                        count++;
            return count;
        }
        public int FindMaxLocation(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[max] < array[i])
                    max = i;
            return max;
        }
        public void OutputListTuple(List<Tuple<int,int>> ds)
        {
            Console.WriteLine("Availble location of other queens list : ");
            foreach (var item in ds)
                Console.WriteLine(item.Item1 + "-" + item.Item2);
            Console.WriteLine();
        }
        public bool CheckMapIsStillEmpty()
        {
            for(int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                    if (map[i, j] == 0)
                        return true;
            return false;
        }
        public void FindMyQueen()
        {
            if (k == 8)
            {
                Console.WriteLine("FULL 8 QUEEN ! CONGRATULATION ! ");
                LocationOfAllQueen();
                return;
            }
            if(!CheckMapIsStillEmpty())
            {
                Console.WriteLine("It has been full of queen in this map ! please re-enter the location ! ");
                LocationOfAllQueen();
                return;
            }
            List<Tuple<int, int>> ds = new List<Tuple<int, int>>();
            int dem = 0;
            #region condition
            
            if (d + 2 < n && c + 1 < n && map[d + 2, c + 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d + 2, c + 1));

            }
            if (d + 1 < n && c + 2 < n && map[d + 1, c + 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d + 1, c + 2));
            }
            if (d - 1 >= 0 && c + 2 < n && map[d - 1, c + 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d - 1, c + 2));
            }
            if (d - 2 >= 0 && c + 1 < n && map[d - 2, c + 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d - 2, c + 1));
            }
            if (d - 2 >= 0 && c - 1 >= 0 && map[d - 2, c - 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d - 2, c - 1));
            }
            if (d - 1 >= 0 && c - 2 >= 0 && map[d - 1, c - 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d - 1, c - 2));
            }
            if (d + 1 < n && c - 2 >= 0 && map[d + 1, c - 2] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d + 1, c - 2));
            }
            if (d + 2 < n && c - 1 >= 0 && map[d + 2, c - 1] == 0)
            {
                dem++;
                ds.Add(new Tuple<int, int>(d + 2, c - 1));
            }
            
            if(dem==0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (map[i,j] == 0)
                        {
                            dem++;
                            ds.Add(new Tuple<int, int>(i,j));
                        }
                    }
                }
            }
            #endregion
            int[] array = new int[dem];
            Console.WriteLine("CURRENT MAP : ");
            Output();
            OutputListTuple(ds);

            for (int i = 0; i < dem; i++)
            {
                Console.WriteLine("Queen ( " + ds[i].Item1 + "-" + ds[i].Item2 + " )");
                CopyChessMap();
                SetRoad(ds[i].Item1, ds[i].Item2, b);
                Console.WriteLine("Empty location(s) are : " + CountNull(b));
                array[i] = CountNull(b);
                //OutputCopy();
                Console.WriteLine();
            }
            int max = FindMaxLocation(array);
            d = ds[max].Item1;
            c = ds[max].Item2;
            map[d, c] = ++k;
            SetRoad(d, c, map);
            Console.WriteLine("================================================================");
            Console.WriteLine(" [ K: " + k + " ] ");
            Console.WriteLine(" [ Location: " + d + "-" + c + " ] ");
            Output();
            Console.WriteLine("================================================================");
            Console.WriteLine();
            FindMyQueen();
        }
        public void LocationOfAllQueen()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (map[i, j] == -1)
                        Console.Write("_ ");
                    else
                        Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
