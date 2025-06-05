using DesafioRocketSeat1.Enum;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DesafioRocketSeat1
{
    public class Program
    {
        /// <summary>
        /// Ponto de entrada do programa. Exibe um menu com opções baseadas no enum Programs,
        /// permite que o usuário selecione uma funcionalidade e executa o método correspondente.
        /// </summary>
        /// <param name="args">Argumentos de linha de comando (não utilizados).</param>
        static void Main(string[] args)
        {
            int OptionSelected;
            
            while (true)
            {
                Console.WriteLine($"{GetBasicInformations()}{Environment.NewLine}");

                Console.WriteLine("Selecione uma das opções para prosseguir (informe o número indicado)");

                foreach (Programs item in System.Enum.GetValues(typeof(Programs)))
                {
                    Console.WriteLine($"{(int)item} - {item.ToString().Replace('_', ' ')}");
                }

                Console.WriteLine();

                string Response = Console.ReadLine();

                int.TryParse(Response, out OptionSelected);              

                if (System.Enum.IsDefined(typeof(Programs), OptionSelected) == false)
                {
                    Console.WriteLine($"Opção informada inválida!{Environment.NewLine}Aperte Enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();

                    continue;
                }

                break;
            }

            if (OptionSelected == (int)Programs.Boas_Vindas)
            {
                Boas_Vindas();
            }
            else if (OptionSelected == (int)Programs.None_Completo)
            {
                None_Completo();
            }
            else if (OptionSelected == (int)Programs.Operacoes_Matematicas)
            {
                Operacoes_Matematicas();
            }
            else if (OptionSelected == (int)Programs.Quantidade_Caracteres)
            {
                Quantidade_Caracteres();
            }
            else if (OptionSelected == (int)Programs.Validador_Placas)
            {
                Validador_Placas();
            }
            else if (OptionSelected == (int)Programs.Formatos_Data)
            {
                Formatos_Data();
            }
        }

        /// <summary>
        /// Solicita o nome do usuário e exibe uma mensagem personalizada de boas-vindas no console.
        /// </summary>
        private static void Boas_Vindas()
        {
            try
            {
                Console.Write($"{GetMessageInitial()}por favor, informe seu nome: ");
               
                string Name = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine($"Olá, {Name}! Seja muito bem-vindo(a)!");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        /// <summary>
        /// Solicita o primeiro nome e o sobrenome do usuário e exibe uma saudação personalizada com o nome completo.
        /// </summary>
        private static void None_Completo()
        {
            try
            {
                Console.Write($"{GetMessageInitial()}por favor, informe seu primeiro nome: ");

                string FirstName = Console.ReadLine();

                Console.Write("Agora informe seu sobrenome: ");

                string SecondName = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine($"Olá, {FirstName} {SecondName}! Seja muito bem-vindo(a)!");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exibe um menu de operações matemáticas disponíveis, permite ao usuário selecionar uma operação,
        /// solicita dois valores numéricos e exibe o resultado da operação escolhida
        /// (soma, subtração, multiplicação, divisão ou média).
        /// </summary>
        private static void Operacoes_Matematicas()
        {
            try
            {
                int OptionSelected;

                while (true)
                {
                    Console.Write($"{GetMessageInitial()}{Environment.NewLine}");
                    Console.WriteLine("Selecione uma das opções para prosseguir (informe o número indicado)");

                    foreach (Operacao item in System.Enum.GetValues(typeof(Operacao)))
                    {
                        Console.WriteLine($"{(int)item} - {item.ToString().Replace('_', ' ')}");
                    }

                    Console.WriteLine();

                    string Response = Console.ReadLine();

                    int.TryParse(Response, out OptionSelected);

                    if (System.Enum.IsDefined(typeof(Operacao), OptionSelected) == false)
                    {
                        Console.WriteLine($"Opção informada inválida!{Environment.NewLine}Aperte Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();

                        continue;
                    }

                    break;
                }

                while (true)
                {
                    Console.Write($"{GetMessageInitial()}por favor, informe o primeiro valor: ");

                    string FirstValue = Console.ReadLine();

                    double.TryParse(FirstValue, out double FirstNumber);

                    if (FirstNumber == 0)
                    {
                        Console.WriteLine($"Valor informado inválido!{Environment.NewLine}Aperte Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();

                        continue;
                    }

                    Console.Write("Agora informe o segundo valor: ");

                    string SecondValue = Console.ReadLine();

                    double.TryParse(SecondValue, out double SecondNumber);

                    if (SecondNumber == 0)
                    {
                        Console.WriteLine($"Segundo valor informado inválido!{Environment.NewLine}Aperte Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();

                        continue;
                    }

                    if (OptionSelected == (int)Operacao.Soma)
                    {
                        Console.WriteLine($"A soma dos valores é: {FirstNumber + SecondNumber}");
                        Console.ReadLine();
                    }
                    else if (OptionSelected == (int)Operacao.Subtracao)
                    {
                        Console.WriteLine($"A subtração dos valores é: {FirstNumber - SecondNumber}");
                        Console.ReadLine();
                    }
                    else if (OptionSelected == (int)Operacao.Multiplicacao)
                    {
                        Console.WriteLine($"A multiplicação dos valores é: {FirstNumber * SecondNumber}");
                        Console.ReadLine();
                    }
                    else if (OptionSelected == (int)Operacao.Divisao)
                    {
                        Console.WriteLine($"A divisão dos valores é: {FirstNumber / SecondNumber}");
                        Console.ReadLine();
                    }
                    else if (OptionSelected == (int)Operacao.Media)
                    {
                        Console.WriteLine($"A média dos valores é: {(FirstNumber + SecondNumber) / 2.0}");
                        Console.ReadLine();
                    }

                    break;
                }
   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Solicita ao usuário que digite um texto e exibe no console
        /// a quantidade total de caracteres presentes na entrada.
        /// </summary>
        private static void Quantidade_Caracteres()
        {
            try
            {
                Console.WriteLine($"{GetMessageInitial()}por favor, digite o texto para exibir seu número de caracteres: ");

                string Total = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine($"O total de caracteres do texto informado são de: {Total.Length}");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Solicita ao usuário que digite uma placa de veículo e verifica
        /// se ela é válida segundo o padrão brasileiro até 2018 (3 letras seguidas de 4 números).
        /// Exibe "Verdadeiro" ou "Falso" no console.
        /// </summary>
        private static void Validador_Placas()
        {
            try
            {
                Console.WriteLine($"{GetMessageInitial()}por favor, digite o número da placa: ");

                string Result = Console.ReadLine();

                bool Validate = Regex.IsMatch(Result, @"^[a-zA-Z]{3}[0-9]{4}$");

                Console.WriteLine(Validate ? "Verdadeiro" : "Falso");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Exibe a data e hora atual em diferentes formatos no console:
        /// completo, apenas data, apenas hora e data com mês por extenso.
        /// </summary>
        private static void Formatos_Data()
        {
            try
            {
                DateTime DataAtual = DateTime.Now;

                Console.WriteLine($"{GetMessageInitial()} seja bem-vindo(a)");

                Console.WriteLine();

                Console.WriteLine($"Formato Completo: {DataAtual}");
                Console.WriteLine($"Apenas Data: {string.Format("{0:dd/MM/yyyy}" ,DataAtual)}");
                Console.WriteLine($"Apenas hora no formato 24 horas: {string.Format("{0:HH:mm:ss}", DataAtual)}");
                Console.WriteLine($"Data com mês por extenso: {DataAtual:dd 'de' MMMM 'de' yyyy}");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma string com o país (com base na cultura atual do sistema)
        /// seguido da data e hora atual formatadas.
        /// </summary>
        /// <returns>Exemplo: "Brasil, 04 de junho de 2025 14:30"</returns>
        private static string GetBasicInformations()
        {
            try
            {
                string Return = $"{new RegionInfo(CultureInfo.CurrentCulture.Name).DisplayName}, {DateTime.Now:dd 'de' MMMM 'de' yyyy HH:mm}";

                return Return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma saudação ("Bom dia", "Boa tarde" ou "Boa noite")
        /// com base na hora atual do sistema.
        /// </summary>
        /// <returns>Saudação apropriada para a hora atual.</returns>
        public static string GetMessageInitial()
        {
            try
            {
                int hour = DateTime.Now.Hour;

                if (hour >= 6 && hour < 12)
                {
                    return "Bom dia, ";
                }
                else if (hour >= 12 && hour < 18)
                {
                    return "Boa tarde, ";
                }
                else
                {
                    return "Boa noite, ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }
    }
}
