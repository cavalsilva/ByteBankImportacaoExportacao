﻿using ByteBankImportacaoExportacao.Modelos;
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

            //Bloco de leitura de arquivos
            var arquivo = "contas.txt";
            
            //Quando existir um using abaixo o outro, não é necessário ter {} nos acimas
            using (var fluxoDoArquivo = new FileStream(arquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    var msg = $"{contaCorrente.Titular.Nome}: Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}. Saldo: {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }
            }


            //Bloco de escrita de arquivos via console
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fs.Write(buffer, 0, bytesLidos);
                    fs.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }
            }

        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.',','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }

        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                escritor.Write("456,78945,4785.50,Ricardo Silva");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100000000; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    // O comando abaixo escreve o conteúdo no arquivo
                    escritor.Flush();

                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter p adicionar mais uma!");
                    Console.ReadLine();
                }
            }
        }

    }
}
