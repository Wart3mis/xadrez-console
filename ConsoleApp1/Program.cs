﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno:" + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] possicoesPossiveis = partida.Tabuleiro.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tabuleiro, possicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }

                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Aperte ENTER e selecione uma nova peça!");
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}