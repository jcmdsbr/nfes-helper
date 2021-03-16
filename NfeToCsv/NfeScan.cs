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

        private const string CABECALHO = "Numero;DataEmissao;Valor;TomadorRazaoSocial;TomadorCnpj";
        private string Arquivo { get; }
        private XmlDataDocument LeitorXml { get; set; } = new();
     
        public XmlNodeList CarregarXml()
        {
            using var fs = new FileStream($"{Arquivo}.xml", FileMode.Open, FileAccess.Read);
            LeitorXml.Load(fs);
            return LeitorXml.GetElementsByTagName("ns2:Nfse");
        }

        public void CriarCsv(List<Nfe> nfes)
        {
            var builder = new StringBuilder();
            builder.AppendLine(CABECALHO);
            nfes.ForEach(nfe => { builder.AppendLine(nfe.ToString()); });
            using var streamWriter = File.CreateText($"{Arquivo}.csv");
            foreach (var linha in  builder.ToString().Split('\n'))
                streamWriter.WriteLine(linha);
        }
        
        public void Dispose()
        {
            LeitorXml = null;
        }
    }
}