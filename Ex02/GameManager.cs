using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        public void Run()
        {
            Menu gameMenu = new Menu();
            GameSettings settings = gameMenu.Run();
        }
    }
}
