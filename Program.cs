namespace jogo_da_forca_Academia_Programador
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] frutas = {
            "ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA",
            "BACABA", "BACURI", "BANANA", "CAJA", "CAJU",
            "CARAMBOLA", "CUPUACU", "GRAVIOLA", "GOIABA",
            "JABUTICABA", "JENIPAPO", "MACA", "MANGABA",
            "MANGA", "MARACUJA", "MURICI", "PEQUI", "PITANGA",
            "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"
        };

            Random random = new Random();

            while (true)
            {
                string palavra = frutas[random.Next(frutas.Length)];
                char[] letrasDescobertas = new char[palavra.Length];
                for (int i = 0; i < letrasDescobertas.Length; i++)
                    letrasDescobertas[i] = '_';

                int erros = 0;
                List<char> letrasTentadas = new List<char>();

                while (erros < 5 && new string(letrasDescobertas) != palavra)
                {
                    Console.Clear();
                    DesenharForca(erros);
                    Console.WriteLine("Letras tentadas: " + string.Join(", ", letrasTentadas));
                    Console.WriteLine("Palavra: " + string.Join(" ", letrasDescobertas));

                    Console.Write("Digite uma letra ou a palavra completa: ");
                    string tentativa = Console.ReadLine().ToUpper();

                    if (tentativa.Length == 1)
                    {
                        char letra = tentativa[0];
                        if (letrasTentadas.Contains(letra))
                        {
                            Console.WriteLine("Letra já tentada!");
                            continue;
                        }

                        letrasTentadas.Add(letra);

                        if (palavra.Contains(letra))
                        {
                            for (int i = 0; i < palavra.Length; i++)
                                if (palavra[i] == letra)
                                    letrasDescobertas[i] = letra;
                        }
                        else
                        {
                            erros++;
                        }
                    }
                    else
                    {
                        if (tentativa == palavra)
                        {
                            letrasDescobertas = palavra.ToCharArray();
                        }
                        else
                        {
                            erros++;
                            Console.WriteLine("Palavra incorreta!");
                        }
                    }
                }

                Console.Clear();
                if (erros >= 5)
                {
                    DesenharForca(5);
                    Console.WriteLine("Você perdeu! A palavra era: " + palavra);
                }
                else
                {
                    Console.WriteLine("Parabéns! Você acertou: " + palavra);
                }

                Console.Write("Jogar novamente? (S/N): ");
                if (Console.ReadLine().ToUpper() != "S") break;
            }
        }

        static void DesenharForca(int erros)
        {
            string[] partes = {
            "  o  ",
            " /|\\ ",
            " / \\ "
        };

            Console.WriteLine("  _______");
            Console.WriteLine("  |     |");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("  |    ");
                if (erros > i) Console.WriteLine(partes[i]);
                else Console.WriteLine();
            }

            Console.WriteLine("  |");
            Console.WriteLine("__|__");
            Console.WriteLine("Erros: " + erros + "/5\n");
        }
    }
}
