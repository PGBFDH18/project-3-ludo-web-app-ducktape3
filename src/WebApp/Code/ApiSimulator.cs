using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Code
{
    public class ApiSimulator
    {
        public int RollDiece()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
