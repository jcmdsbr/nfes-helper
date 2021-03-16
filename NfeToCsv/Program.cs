using System.Globalization;
using System.Threading;

namespace NfeToCsv
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            using var scan = new NfeScan("Notas");
            scan.CriarCsv(Helper.ConverterXmlNode(scan.CarregarXml()));
        }
    }
}