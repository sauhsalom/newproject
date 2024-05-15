

string mensagemBoasVindas = ("Bem vindos a Sreem Sound");
//List<string> listaDasBandas = new List<string> { "U2", "Red Hot" };

Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
BandasRegistradas.Add("link park", new List<int> { 10, 8, 6 });
BandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░░███╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░████║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔████╔██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚██╔╝██║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚═╝░██║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░░░░╚═╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemBoasVindas);

}

void ExibirOpcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar uma banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para mostrar a média das bandas");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaDasBandas();
            break;
        case -1:
            Console.WriteLine("Você escolheu a opção " + opcaoEscolhidaNumerica);
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }

    void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro da banda");
        string nomeDaBanda = Console.ReadLine()!;
        BandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    }

    void MostrarBandasRegistradas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

        //for (int i = 0; i < listaDasBandas.Count; i++)
        //{
        //Console.WriteLine($"Banda: {listaDasBandas[i]}");
        //}

        foreach (string banda in BandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda} ");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    void AvaliarUmaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar uma banda");
        Console.Write("Digite o nome da banda que quer avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(Console.ReadLine()!);
            BandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"\n A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
            Thread.Sleep(4000);
            Console.Clear();
            ExibirOpcoesMenu();
        }

        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar ao menu inicial");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesMenu();
        }
    }

    void MediaDasBandas()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir Média Das bandas");
        Console.WriteLine("Qual banda deseja saber a média: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandasRegistradas.ContainsKey(nomeDaBanda))
        {
            List<int> notasDasBandas = BandasRegistradas[nomeDaBanda];
            Console.WriteLine($"\n A média da banda {nomeDaBanda} é {notasDasBandas.Average()}.");
            Console.WriteLine("Digite qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesMenu();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar ao menu inicial");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesMenu();
        }

    }



}


ExibirOpcoesMenu();
