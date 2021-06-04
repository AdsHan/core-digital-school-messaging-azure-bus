using System.Text.RegularExpressions;

namespace MED.Core.DomainObjects
{
    public class Telefone
    {
        public const int TelefoneMaxLength = 13;

        public string Numero { get; private set; }

        public Telefone(string numero)
        {
            if (!Validar(numero)) throw new DomainException("Telefone inválido");
            Numero = numero;
        }

        public static bool Validar(string telefone)
        {
            // Valida qualquer telefone ou celular, com ou sem DDD. O traço é opcional. Sem parênteses.
            var regexTelefone = new Regex(@"(^[0-9]{2})?(\s|-)?(9?[0-9]{4})-?([0-9]{4}$)");
            return regexTelefone.IsMatch(telefone);
        }

        public void Atualizar(string numero)
        {
            Numero = numero;
        }

    }
}