namespace TestApp;

public partial class TicTacToe : ContentPage
{
	int _numMoves = 0;
	
	public TicTacToe()
	{
		InitializeComponent();
    }

	private string[,] _gameBoard = new string[3, 3];
	private bool _isPlayer1 = true;

	private void Button_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		var row = Grid.GetRow(button);
		var col = Grid.GetColumn(button);

		if (_gameBoard[row, col] != null )
		{
			return;
		}

		if (_isPlayer1 )
		{
			_gameBoard[row, col] = "X";
			button.Text = "X";
		}
		else
		{
            _gameBoard[row, col] = "O";
            button.Text = "O";
			
        }

		_isPlayer1 = !_isPlayer1;
		_numMoves++;

        if (CheckForWinner())
		{
            DisplayWinner();

            button00.IsVisible = false;
            button01.IsVisible = false;
            button02.IsVisible = false;
            button10.IsVisible = false;
            button11.IsVisible = false;
            button12.IsVisible = false;
            button20.IsVisible = false;
            button21.IsVisible = false;
            button22.IsVisible = false;

            btnReset.IsVisible = true;
        }
	}

	private bool CheckForWinner()
	{
		
		for (int i = 0; i < 3; i++)
		{
			if (_gameBoard[i, 0] == _gameBoard[i, 1] && _gameBoard[i, 1] == 
				_gameBoard[i,2] && _gameBoard[i,0] != null)
			{
				return true;
			}
		}

		for (int i = 0; i < 3; i++)
		{
			if (_gameBoard[0,i] == _gameBoard[1,i] && _gameBoard[1,i] ==
				_gameBoard[2,i] && _gameBoard[0,i] != null)
			{
				return true;
			}
		}

		if (_gameBoard[0,0] == _gameBoard[1,1] && _gameBoard[1,1] ==
			_gameBoard[2,2] && _gameBoard[0,0] != null) 
		{
            return true;
        }

        if (_gameBoard[0,2] == _gameBoard[1,1] && _gameBoard[1,1] ==
            _gameBoard[2,0] && _gameBoard[0,2] != null)
        {
            return true;
        }

		if (_numMoves == 9)
		{
			DisplayAlert("Draw", "Draw", "New Game");

            button00.IsVisible = false;
            button01.IsVisible = false;
            button02.IsVisible = false;
            button10.IsVisible = false;
            button11.IsVisible = false;
            button12.IsVisible = false;
            button20.IsVisible = false;
            button21.IsVisible = false;
            button22.IsVisible = false;

            btnReset.IsVisible = true;
        }

		return false;
    }

    private void DisplayWinner()
    {
        string winner = _isPlayer1 ? "O" : "X";
        DisplayAlert("Winner", $"Player {winner} wins!", "Ok");
    }


	private void ResetButtons(object sender, EventArgs e)
	{
        _gameBoard = new string[3, 3];
        _isPlayer1 = true;
        _numMoves = 0;

		button00.IsVisible = true;
		button01.IsVisible = true;
		button02.IsVisible = true;
        button10.IsVisible = true;
        button11.IsVisible = true;
        button12.IsVisible = true;
        button20.IsVisible = true;
        button21.IsVisible = true;
        button22.IsVisible = true;



        btnReset.IsVisible = false;

        button00.Text = "";
        button01.Text = "";
        button02.Text = "";
        button10.Text = "";
        button11.Text = "";
        button12.Text = "";
        button20.Text = "";
        button21.Text = "";
        button22.Text = "";
    }
}