using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    class Program
    {
		public static void Main(string[] args)
		{
			int t = 1;
			string x = "12345123";
			x = t + x.Substring(0,7);
			Console.WriteLine("{0}", x);
		}
	}
}
