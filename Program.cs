internal class Program
{
  public Program()
  {
    string[,] quadroBatalha = new string[10, 10]; // tamanho do mapa
    int playerPoints = 0; // pontos atuais do jogador
    int jogadas = 15; // 
    int player; //jogador
    int[] lastplayerPoints;  // antigos pontos do jogador
    string[] Cruiser = new string[1];  // cruzador
    string[] AircraftCarrier = new string[10]; // porta aviao 
    string[] TugBoats = new string[2]; // rebocador

    SetCruzador(quadroBatalha);
    SetRebocador(quadroBatalha);
    SetPortaAviao(quadroBatalha);

    Menu(quadroBatalha, jogadas);

    // Console.WriteLine(int.IsPunctuation(playerPoints));
    // Console.WriteLine(int.IsPunctuation(lastplayerPoints)); //sistema de pontuacao nao concluido


  }

  public string VerificaTiro(string[,] quadroBatalha, int linha, int coluna) // verifica a jogada do jogador
  {
    if (quadroBatalha[linha, coluna] == " ")
    {
      return VerificaPosicãoBarcoMaisPerto(quadroBatalha, linha, coluna);
    }
    else if (quadroBatalha[linha, coluna] == "C")
    {
      // Console.WriteLine("Atingiu um Porta Cruzador: {Red}", Console.BackgroundColor);
      // Console.BackgroundColor = ConsoleColor.Red;
      // Console.WriteLine("Atingiu um Porta Cruzador: {Red}", Console.BackgroundColor);
      return "c";
    }
    else if (quadroBatalha[linha, coluna] == "P")
    {
      // Console.WriteLine("Atingiu um Porta Avião: {Red}", Console.BackgroundColor);
      // Console.BackgroundColor = ConsoleColor.Red;
      // Console.WriteLine("Atingiu um Porta Avião: {Red}", Console.BackgroundColor);
      return "p";
    }
    else if (quadroBatalha[linha, coluna] == "R")
    {
      // Console.WriteLine("Atingiu um Porta Rebocador: {Red}", Console.BackgroundColor);
      // Console.BackgroundColor = ConsoleColor.Red;
      // Console.WriteLine("Atingiu um Porta Rebocador: {Red}", Console.BackgroundColor);
      return "r";
    }
    else if (quadroBatalha[linha, coluna] == "r" || quadroBatalha[linha, coluna] == "p" || quadroBatalha[linha, coluna] == "c" ||
    quadroBatalha[linha, coluna] == "1" || quadroBatalha[linha, coluna] == "2" || quadroBatalha[linha, coluna] == "3" ||
    quadroBatalha[linha, coluna] == "M")
    {
      // Console.WriteLine("Não atingiu nenhuma construção: {Green}", Console.BackgroundColor);
      // Console.BackgroundColor = ConsoleColor.Green;
      // Console.WriteLine("Não atingiu nenhuma construção: {Green}", Console.BackgroundColor);
      return "comando dado antes";
    }

    return "Como????";
  }

  public string VerificaPosicãoBarcoMaisPerto(string[,] quadroBatalha, int linha, int coluna)
  {
    string retorno;

    if (linha > 2 && linha < 7 && coluna > 2 && coluna < 7)
    {
      return VerificaTresPosicoes(quadroBatalha, linha, coluna);
    }

    if(coluna == 2 && linha> 2 && linha<7)
    {

    }

  }
#region 
  public static string VerficaParaColuna2(string[,] quadroBatalha, int linha, int coluna)
  { 
    //Verificação para saber se está 1 quadrado em volta
    if (quadroBatalha[linha - 1, coluna] != " " || quadroBatalha[linha + 1, coluna] != " " ||
       quadroBatalha[linha, coluna - 1] != " " || quadroBatalha[linha, coluna + 1] != " ")
    {
      return "1";
    }//Verificação para saber se está 2 quadrado em volta
    else if (quadroBatalha[linha - 2, coluna] == " " || quadroBatalha[linha + 2, coluna] == " " ||
            quadroBatalha[linha, coluna - 2] == " " || quadroBatalha[linha, coluna + 2] == " ")
    {
      return "2";
    }//Verificação para saber se está 3 quadrado em volta
    else if (quadroBatalha[linha + 3, coluna] == " " || quadroBatalha[linha, coluna - 3] == " " || quadroBatalha[linha, coluna + 3] == " ")
    {
      return "3";
    }
    else
    {
      return "M";
      // Console.WriteLine("Errou por muito!");
    }
  }

  public static string VerificaTresPosicoes(string[,] quadroBatalha, int linha, int coluna)
  {
    //Verificação para saber se está 1 quadrado em volta
    if (quadroBatalha[linha - 1, coluna] != " " || quadroBatalha[linha + 1, coluna] != " " ||
       quadroBatalha[linha, coluna - 1] != " " || quadroBatalha[linha, coluna + 1] != " ")
    {
      return "1";
    }//Verificação para saber se está 2 quadrado em volta
    else if (quadroBatalha[linha - 2, coluna] == " " || quadroBatalha[linha + 2, coluna] == " " ||
            quadroBatalha[linha, coluna - 2] == " " || quadroBatalha[linha, coluna + 2] == " ")
    {
      return "2";
    }//Verificação para saber se está 3 quadrado em volta
    else if (quadroBatalha[linha - 3, coluna] == " " || quadroBatalha[linha + 3, coluna] == " " ||
            quadroBatalha[linha, coluna - 3] == " " || quadroBatalha[linha, coluna + 3] == " ")
    {
      return "3";
    }
    else
    {
      return "M";
      // Console.WriteLine("Errou por muito!");
    }
  }
#endregion
  public void Menu(string[,] quadroBatalha, int jogadas)
  {
    //menu Do Jogo
    Console.WriteLine("Bem vindo");

    Console.WriteLine("Você terá 15 jogadas");

    Console.WriteLine("Se você acertar um porta avião, você ganhará 5 pontos");

    Console.WriteLine("Se você acertar um porta rebocador, você ganhará 10 pontos");

    Console.WriteLine("Se você acertar um porta cruzador, você ganhará 15 pontos");

    Console.WriteLine("Boa sorte");
    do
    {
      Console.WriteLine("Escolha uma Posição para jogar (linha coluna)");
      //Método split(retira o espaço)
      string[] Lc = Console.ReadLine().Split(" ");

      int linha = int.Parse(Lc[0]);
      int coluna = int.Parse(Lc[1]);

      string oQueAcertou = VerificaTiro(quadroBatalha, linha, coluna);

      if (oQueAcertou == "comando dado antes")
      {
        Console.WriteLine($"{oQueAcertou}");
        continue;
      }

      quadroBatalha[linha, coluna] = oQueAcertou;

      Mapa(quadroBatalha, false);

      jogadas--;
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

  public void SetCruzador(string[,] quadroBatalha)//Seta onde vai ficar posicionado o Cruzador
  {
    (int, int) tupla = GetPosicaoLivre(quadroBatalha);
    quadroBatalha[tupla.Item1, tupla.Item2] = "C";
  }

  public void SetPortaAviao(string[,] quadroBatalha)//Seta onde vai ficar posicionado o porta aviões
  {
    //TODO: verificar se ja foi sorteada essa posição, se já, sortear outra
    for (int a = 0; a < 10; a++) //Quantidade de porta aviões
    {
      (int, int) tupla = GetPosicaoLivre(quadroBatalha);
      quadroBatalha[tupla.Item1, tupla.Item2] = "P";
    }
  }

  public void SetRebocador(string[,] quadroBatalha)//Seta onde vai ficar posisionado o rebocador
  {
    //TODO: verificar se ja foi sorteada essa posição, se já, sortear outra
    for (int i = 0; i < 2; i++) //Quantidade de rebocadores
    {
      (int, int) tupla = GetPosicaoLivre(quadroBatalha);
      quadroBatalha[tupla.Item1, tupla.Item2] = "R";
    }
  }

  public void Mapa(string[,] quadroBatalha, bool MostrarTudo)
  {

    if (!MostrarTudo)
    {
      
    }
    else
    {
        for (int i = 0; i < quadroBatalha.GetLength(0); i++)
      {
        //Console.WriteLine("----------");
        Console.Write("|");
        for (int j = 0; j < quadroBatalha.GetLength(1); j++)
        {
          Console.Write($"{quadroBatalha[i, j]}|");
        }
        Console.WriteLine();
        Console.WriteLine("----------");
      }
    }

  }

  private static void Main(string[] args)
  {
    var prog = new Program();
  }
}