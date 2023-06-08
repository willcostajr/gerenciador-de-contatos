using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos
{
    public class Contato
    {
        //Propriedades do Ojeto
        #region
        public string Nome { get;  set; }
        
        public string Sobrenome { get; set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        #endregion

        //Propriedades da classe
        public static int TotalContatos { get; private set; }

        
        //Verifica formato e insere telefone
        public void InserirTelefone(string telefone)
        {
            bool verificar = Regex.IsMatch(telefone, "^[(]?([0-9]{2})?[)]?[9]?[0-9]{4}[-]?[0-9]{4}$");
            if (verificar) { this.Telefone = telefone; Console.WriteLine("Telefone salvo com sucesso!"); Console.ReadKey(); }
            else { throw new TelefoneException("Formato de telefone inválido!"); }
        }

        //Verifica formato e insere e-mail
        public void InserirEmail(string email)
        {
            bool verificacao = Regex.IsMatch(email, "^[a-z_0-9.]+@[a-z_0-9]+.[a-z_0-9]+.([a-z_0-9]+)?$");
            if (verificacao) { this.Email = email; Console.WriteLine("E-mail salvo com sucesso!"); Console.ReadKey(); }
            else { throw new EmailException("Formato de e-mail inválido!"); }
        }

        public void EditarNome(string nome)
        {
            this.Nome = nome;
            Console.WriteLine("Nome salvo com sucesso;");
            Console.ReadKey();
        }

        public void EditarSobrenome(string sobrenome)
        {
            this.Sobrenome = sobrenome;
            Console.WriteLine("Sobrenome salvo com sucesso!");
            Console.ReadKey();
        }

        public void ExibirContato()
        {
            Console.WriteLine($"Nome: {Nome}\n" +
                $"Sobrenome: {Sobrenome}\n" +
                $"Telefone: {Telefone}\n" +
                $"E-mail: {Email}");
        }

    }
}
