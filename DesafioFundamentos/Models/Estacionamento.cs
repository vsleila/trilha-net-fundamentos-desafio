using System.ComponentModel;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void CadastrarVeiculoComTratamento()
        {
            Console.WriteLine("A opção: 'Cadastrar Veículo' foi selecionada!");
            Console.WriteLine("Digite a placa do veículo para cadastrar:");

            try
            {
                string placa = Console.ReadLine().ToUpper();
                if (placa.Length == 6)
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo de {placa} cadastrado com sucesso!\n" +
                    "Tecle 'enter' para voltar ao menu de opções.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("A placa do veículo está incorreta, tente novamente.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao cadastrar o veículo: {ex.Message}.");
            }
        }

        public void RemoverVeiculoComTratamento()
        {
            Console.WriteLine("A opção: 'Remover veículo' foi selecionada!");

            if (veiculos.Count > 0)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                try
                {
                    string placa = Console.ReadLine();

                    if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        decimal horas = Convert.ToDecimal(Console.ReadLine());
                        decimal valorTotal = precoInicial + (precoPorHora * horas);
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal} reais.\n" +
                        "Tecle 'enter' para voltar ao menu principal.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está na lista. Confira se digitou a placa corretamente.");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao remover o veículo: {ex.Message}");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Não há veículos para remover!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void ListaDeVeiculos()
        {
            Console.WriteLine("A opção: 'Lista de veículos' foi selecionada!");

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}


