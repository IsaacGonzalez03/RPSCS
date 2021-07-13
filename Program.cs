using System;
namespace RockPaperScissors
{
  public enum Choice { Rock, Paper, Scissor };
  public enum Result { Tie, Win, Loss };
  public class Program

  {
    public static Random rng;
    public static void Main(string[] args)
    {
      rng = new Random();
      Console.WriteLine("Lets Play ROCK-PAPER-SCISSORS");
      var playerChoice = PlayerInput();
      Console.WriteLine("You picked: {0}", playerChoice.ToString());
      var compChoice = CompInput();
      Console.WriteLine("Computer Picked: {0}", compChoice.ToString());
      switch (GameResult(playerChoice, compChoice))
      {
        case Result.Win:
          Console.WriteLine("You Win!");
          break;
        case Result.Loss:
          Console.WriteLine("You Fat Loser!");
          break;
        case Result.Tie:
          Console.WriteLine("Tie, Play Again!");
          break;
      }
    }
    public static Choice PlayerInput()
    {
      Choice result;
      //do while loop
      while (true)
      {
        var input = Console.ReadLine();
        if (Choice.TryParse(input, true, out result))
        {
          return result;
        }
        else
        {
          Console.WriteLine("Invalid", input);
        }
      }
    }
    public static Choice CompInput()
    {
      return (Choice)rng.Next((int)Choice.Rock, (int)Choice.Scissor);
    }
    public static Result GameResult(Choice player, Choice comp)
    {
      switch (player)
      {
        case Choice.Rock:
          switch (comp)
          {
            case Choice.Rock: return Result.Tie;
            case Choice.Paper: return Result.Loss;
            case Choice.Scissor: return Result.Win;
          }
          break;
        case Choice.Paper:
          switch (comp)
          {
            case Choice.Rock: return Result.Win;
            case Choice.Paper: return Result.Tie;
            case Choice.Scissor: return Result.Loss;
          }
          break;
        case Choice.Scissor:
          switch (comp)
          {
            case Choice.Rock: return Result.Loss;
            case Choice.Paper: return Result.Win;
            case Choice.Scissor: return Result.Tie;
          }
          break;
      }
      throw new Exception(string.Format("Unhandled action pair occured: {0}, {1}", player, comp));
    }
  }
}


