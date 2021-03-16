using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace NfeToCsv
{
    public class NfeScan : IDisposable
    {
        public NfeScan(string arquivo)
        {
            Arquivo = arquivo;
        }

        private string Arquivo { get; }
        private XmlDataDocument XmlDataDocument { get; set; } = new();

        public void Dispose()
        {
            XmlDataDocument = null;
        }

        public XmlNodeList Get()
        {
            using var fs = new FileStream($"{Arquivo}.xml", FileMode.Open, FileAccess.Read);
            XmlDataDocument.Load(fs);
            return XmlDataDocument.GetElementsByTagName("ns2:Nfse");
        }

        public static void TransformToCsv(List<Nfe> nfes)
        {
            var builder = new StringBuilder();
            builder.AppendLine(
                "Cnpj;InscricaoMunicipal;RazaoSocial;Numero;DataEmissao;Valor;TomadorRazaoSocial;TomadorCnpj");
            nfes.ForEach(book => { builder.AppendLine(book.ToString()); });
            var lines = builder.ToString().Split('\n');
            using var streamWriter = File.CreateText(@"example.csv");
            foreach (var line in lines)
                streamWriter.WriteLine(line);
        }
    }
}