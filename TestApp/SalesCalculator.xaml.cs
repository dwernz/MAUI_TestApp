namespace TestApp;

public partial class SalesCalculator : ContentPage
{
	public SalesCalculator()
	{
		InitializeComponent();
	}

	private void CalculateDiscount(object sender, EventArgs e)
	{
		decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
		decimal discountPercent = Convert.ToDecimal(txtDiscountPercent.Text);

		decimal discountAmount = subtotal * (discountPercent / 100);
		decimal total = subtotal - discountAmount;

		txtDiscountAmount.Text = "$" + Math.Round(discountAmount, 2).ToString();
		txtTotal.Text = "$" + Math.Round(total, 2).ToString();
	}
}