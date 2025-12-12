using Xunit;

public class BoardTests
{
    [Fact]
    public void PlayMove_ShouldReturnTrue_WhenCaseIsEmpty()
    {
        // Arrange
        var board = new Board();

        // Act
        bool result = board.PlayMove(1, 1, 'X');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PlayMove_ShouldReturnFalse_WhenCaseIsAlreadyTaken()
    {
        // Arrange
        var board = new Board();
        board.PlayMove(1, 1, 'X');

        // Act
        bool result = board.PlayMove(1, 1, 'O');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void PlayMove_ShouldReturnFalse_WhenCoordinatesOutOfBounds()
    {
        // Arrange
        var board = new Board();

        // Act
        bool result = board.PlayMove(-1, 3, 'X');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFull_ShouldReturnFalse_WhenBoardIsEmpty()
    {
        var board = new Board();

        Assert.False(board.IsFull());
    }

    [Fact]
    public void IsFull_ShouldReturnTrue_WhenBoardIsFull()
    {
        var board = new Board();

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board.PlayMove(i, j, 'X');

        Assert.True(board.IsFull());
    }

    [Fact]
    public void CheckWin_ShouldReturnTrue_WhenRowIsCompleted()
    {
        var board = new Board();

        board.PlayMove(0, 0, 'X');
        board.PlayMove(0, 1, 'X');
        board.PlayMove(0, 2, 'X');

        Assert.True(board.CheckWin('X'));
    }

    [Fact]
    public void CheckWin_ShouldReturnTrue_WhenDiagonalOneIsCompleted()
    {
        var board = new Board();

        board.PlayMove(0, 0, 'X');
        board.PlayMove(1, 1, 'X');
        board.PlayMove(2, 2, 'X');

        Assert.True(board.CheckWin('X'));
    }

    [Fact]
    public void CheckWin_ShouldReturnTrue_WhenDiagonalTwoIsCompleted()
    {
        var board = new Board();

        board.PlayMove(0, 2, 'X');
        board.PlayMove(1, 1, 'X');
        board.PlayMove(2, 0, 'X');

        Assert.True(board.CheckWin('X'));
    }
}
