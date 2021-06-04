using System.Text.RegularExpressions;

namespace MED.Core.DomainObjects
{
    public class Cnpj
    {
        public const int CnpjMaxLength = 14;
        public string Numero { get; private set; }

        public Cnpj(string numero)
        {
            if (!Validar(numero)) throw new DomainException("CNPJ inválido");
            Numero = numero;
        }

        public static bool Validar(string cnpj)
        {
            // Valida tanto 12.345.678/0001-00 quanto 12345678000100
            var regexCpnj = new Regex(@"(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)");
            return regexCpnj.IsMatch(cnpj);
        }
        public void Atualizar(string numero)
        {
            Numero = numero;
        }

    }
}