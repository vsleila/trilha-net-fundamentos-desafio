using System.Collections;
using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0, precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao Sistema de Estacionamento!");
precoInicial = LerDecimalComTratamento("Digite a taxa fixa:");
precoPorHora = LerDecimalComTratamento("Digite o preço a ser cobrado por hora:");

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);
Console.Clear();

bool exibirMenu = true;
while (exibirMenu)
{
    string menuTexto = "Digite a sua opção no menu:\n" +
                        "1 - Cadastrar veículo\n" +
                        "2 - Remover veículo\n" +
                        "3 - Lista de veículos estacionados\n" +
                        "4 - Encerrar programa";
    Console.WriteLine(menuTexto);

    string opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            es.CadastrarVeiculoComTratamento();
            break;

        case "2":
            es.RemoverVeiculoComTratamento();
            break;

        case "3":
            es.ListaDeVeiculos();
            break;

        case "4":
            Console.WriteLine("Você deseja realmente encerrar o programa? Se 'Sim', digite 'S', se 'Não', digite qualquer tecla");
            string tecla = Console.ReadLine().ToUpper();
            if (tecla == "S")
            {
                exibirMenu = false;
                Console.WriteLine("O programa foi encerrado!");
                break;
            }
            else
            {
                Console.Clear();
                exibirMenu = true;
            }
            break;

        default:
            Console.WriteLine("Opção inválida!");
            Console.ReadLine();
            Console.Clear();
            break;
    }
}


//Tratamento de exceçoes -----------------------------------

static decimal LerDecimalComTratamento(string mensagem)
{
    Console.WriteLine(mensagem);
    try
    {
        return Convert.ToDecimal(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro de formato. Certifique-se de inserir um número válido.");
        return LerDecimalComTratamento(mensagem);
    }
    catch (OverflowException)
    {
        Console.WriteLine("O valor inserido é muito grande. Tente novamente.");
        return LerDecimalComTratamento(mensagem);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro ao ler: {ex.Message}");
        return LerDecimalComTratamento(mensagem);
    }
}


