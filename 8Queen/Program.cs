using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Queen
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMap bc = new ChessMap();
            bc.CreateChessMap();
            bc.Input();
            bc.SetRoad(bc.D, bc.C, bc.Map);
            Console.WriteLine(bc.K);
            bc.FindMyQueen();
        }
    }
}
