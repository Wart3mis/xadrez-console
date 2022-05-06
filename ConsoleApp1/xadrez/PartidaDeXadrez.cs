using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
{
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(p, destino);
        }
        
        private void colocarPecas()
        {
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).toPosicao());
            Tabuleiro.colocarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).toPosicao());
            Tabuleiro.colocarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).toPosicao());

        }
    }
}
