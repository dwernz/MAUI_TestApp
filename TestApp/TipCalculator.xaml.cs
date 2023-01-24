namespace TestApp;

public partial class TipCalculator : ContentPage
{
	public TipCalculator()
	{
		InitializeComponent();
	}

	private void CalculatePercent(object sender, EventArgs e)
	{
        bool roundUpTip = radioTip.IsChecked;
        bool roundUpTotal = radioTotal.IsChecked;

        decimal subtotal = Convert.ToDecimal(txtTipSubtotal.Text);
		decimal tipAmount = Convert.ToDecimal(txtTipAmount.Text);

        if (roundUpTip == true)
        {
            tipAmount = Math.Ceiling(tipAmount);
            txtTipAmount.Text = Math.Round(tipAmount, 2).ToString();
        }

        
		decimal total = subtotal + tipAmount;

        if (roundUpTotal == true)
        {
            total = Math.Ceiling(total);
            tipAmount = total - subtotal;
        }

        decimal tipPercent = (tipAmount / subtotal) * 100;

        txtTipAmount.Text = Math.Round(tipAmount, 2).ToString();
        txtTipPercent.Text = Math.Round(tipPercent, 2).ToString();
		txtTipTotal.Text = Math.Round(total, 2).ToString();
	}

	private void CalculateAmount(object sender, EventArgs e)
	{
		bool roundUpTip = radioTip.IsChecked;
		bool roundUpTotal = radioTotal.IsChecked;

		decimal subtotal = Convert.ToDecimal(txtTipSubtotal.Text);
        decimal tipPercent = Convert.ToDecimal(txtTipPercent.Text);
        decimal tipAmount = subtotal * (tipPercent / 100);

        if (roundUpTip == true)
        {
            tipAmount = Math.Ceiling(tipAmount);
        }

        decimal total = subtotal + tipAmount;

        if (roundUpTotal == true)
        {
			total = Math.Ceiling(total);
            tipAmount = total - subtotal;
        }
        
        tipPercent = (tipAmount / subtotal) * 100;

        txtTipPercent.Text = Math.Round(tipPercent, 2).ToString();
        txtTipAmount.Text = Math.Round(tipAmount, 2).ToString();
        txtTipTotal.Text = Math.Round(total, 2).ToString();
    }

}