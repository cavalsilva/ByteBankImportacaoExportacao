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

            var fluxoDoArquivo = new FileStream(arquivo, FileMode.Open);

            var buffer = new byte[1024];

            var quantidadeDeBytesLidos = -1;
            while (quantidadeDeBytesLidos != 0)
            {
                quantidadeDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                EscreverBuffer(buffer);
            }

            Console.ReadLine();
        }

        static void EscreverBuffer(byte[] buffer)
        {
            var encoding = new UTF8Encoding();
            var texto = encoding.GetString(buffer);

            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}
