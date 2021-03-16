using System;

namespace NfeToCsv
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using var scan = new NfeScan("example");
            var nodes = scan.Get();
            NfeScan.TransformToCsv(Helper.NodeToList(nodes));
            Console.ReadKey();
        }
    }
}