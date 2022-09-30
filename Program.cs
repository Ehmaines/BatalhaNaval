internal class Program
{
  public Program()
  {
    string[,] quadroBatalha = new string[10, 10]; // tamanho do mapa
    int pontos = 0; // pontos atuais do jogador
    int jogadas = 15; //
    string opcao;

    do
    {
      PrencherPosicoesCampo(quadroBatalha);

      SetCruzador(quadroBatalha);
      SetRebocador(quadroBatalha);
      SetPortaAviao(quadroBatalha);

      Menu(quadroBatalha, jogadas, ref pontos);

      Console.WriteLine("Deseja Jogar Novamente?");
      Console.WriteLine("Digite 1 para continuar");
      Console.WriteLine("Digite 2 para sair");
      opcao = Console.ReadLine();
    }
    while (opcao != "2");

    // Console.WriteLine(int.IsPunctuation(playerPoints));
    // Console.WriteLine(int.IsPunctuation(lastplayerPoints)); //sistema de pontuacao nao concluido


  }
  #region Verificações
  public string VerificaTiro(string[,] quadroBatalha, int linha, int coluna, ref int pontos) // verifica a jogada do jogador
  {

    if (quadroBatalha[linha, coluna] == "C")
    {
      pontos += 15;
      return "c";
    }
    else if (quadroBatalha[linha, coluna] == "P")
    {
      pontos += 5;
      return "p";
    }
    else if (quadroBatalha[linha, coluna] == "R")
    {
      pontos += 10;
      return "r";
    }
    else if (quadroBatalha[linha, coluna] == " ")
    {
      return VerificaPosicaoBarcoMaisPerto(quadroBatalha, linha, coluna);
    }
    else
    {
      return "comando dado antes";
    }

    return "comando dado antes";

  }

  public static string VerificaPosicaoBarcoMaisPerto(string[,] quadroBatalha, int linha, int coluna)
  {
    for (int i = 1; i < 4; i++)
    {
      if (linha - i >= 0)
      {
        if (quadroBatalha[linha - i, coluna] == "C" ||
        quadroBatalha[linha - i, coluna] == "P" ||
        quadroBatalha[linha - i, coluna] == "R")
          return Convert.ToString(i);
      }

      if (linha + i < 10)
      {
        if (quadroBatalha[linha + i, coluna] == "C" ||
        quadroBatalha[linha + i, coluna] == "P" ||
        quadroBatalha[linha + i, coluna] == "R")
          return Convert.ToString(i);
      }

      if (coluna - i >= 0)
      {
        if (quadroBatalha[linha, coluna - i] == "C" ||
        quadroBatalha[linha, coluna - i] == "P" ||
        quadroBatalha[linha, coluna - i] == "R")
          return Convert.ToString(i);
      }

      if (coluna + i < 10)
      {
        if (quadroBatalha[linha, coluna + i] == "C" ||
        quadroBatalha[linha, coluna + i] == "P" ||
        quadroBatalha[linha, coluna + i] == "R")
          return Convert.ToString(i);
      }
    }
    return "M";
  }
  #endregion

  #region Menu
  public void Menu(string[,] quadroBatalha, int jogadas, ref int pontos)
  {
    //menu Do Jogo
    Console.WriteLine("Bem vindo");

    Console.WriteLine("Você terá 15 jogadas");

    Console.WriteLine("Se você acertar um porta avião, você ganhará 5 pontos");

    Console.WriteLine("Se você acertar um porta rebocador, você ganhará 10 pontos");

    Console.WriteLine("Se você acertar um porta cruzador, você ganhará 15 pontos");

    Console.WriteLine("Boa sorte");

    Console.WriteLine(" Digite enter para começar");
    Console.ReadLine();
    Console.Clear();
    do
    {
      Console.WriteLine("Escolha uma Posição para jogar (linha coluna)");
      //Método split(retira o espaço)
      string[] Lc = Console.ReadLine().Split(" ");

      int linha = int.Parse(Lc[0]);
      int coluna = int.Parse(Lc[1]);

      if (linha < 0 || linha >= 10)
      {
        Console.ForegroundColor =ConsoleColor.Yellow;
        Console.WriteLine("Linha fora do Permitido");
        Console.ResetColor();
        continue;
      }

      if (coluna < 0 || coluna >= 10)
      {
        Console.ForegroundColor =ConsoleColor.Yellow;
        Console.WriteLine("coluna fora do Permitido");
        Console.ResetColor();
        continue;
      }

      string oQueAcertou = VerificaTiro(quadroBatalha, linha, coluna, ref pontos);

      if (oQueAcertou == "comando dado antes")
      {
        Console.WriteLine($"{oQueAcertou}");
        continue;
      }

      quadroBatalha[linha, coluna] = oQueAcertou;
      
      Console.Clear();

      Mapa(quadroBatalha, false);

      jogadas--;
    }
    while (jogadas > 0);
    Mapa(quadroBatalha, true);
    Console.WriteLine($"Você fez: {pontos}");
  }
  #endregion

  #region Preparar Campo
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
  #endregion
  public void Mapa(string[,] quadroBatalha, bool MostrarTudo)
  {

    if (!MostrarTudo)
    {
      for (int i = 0; i < quadroBatalha.GetLength(0); i++)
      {
        //Console.WriteLine("----------");
        Console.Write(i + "  ");
        for (int j = 0; j < quadroBatalha.GetLength(1); j++)
        {
          Console.Write("|");
          if (quadroBatalha[i, j] == "r")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "c")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "p")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "1" || quadroBatalha[i, j] == "2" ||
              quadroBatalha[i, j] == "3" || quadroBatalha[i, j] == "M")
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else
          {
            Console.Write(" |");
          }

        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
      }
      Console.WriteLine("    0  1  2  3  4  5  6  7  8  9 ");
    }
    else
    {
      for (int i = 0; i < quadroBatalha.GetLength(0); i++)
      {
        //Console.WriteLine("----------");

        for (int j = 0; j < quadroBatalha.GetLength(1); j++)
        {
          
          if (quadroBatalha[i, j] == "r")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|");
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "c")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|");
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "p")
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|");
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "1" || quadroBatalha[i, j] == "2" ||
              quadroBatalha[i, j] == "3" || quadroBatalha[i, j] == "M")
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("|");
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else if (quadroBatalha[i, j] == "P" || quadroBatalha[i, j] == "C" ||
              quadroBatalha[i, j] == "R")
          {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("|");
            Console.Write($"{quadroBatalha[i, j]}|");
            Console.ResetColor();
          }
          else
          {
            Console.Write("| |");
          }

        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------");
      }
    }
  }

  private static void Main(string[] args)
  {
    var prog = new Program();
  }
}