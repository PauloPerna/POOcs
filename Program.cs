using System;

namespace ExercicioPOO{
    public class Program{
        static void Main(string[] args){
            List<Correntista> testeCorrentistas = new List<Correntista>();
            bool stop = false;
            int cpf;
            while(!stop){
                Console.WriteLine("Entre cpf correntista:");
                int.TryParse(Console.ReadLine(), out cpf);
                testeCorrentistas.Add(new Correntista(cpf));
                Console.WriteLine("Stop? <1/0>");
                stop = Console.ReadLine() == "1";
            }

            int input;
            int index;
            decimal valor;
            Correntista correntista;
            string descricaoDespesa;
            stop = false;
            while(!stop){
                Console.WriteLine("Qual funcionalidade vamos testar?");
                Console.WriteLine("1 - buscaValorSaldo");
                Console.WriteLine("2 - adicionarSaldo");
                Console.WriteLine("3 - pagarConta");
                Console.WriteLine("4 - encontraCorrentista");
                Console.WriteLine("5 - inserirDespesa");
                Console.WriteLine("6 - somarDespesas");
                Console.WriteLine("7 - Sair");
                int.TryParse(Console.ReadLine(),out input);
                switch(input){
                    case 1:
                        Console.WriteLine($"Entre o índice do correntista 0/{testeCorrentistas.Count - 1}");
                        int.TryParse(Console.ReadLine(), out index);
                        decimal saldo = testeCorrentistas[index].buscaValorSaldo();
                        Console.WriteLine($"O saldo é {saldo.ToString("C")}");
                        break;
                    case 2:
                        Console.WriteLine($"Entre o índice do correntista 0/{testeCorrentistas.Count - 1}");
                        int.TryParse(Console.ReadLine(), out index);
                        Console.WriteLine("Entre o valor para adicionar ao saldo:");
                        decimal.TryParse(Console.ReadLine(), out valor);
                        testeCorrentistas[index].adicionarSaldo(valor);
                        Console.WriteLine("Saldo adicionado!");
                        break;
                    case 3:
                        Console.WriteLine($"Entre o índice do correntista 0/{testeCorrentistas.Count - 1}");
                        int.TryParse(Console.ReadLine(), out index);
                        Console.WriteLine("Entre o valor da conta que deseja pagar");
                        decimal.TryParse(Console.ReadLine(), out valor);
                        if(testeCorrentistas[index].pagarConta(valor)){
                            Console.WriteLine("Conta paga!"); 
                        }
                        break;
                    case 4:
                        Console.WriteLine("Entre o cpf do correntista que deseja encontrar:");
                        int.TryParse(Console.ReadLine(), out cpf);
                        correntista = Correntista.encontraCorrentista(testeCorrentistas,cpf);
                        if(correntista == null){
                            Console.WriteLine("Não foi encontrado nenhum correntista com esse cpf");
                        } else {
                            Console.WriteLine($"Encontramos o correntista com saldo de {correntista.buscaValorSaldo().ToString("C")}");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Entre o índice do correntista 0/{testeCorrentistas.Count - 1}");
                        int.TryParse(Console.ReadLine(), out index);
                        Console.WriteLine("Insira a descrição da despesa:");
                        descricaoDespesa = Console.ReadLine();
                        Console.WriteLine("Insira o valor da despesa:");
                        decimal.TryParse(Console.ReadLine(),out valor);
                        testeCorrentistas[index].inserirDespesa(descricaoDespesa, valor);
                        Console.WriteLine("Despesa inserida!");
                        break;
                    case 6:
                        Console.WriteLine($"Entre o índice do correntista 0/{testeCorrentistas.Count - 1}");
                        int.TryParse(Console.ReadLine(), out index);
                        Console.WriteLine($"A soma das despesas do correntista é {testeCorrentistas[index].somarDespesas().ToString("C")}");
                        break;
                    case 7:
                        stop = true;
                        Console.WriteLine("Até mais! :D");
                        break;
                    default:
                        Console.WriteLine("Não entendi... Poderia repetir?");
                        break;
                }
            }
        }
    }
}