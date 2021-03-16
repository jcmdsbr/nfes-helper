namespace NfeToCsv
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using var scan = new NfeScan("example");
            scan.CriarCsv(Helper.ConverterXmlNode(scan.CarregarXml()));
        }
    }
}