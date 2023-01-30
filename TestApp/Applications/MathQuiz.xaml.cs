using System.Runtime.Intrinsics.Arm;

namespace TestApp;

public partial class MathQuiz : ContentPage
{
	int question = -1;
	int correct = 0;
    int rndNum1 = 0;
    int rndNum2 = 0;
    int rndOperator = 0;
    string stringOperator = "";
    Random rnd = new Random();

    public MathQuiz()
	{
		InitializeComponent();
	}

	private void StartQuiz(object sender, EventArgs e)
	{
		btnStart.IsVisible = false;
		btnSubmit.IsVisible = true;
        txtNum1.IsVisible = true;
        txtNum2.IsVisible = true;
        txtOperator.IsVisible = true;
        txtGuess.IsVisible = true;
        lblGuess.IsVisible = true;
        lblQuestion.IsVisible = true;
        lblCorrect.IsVisible = true;
        lblScore.IsVisible = true;

		generateQuestion();
		
    }

    private void SubmitAnswer(object sender, EventArgs e)
    {
        try
        {
            if (txtGuess.Text == "")
            {
                DisplayAlert("No Number", "Your guess can't be blank.", "Ok");
                return;
            }

            int guess = Convert.ToInt32(txtGuess.Text);

            int answer = 0;

            if (stringOperator == "/")
            {
                answer = rndNum1 / rndNum2;
            }
            else if (stringOperator == "*")
            {
                answer = rndNum1 * rndNum2;
            }
            else if (stringOperator == "+")
            {
                answer = rndNum1 + rndNum2;
            }
            else if (stringOperator == "-")
            {

                answer = rndNum1 - rndNum2;
            }

            if (answer == guess)
            {
                correct++;
                txtHeader.Text = $"Correct: {rndNum1} {stringOperator} {rndNum2} = {answer}";
            }
            else
            {
                txtHeader.Text = $"Incorrect: {rndNum1} {stringOperator} {rndNum2} = {answer}";
            }


            generateQuestion();
        }
        catch (FormatException)
        {
            DisplayAlert("Error", "Please enter a valid integer", "Ok");
        }
        
	}

	private void generateQuestion()
	{
        question++;
        decimal score = 0;

        txtGuess.Text = "";
        txtGuess.Focus();

        rndOperator = rnd.Next(1, 5);
        if (question > 0)
        {
            score = (Convert.ToDecimal(correct) / (Convert.ToDecimal(question))) * 100;
            lblScore.Text = "Score: " + Math.Round(score, 2).ToString() + "%";
        }
        else
        {
            lblScore.Text = "Score: N/A";
        }
        
        lblQuestion.Text = "Questions completed: " + question.ToString();
        lblCorrect.Text = "Correct: " + correct.ToString();
        

        if (rndOperator == 1)
        {
            stringOperator = "+";
        }
        else if (rndOperator == 2)
        {
            stringOperator = "-";
        }
        else if (rndOperator == 3)
        {
            stringOperator = "/";
        }
        else if (rndOperator == 4)
        {
            stringOperator = "*";
        }
        else
        {
            stringOperator = "Error:";
        }

        txtOperator.Text = stringOperator;

        if (stringOperator == "/")
        {
            do
            {
                rndNum1 = rnd.Next(0, 100);
                rndNum2 = rnd.Next(1, 11);
            }
            while (rndNum1 % rndNum2 != 0);
        }
        else if (stringOperator == "*")
        {
            rndNum1 = rnd.Next(0, 13);
            rndNum2 = rnd.Next(0, 13);
        }
        else if (stringOperator == "-")
        {
            do
            {
                rndNum1 = rnd.Next(0, 101);
                rndNum2 = rnd.Next(0, 101);
            } while ((rndNum1 - rndNum2) < 0);
        }
        else if (stringOperator == "+")
        {
            rndNum1 = rnd.Next(0, 101);
            rndNum2 = rnd.Next(0, 101);
        }

        txtNum1.Text = rndNum1.ToString();
        txtNum2.Text = rndNum2.ToString();
    }
}