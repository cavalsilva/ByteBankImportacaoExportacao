using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var arquivo = "contas.txt";

            //Quando existir um using abaixo o outro, não é necessário ter {} nos acimas
            using (var fluxoDoArquivo = new FileStream(arquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
            }

            Console.ReadLine();
        }

        //static void EscreverBuffer(byte[] buffer, int bytesLidos)
        //{
        //    var encoding = new UTF8Encoding();
        //    var texto = encoding.GetString(buffer, 0, bytesLidos);

        //    Console.Write(texto);
        //}
    }
}
