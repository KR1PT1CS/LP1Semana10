using System;

namespace CharSets
{
    public class Program
    {
        private static void Main(string[] args)
        {
            HashSet<char> caracteres = new HashSet<char>();
        try
        {
            foreach (var ficheiro in args)
            {
                if (!File.Exists(ficheiro))
                {
                    Console.Error.WriteLine($"Erro: Ficheiro '{ficheiro}' não encontrado.");
                    return 1;
                }

                int linhasInvalidas = 0;
                foreach (var linha in File.ReadLines(ficheiro))
                {
                    if (linha.Length != 1)
                    {
                        linhasInvalidas++;
                        if (linhasInvalidas > 1)
                        {
                            Console.Error.WriteLine("Erro: Mais de uma linha com mais de um carácter.");
                            return 1;
                        }
                    }
                    else
                    {
                        caracteres.Add(linha[0]);
                    }
                }
            }

            var ordenado = caracteres.OrderBy(c => c);
            foreach (var c in ordenado)
            {
                Console.WriteLine(c);
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro: {ex.Message}");
            return 1;
        }
    }
}