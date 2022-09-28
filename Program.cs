internal class Program
{
    public Program()
    {
        string[,] quadroBatalha = new string[10, 10]; // tamanho do mapa
        int playerPoints = 0; // pontos atuais do jogador
        int jogadas = 15; // 
        int player; //jogador
        int[] lastplayerPoints;  // antigos pontos do jogador
        int[] Cruiser = new int[1];  // cruzador
        string[] AircraftCarrier = new string[10]; // porta aviao 
        int[] TugBoats = new int[2]; // rebocador
        
        // Console.WriteLine(int.IsPunctuation(playerPoints));
        // Console.WriteLine(int.IsPunctuation(lastplayerPoints)); //sistema de pontuacao nao concluido


    }

    // public void Teste(string[] AircraftCarrier)
    // {
    //     //2 3

    //     foreach(string item in AircraftCarrier)
    //     {
    //         string[]Lc= item.Split(" ");

    //         string linha = Lc[0];
    //         string coluna = Lc[1];

    //        if(quadro[linha,coluna]==" ");
    //        {
    //             quadro[linha,coluna]="C";
    //        }
    //     }
    // }

    public void VerificaTiro(string[,] quadroBatalha, int linha, int coluna) // verifica a jogada do jogador
    {
        if (quadroBatalha[linha, coluna] == " ")
        {

        }
        else if (quadroBatalha[linha, coluna] == "c")
        {
            Console.WriteLine("Atingiu um Porta Cruzador: {Red}", Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Atingiu um Porta Cruzador: {Red}", Console.BackgroundColor);
        }
        else if (quadroBatalha[linha, coluna] == "p")
        {
            Console.WriteLine("Atingiu um Porta Avião: {Red}", Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Atingiu um Porta Avião: {Red}", Console.BackgroundColor);
        
        }
        else if (quadroBatalha[linha, coluna] == "r")
        {
            Console.WriteLine("Atingiu um Porta Rebocador: {Red}", Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Atingiu um Porta Rebocador: {Red}", Console.BackgroundColor);
        }
        else if (quadroBatalha[linha, coluna] == "n")
        {
            Console.WriteLine("Não atingiu nenhuma construção: {Green}", Console.BackgroundColor);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Não atingiu nenhuma construção: {Green}", Console.BackgroundColor);
        }
    
    
    }
    
    public string VerificaPosicãoBarcoMaisPerto(string[,] quadroBatalha, int linha, int coluna)
    {
        string numero;
        //Verificação para saber se está 1 quadrado em volta
        if (quadroBatalha[linha - 1, coluna] == "p" || quadroBatalha[linha - 1, coluna] == "c" || quadroBatalha[linha - 1, coluna] == "r" ||
           quadroBatalha[linha + 1, coluna] == "p" || quadroBatalha[linha + 1, coluna] == "c" || quadroBatalha[linha + 1, coluna] == "r" ||
           quadroBatalha[linha, coluna - 1] == "p" || quadroBatalha[linha, coluna - 1] == "c" || quadroBatalha[linha, coluna - 1] == "r" ||
           quadroBatalha[linha, coluna + 1] == "p" || quadroBatalha[linha, coluna + 1] == "c" || quadroBatalha[linha, coluna + 1] == "r")
        {
            return "1";
        }//Verificação para saber se está 2 quadrado em volta
        else if (quadroBatalha[linha - 2, coluna] == "p" || quadroBatalha[linha - 2, coluna] == "c" || quadroBatalha[linha - 2, coluna] == "r" ||
                quadroBatalha[linha + 2, coluna] == "p" || quadroBatalha[linha + 2, coluna] == "c" || quadroBatalha[linha + 2, coluna] == "r" ||
                quadroBatalha[linha, coluna - 2] == "p" || quadroBatalha[linha, coluna - 2] == "c" || quadroBatalha[linha, coluna - 2] == "r" ||
                quadroBatalha[linha, coluna + 2] == "p" || quadroBatalha[linha, coluna + 2] == "c" || quadroBatalha[linha, coluna + 2] == "r")
        {
            return "2";
        }//Verificação para saber se está 3 quadrado em volta
        else if (quadroBatalha[linha - 3, coluna] == "p" || quadroBatalha[linha - 3, coluna] == "c" || quadroBatalha[linha - 3, coluna] == "r" ||
                quadroBatalha[linha + 3, coluna] == "p" || quadroBatalha[linha + 3, coluna] == "c" || quadroBatalha[linha + 3, coluna] == "r" ||
                quadroBatalha[linha, coluna - 3] == "p" || quadroBatalha[linha, coluna - 3] == "c" || quadroBatalha[linha, coluna - 3] == "r" ||
                quadroBatalha[linha, coluna + 3] == "p" || quadroBatalha[linha, coluna + 3] == "c" || quadroBatalha[linha, coluna + 3] == "r")
        {
            return "3";
        }
        else{
            return "M";
            Console.WriteLine("Errou por muito!");
        }
    }

    public void Menu(int jogadas)
    {
        //menu Do Jogo
        Console.WriteLine("Bem vindo");
        do
        {
            Console.WriteLine("Escolha uma Posição para jogar (linha coluna)");
            //Método split(retira o espaço)
            string[] Lc = Console.ReadLine().Split(" ");

            int linha = int.Parse(Lc[0]);
            int coluna = int.Parse(Lc[1]);


        Console.WriteLine("Você terá 15 jogadas");
        
        Console.WriteLine("Se você acertar um porta avião, você ganhará 5 pontos");
        
        Console.WriteLine("Se você acertar um porta rebocador, você ganhará 10 pontos");
        
        Console.WriteLine("Se você acertar um porta cruzador, você ganhará 15 pontos");
        
        Console.WriteLine("Boa sorte");

        }
        while (jogadas > 0);
       
    }

    public void PrencherPosicoesCampo(string[,] quadroBatalha) // linhas e colunas da batalha anval
    {
        //carrega o array com strings formatadas ("").
        for (int i = 0; i < quadroBatalha.GetLength(0); i++)
        {
            for (int j = 0; j < quadroBatalha.GetLength(1); j++)
            {
                quadroBatalha[i, j] = " ";
            }
        }
    }

    public int GetRandomPosition(int max) //não usar, usado somente para o GetPosicaoLivre 
    {
        var random = new Random();
        return random.Next(max);
    }

    public (int, int) GetPosicaoLivre(string[,] quadroBatalha)
    {
        int i = -1;
        int j = -1;

        do
        {
            i = GetRandomPosition(10);
            j = GetRandomPosition(10);
        } while (quadroBatalha[i, j] != " ");

        return (i, j);
    }

    public void SetCruzador(ref string[,] quadroBatalha)//Seta onde vai ficar posicionado o Cruzador
    {
        (int, int) tupla = GetPosicaoLivre(quadroBatalha);
        quadroBatalha[tupla.Item1, tupla.Item2] = "c";
    }

    public void SetPortaAviao(ref string[,] quadroBatalha)//Seta onde vai ficar posicionado o porta aviões
    {
        //TODO: verificar se ja foi sorteada essa posição, se já, sortear outra
        for (int a = 0; a < 10; a++) //Quantidade de porta aviões
        {
            (int, int) tupla = GetPosicaoLivre(quadroBatalha);
            quadroBatalha[tupla.Item1, tupla.Item2] = "p";
        }
    }

    public void SetRebocador(ref string[,] quadroBatalha)//Seta onde vai ficar posisionado o rebocador
    {
        //TODO: verificar se ja foi sorteada essa posição, se já, sortear outra
        for (int i = 0; i < 2; i++) //Quantidade de rebocadores
        {
            (int, int) tupla = GetPosicaoLivre(quadroBatalha);
            quadroBatalha[tupla.Item1, tupla.Item2] = "c";
        }
    }

    public void Mapa(){
        string[,] quadro = new string[10, 10];

        for (int i = 0; i < quadro.GetLength(0); i++)
        {
            //Console.WriteLine("----------");
            Console.Write("|");
            for (int j = 0; j < quadro.GetLength(1); j++)
            {
                Console.Write($"{quadro[i,j]}|");
            }
            Console.WriteLine();
            Console.WriteLine("----------");
        }
    }

    private static void Main(string[] args)
    {
        var prog = new Program();
    }
}