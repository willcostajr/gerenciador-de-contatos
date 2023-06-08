using GerenciamentoDeContatos;
class Program
{
    public static List<Contato> listaDeContatos = new List<Contato>();
    public static void Main(string[] args)
    {
        IniciarGerenciador();
    }

    public static void IniciarGerenciador()
    {        
        int a = ExibirMenuPrincipal();
        switch (a)
        {
            case 0:
                Contato contato = new Contato();
                InserirContato(contato);
                break;
            case 1:
                SelecionarContato("editado");
                break;
            case 2:
                ListarContatos();
                break;
            case 3:
                SelecionarContato("excluído");
                break;
            case 4:
                SelecionarContato("exibido");
                break;
            case 5:
                Console.WriteLine("Acabou aqui!");
                Console.ReadLine();
                Environment.Exit(0);
                break;
            default:
                IniciarGerenciador();
                break;
        }
        IniciarGerenciador();
    }

    public static int ExibirMenuPrincipal()
    {
        Console.Clear();
        ExibirTitulo();

        Console.WriteLine("[0] Inserir novo contato" +
            "\n[1] Editar contato existente" +
            "\n[2] Listar contatos" +
            "\n[3] Deteletar contato" +
            "\n[4] Exibir informações do contato" +
            "\n[5] Sair");
        Console.WriteLine();
        Console.Write("Digite a opção desejada: ");
        int a = int.Parse(Console.ReadLine());
        return a;
    }

    public static void ExibirMenu0(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();
        
        Console.WriteLine("Inserir: " +
                "\n[0] E-mail" +
                "\n[1] Telefone" +
                "\n[2] Voltar ao menu principal");
        Console.Write("Digite a opção desejada: ");
        int a = int.Parse(Console.ReadLine());
        
        switch (a)
        {
            case 0: InserirEmail(contato); break;
            case 1: InserirTelefone(contato); break;
            case 2: IniciarGerenciador(); break;
            default: Console.WriteLine("Opçao Inválida!"); ExibirMenu0(contato); break;
        }

    }

    public static void SelecionarContato(string n)
    {
        Console.Clear();
        ExibirTitulo();
            ;
        Console.WriteLine($"Informe o contato a ser {n}: \n");
        foreach(Contato contato in listaDeContatos)
        {
            Console.WriteLine($"[{listaDeContatos.IndexOf(contato)}] {contato.Nome} {contato.Sobrenome}");
        }
        
        Console.Write("\nDigite sua opção: ");
        int a = int.Parse(Console.ReadLine());
        if (n == "editado")
            Editar(listaDeContatos[a]);
        else if (n == "excluído")
            Deletar(listaDeContatos[a]);
        else if (n == "exibido")
            Exibir(listaDeContatos[a]);
        else
            IniciarGerenciador();
    }

    public static void InserirContato(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();
        
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Sobrenome: ");
        string sobrenome = Console.ReadLine();
        contato.Nome = nome;
        contato.Sobrenome = sobrenome;
        listaDeContatos.Add(contato);
        ExibirMenu0(contato) ;
    }

    public static void InserirEmail(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();

        Console.Write("E-mail: ");
        string email = Console.ReadLine();
        try { contato.InserirEmail(email); }
        catch (EmailException ex)
        { Console.WriteLine(ex.Message); Console.ReadKey(); }
        ExibirMenu0(contato);
    }

    public static void InserirTelefone(Contato contato)
    {
        Console.Clear() ;
        ExibirTitulo();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        try { contato.InserirTelefone(telefone); }
        catch (TelefoneException ex) { Console.WriteLine(ex.Message); Console.ReadKey(); }
        ExibirMenu0(contato);
    }

    public static void ListarContatos()
    {
        Console.Clear();
        ExibirTitulo();

        foreach (Contato contato in listaDeContatos)
        {
            Console.WriteLine($"{contato.Nome} {contato.Sobrenome}");
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
        IniciarGerenciador();
    }

    public static void Editar(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();

        Console.WriteLine($"O que deseja alterar no contato {contato.Nome} {contato.Sobrenome}?" +
            $"\n[0] Nome" +
            $"\n[1] Sobrenome" +
            $"\n[2] Telefone" +
            $"\n[3] E-mail" +
            $"\n[4] Voltar ao menu principal");
        Console.WriteLine();
        Console.Write("Digite sua opção: ");
        switch (int.Parse(Console.ReadLine()))
        {
            case 0:
                Console.Clear();
                ExibirTitulo();

                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                contato.EditarNome(nome);
                Editar(contato);
                break;
            case 1:
                Console.Clear();
                ExibirTitulo();

                Console.Write("Sobrenome: ");
                string sobrenome = Console.ReadLine();
                contato.EditarSobrenome(sobrenome);
                Editar(contato);
                break;
            case 2:
                InserirTelefone(contato);
                break;
            case 3:
                InserirEmail(contato);
                break;
            case 4:
                IniciarGerenciador();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                Editar(contato);
                break;

        }

    }
    
    public static void Deletar(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();

        Console.WriteLine($"Deseja realmente excluir o contato {contato.Nome} " +
            $"{contato.Sobrenome}?\n");
        Console.Write("[0] Sim \n[1] Não\n");
        int x =int.Parse(Console.ReadLine());
        if (x == 0)
        {
            listaDeContatos.Remove(contato);
            Console.WriteLine("Contato excluído!");

        }
            Console.WriteLine("Digite uma tecla para voltar ao menu inicical.");
            Console.ReadKey();
            IniciarGerenciador();
    }

    public static void Exibir(Contato contato)
    {
        Console.Clear();
        ExibirTitulo();

        contato.ExibirContato();

        Console.WriteLine("\nDigite uma tecla para voltar ao menu inicial.");
        Console.ReadKey();
        IniciarGerenciador();
    }

    public static void ExibirTitulo()
    {
        string titulo = "Gerenciador de Contatos";
        int x = titulo.Length;
        string asteriscos = string.Empty.PadLeft(x, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
}