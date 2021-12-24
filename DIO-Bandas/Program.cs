using System;
using DIO.Bandas.Interfaces;
using DIO.Bandas;


namespace DIO.Bandas
{
    class Program
    {
        static BandasRepositorio repositorio = new BandasRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarBandas();
						break;
					case "2":
						InserirBanda();
						break;
					case "3":
						AtualizarBanda();
						break;
					case "4":
						ExcluirBanda();
						break;
					case "5":
						VisualizarBanda();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indiceBanda = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceBanda);
		}

        private static void VisualizarBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indiceBanda = int.Parse(Console.ReadLine());

			var banda = repositorio.RetornaPorId(indiceBanda);

			Console.WriteLine(banda);
		}

        private static void AtualizarBanda()
		{
			Console.Write("Digite o id da banda: ");
			int indiceBanda = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Banda: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Banda: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Banda: ");
			string entradaDescricao = Console.ReadLine();

			Banda atualizaBanda = new Banda(id: indiceBanda,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceBanda, atualizaBanda);
		}
        private static void ListarBandas()
		{
			Console.WriteLine("Listar bandas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma banda cadastrada.");
				return;
			}

			foreach (var banda in lista)
			{
                var excluido = banda.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", banda.retornaId(), banda.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirBanda()
		{
			Console.WriteLine("Inserir nova banda");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Banda: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Banda: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Banda: ");
			string entradaDescricao = Console.ReadLine();

			Banda novaBanda = new Banda(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaBanda);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bandas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Bandas");
			Console.WriteLine("2- Inserir nova banda");
			Console.WriteLine("3- Atualizar banda");
			Console.WriteLine("4- Excluir banda");
			Console.WriteLine("5- Visualizar banda");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
