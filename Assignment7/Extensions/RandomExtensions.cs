using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7.Extensions
{
    public static class RandomExtensions
    {
        public static void  makeThreadSleepForMaximal(this Random random,int millisecs)
         => Thread.Sleep(random.Next(millisecs));
    }
}
