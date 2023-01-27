using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace TestApp;

public partial class ShoppingTotal : ContentPage
{
    // Create the list of items.
    public ObservableCollection<Item> items { get; set; } = new ObservableCollection<Item>();
    double subtotal = 0.00;

    public ICommand DeleteCommand { get; set; }

    public ShoppingTotal()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private void AddItem(object sender, EventArgs e)
    {
        // Make sure entry fields are not null or empty.
        if (txtItemName.Text == null || txtItemName.Text == "")
        {
            DisplayAlert("Item Name Empty", "Item Name field cannot be empty", "Ok");
            txtItemName.Focus();
            return;
        }

        if (txtItemPrice.Text == null || txtItemPrice.Text == "")
        {
            DisplayAlert("Item Price Empty", "Item Price field cannot be empty", "Ok");
            txtItemPrice.Focus();
            return;
        }

        if (txtTaxPercent.Text == null || txtTaxPercent.Text == "")
        {
            DisplayAlert("Tax Percent Empty", "The Tax Percent field was empty and replaced with a default value of 6.5%", "Ok");
            txtTaxPercent.Text = "6.5";
        }

        try
        {
            double price = double.Parse(txtItemPrice.Text);
            var item = new Item { Name = txtItemName.Text, Price = double.Parse(txtItemPrice.Text) };

            items.Add(item);
            txtItemName.Text = "";
            txtItemPrice.Text = "";

            subtotal += price;

            UpdateTotals();
        }
        catch (FormatException)
        {
            // This catch makes sure the input is a number.
            DisplayAlert("Error", "Please enter a valid number for item price", "Ok");
        }        
    }

    private void EditItemName(object sender, EventArgs e)
    {
        var item = (Item)((Button)sender).CommandParameter;

        if (txtItemName.Text == null || txtItemName.Text == "")
        {
            DisplayAlert("Item Name Empty", "Item Name field cannot be empty", "Ok");
            txtItemName.Focus();
            return;
        }

        item.Name = txtItemName.Text;
        item.NotifyPropertyChanged("Name");

        txtItemName.Text = "";
    }
    private void EditItemPrice(object sender, EventArgs e)
    {
        var item = (Item)((Button)sender).CommandParameter;

        if (txtItemPrice.Text == null)
        {
            DisplayAlert("Item Price Empty", "Item Price field cannot be empty", "Ok");
            txtItemPrice.Focus();
            return;
        }

        try
        {
            double price = double.Parse(txtItemPrice.Text);

            
            subtotal -= item.Price;
            subtotal += price;

            item.Price = price;
            item.NotifyPropertyChanged("Price");

            txtItemPrice.Text = "";
            UpdateTotals();
        }
        catch (FormatException)
        {
            DisplayAlert("Error", "Please enter a valid number for item price", "Ok");
        }

    }

    private async void DeleteItem(object sender, EventArgs e)
    {
        var item = (Item)((Button)sender).CommandParameter;
        var confirm = await DisplayAlert("Delete Item", "Are you sure you want to delete this item?", "Yes", "No");
        
        if (confirm)
        {
            items.Remove(item);
            subtotal -= item.Price;
            UpdateTotals();
        }
    }

    private void ClearItems(object sender, EventArgs e)
    {
        txtItemName.Text = "";
        txtItemPrice.Text = "";
    }

    private void UpdateTotals()
    {
        try
        {
            double taxPercent;

            if (txtTaxPercent.Text == null)
            {
                txtTaxPercent.Text = "6.5";
            }
            taxPercent = double.Parse(txtTaxPercent.Text);

            double taxAmount = Math.Round((subtotal * (taxPercent / 100)), 2);
            double total = Math.Round((subtotal + taxAmount), 2);

            lblSubtotal.Text = Math.Round(subtotal, 2).ToString("0.00");
            lblTaxDollar.Text = taxAmount.ToString("0.00");
            lblTotal.Text = total.ToString("0.00");
        }
        catch (FormatException)
        {
            DisplayAlert("Error", "Invalid entry, replaced the value with a default of 6.5%", "Ok");
            txtTaxPercent.Text = "6.5";
            UpdateTotals();
        }
        

    }

    public class Item: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}