using System;
using System.Xml;

namespace NfeToCsv
{
    public class Nfe
    {
        private const int NUMERO = 0;
        private const int DATA_EMISSAO = 1;
        private const int NATUREZA_OPERACAO = 2;
        private const int REGIME_ESPECIAL_TRIBUTACAO = 3;
        private const int OPTANTE_SIMPLES_NASCIONAL = 4;
        private const int INCENTIVADOR_CULTURAL = 5;
        private const int COMPETENCIAS = 6;
        private const int SERVICO = 7;
        private const int PRESTADOR_SERVICO = 8;
        private const int TOMADOR_SERVICO = 9;

        public string Cnpj { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string RazaoSocial { get; set; }
        public string Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NaturezaOperacao { get; set; }
        public string RegimeEspecialTributacao { get; set; }
        public string IncentivadorCultural { get; set; }
        public DateTime Competencia { get; set; }
        public decimal Valor { get; set; }
        public string TomadorRazaoSocial { get; set; }
        public string TomadorCnpj { get; set; }
        public string OptanteSimplesNascional { get; set; }

        public override string ToString()
        {
            return
                $"{Numero};{DataEmissao};{Valor:C};{TomadorRazaoSocial};{TomadorCnpj}";
        }

        public static explicit operator Nfe(XmlNodeList nodeList)
        {
            return new()
            {
                Numero = nodeList.Item(NUMERO)?.FirstChild?.InnerText.Trim(),
                DataEmissao = DateTime.Parse(nodeList.Item(DATA_EMISSAO)?.InnerText.Trim() ?? string.Empty),
                NaturezaOperacao = nodeList.Item(NATUREZA_OPERACAO)?.InnerText.Trim(),
                RegimeEspecialTributacao = nodeList.Item(REGIME_ESPECIAL_TRIBUTACAO)?.InnerText.Trim(),
                OptanteSimplesNascional = nodeList.Item(OPTANTE_SIMPLES_NASCIONAL)?.InnerText.Trim(),
                IncentivadorCultural = nodeList.Item(INCENTIVADOR_CULTURAL)?.InnerText.Trim(),
                Competencia = DateTime.Parse(nodeList.Item(COMPETENCIAS)?.InnerText.Trim() ?? string.Empty),
                Valor = decimal.Parse(nodeList.Item(SERVICO)?.FirstChild?.FirstChild?.InnerText.Trim().Replace(".", ",") ?? string.Empty),
                Cnpj = nodeList.Item(PRESTADOR_SERVICO)?.FirstChild?.FirstChild?.InnerText.Trim(),
                InscricaoMunicipal = nodeList.Item(PRESTADOR_SERVICO)?.FirstChild?.LastChild?.InnerText.Trim(),
                RazaoSocial = nodeList.Item(PRESTADOR_SERVICO)?.ChildNodes?.Item(1)?.InnerText?.Trim(),
                TomadorRazaoSocial = nodeList.Item(TOMADOR_SERVICO)?.ChildNodes?.Item(1)?.InnerText?.Trim(),
                TomadorCnpj = nodeList.Item(TOMADOR_SERVICO)?.FirstChild?.FirstChild?.InnerText.Trim()
            };
        }
    }
}