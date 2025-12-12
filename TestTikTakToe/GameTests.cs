using Xunit;
using System.Collections.Generic;

public class GameTests
{
    [Fact]
    public void Game_ShouldDeclareXWinner_WhenFirstRowCompleted()
    {
        var board = new Board();

        var fakeX = new FakePlayer('X', new List<int[]> {
            new [] {0, 0},
            new [] {0, 1},
            new [] {0, 2}
        });

        var fakeO = new FakePlayer('O', new List<int[]> {
            new [] {1, 0},
            new [] {1, 1}
        });

        var game = new Game(board, fakeX, fakeO);

        while (true)
        {
            int[] move = game.CurrentPlayer.GetNextMove();
            board.PlayMove(move[0], move[1], game.CurrentPlayer.Symbol);

            if (board.CheckWin(game.CurrentPlayer.Symbol))
            {
                Assert.Equal('X', game.CurrentPlayer.Symbol);
                break;
            }

            if (board.IsFull())
            {
                Assert.True(false, "Game should not end in draw");
                break;
            }

            game.SwitchPlayerForTest();
        }
    }

    [Fact]
    public void Game_ShouldDeclareOWinner_WhenColumnCompleted()
    {
        var board = new Board();

        var fakeX = new FakePlayer('X', new List<int[]> {
            new [] {0, 0},
            new [] {1, 2},
            new [] {2, 0}
        });

        var fakeO = new FakePlayer('O', new List<int[]> {
            new [] {0, 1},
            new [] {1, 1},
            new [] {2, 1}
        });

        var game = new Game(board, fakeX, fakeO);

        while (true)
        {
            int[] move = game.CurrentPlayer.GetNextMove();
            board.PlayMove(move[0], move[1], game.CurrentPlayer.Symbol);

            if (board.CheckWin(game.CurrentPlayer.Symbol))
            {
                Assert.Equal('O', game.CurrentPlayer.Symbol);
                break;
            }

            if (board.IsFull())
            {
                Assert.True(false, "Game should not end in draw");
                break;
            }

            game.SwitchPlayerForTest();
        }
    }

    [Fact]
    public void Game_ShouldEndInDraw_WhenBoardIsFullWithoutWinner()
    {
        var board = new Board();

        var fakeX = new FakePlayer('X', new List<int[]> {
            new [] {0,0}, 
            new [] {1,0}, 
            new [] {1,1}, 
            new [] {2,1}, 
            new [] {0,2}
        });

        var fakeO = new FakePlayer('O', new List<int[]> {
            new [] {0,1}, 
            new [] {2,0}, 
            new [] {1,2}, 
            new [] {2,2}
        });

        var game = new Game(board, fakeX, fakeO);

        bool draw = false;

        while (true)
        {
            int[] move = game.CurrentPlayer.GetNextMove();
            board.PlayMove(move[0], move[1], game.CurrentPlayer.Symbol);

            if (board.CheckWin(game.CurrentPlayer.Symbol))
            {
                Assert.True(false, "Should not have a winner");
                break;
            }

            if (board.IsFull())
            {
                draw = true;
                break;
            }

            game.SwitchPlayerForTest();
        }

        Assert.True(draw);
    }
}


