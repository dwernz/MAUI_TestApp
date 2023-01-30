using System.Collections.ObjectModel;

namespace TestApp.Applications;

public partial class ShoppingList : ContentPage
{
    public ObservableCollection<ShoppingItem> shoppingItems { get; set; } = new ObservableCollection<ShoppingItem>();

    public ShoppingList()
	{
		InitializeComponent();
		BindingContext = this;

	}

	public async void AddItem(object sender, EventArgs e)
	{
        if (txtItemListName.Text == null || txtItemListName.Text == "")
        {
            await DisplayAlert("Item Name Empty", "Item Name field cannot be empty", "Ok");
            txtItemListName.Focus();
            return;
        }

        if (txtItemListQty.Text == null || txtItemListQty.Text == "")
        {
            await DisplayAlert("Item Qty Empty", "Item Qty field cannot be empty", "Ok");
            txtItemListQty.Focus();
            return;
        }

        if (txtItemListQty.Text == "0")
        {
            await DisplayAlert("Item Qty Zero", "Item Qty cannot be 0", "Ok");
            txtItemListQty.Focus();
            return;
        }

        

        string name = txtItemListName.Text;
        string qtyString = txtItemListQty.Text;
        
        try
        {
            int qty = Convert.ToInt32(qtyString);

            if (qty < 0)
            {
                await DisplayAlert("Item Qty Negative", "Item Qty cannot be negative", "Ok");
                txtItemListQty.Focus();
                return;
            }

            var shoppingItem = new ShoppingItem { Name = name, Qty = qty };

            shoppingItems.Insert(0, shoppingItem);
            txtItemListName.Text = "";
            txtItemListQty.Text = "";

            await ShoppingService.AddItem(name, qty);
        }
        catch (FormatException)
        {
            await DisplayAlert("Error", "Please enter a valid number for item qty", "Ok");
        }
	}

    public async void EditItem(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Edit Item:", "Cancel", null, "Edit Name", "Edit Qty");

        if (action == "cancel")
        {
            return;
        }
        else if (action == "Edit Name")
        {
            string result = await DisplayPromptAsync("Edit Name", "New Name");

            while (result == "")
            {
                result = await DisplayPromptAsync("Edit Name", "Name cannot be empty");
            }

            var item = (ShoppingItem)((Button)sender).CommandParameter;

            item.Name = result.ToString();
            item.NotifyPropertyChanged("Name");

            int qty = item.Qty;
            string name = item.Name;

            shoppingItems.Remove(item);
            await ShoppingService.DeleteItem(item.Id);

            var shoppingItem = new ShoppingItem { Name = name, Qty = qty };

            shoppingItems.Insert(0, shoppingItem);

            await ShoppingService.AddItem(name, qty);

        }
        else if (action == "Edit Qty")
        {
            string result = await DisplayPromptAsync("Edit Qty", "New Qty", keyboard: Keyboard.Numeric);

            while (result == "")
            {
                result = await DisplayPromptAsync("Edit Qty", "Qty cannot be empty", keyboard: Keyboard.Numeric);
            }

            try
            {
                int qty = Convert.ToInt32(result);
                if (qty == 0)
                {
                    DeleteItem(sender, e);

                }
                else if (qty < 0)
                {
                    await DisplayAlert("Item Qty Negative", "Item Qty cannot be negative", "Ok");
                }
                else if (qty > 0)
                {
                    var item = (ShoppingItem)((Button)sender).CommandParameter;
                    item.Qty = qty;
                    item.NotifyPropertyChanged("Qty");

                    string name = item.Name;

                    shoppingItems.Remove(item);
                    await ShoppingService.DeleteItem(item.Id);

                    var shoppingItem = new ShoppingItem { Name = name, Qty = qty };

                    shoppingItems.Insert(0, shoppingItem);

                    await ShoppingService.AddItem(name, qty);
                }
            }
            catch (FormatException)
            {
                await DisplayAlert("Error", "Invalid Entry", "Ok");
            }

            
        }
    }

    public async void DeleteItem(object sender, EventArgs e)
    {
        var item = (ShoppingItem)((Button)sender).CommandParameter;
        bool sureToDelete = await DisplayAlert("Delete Item", $"Are you sure you want to delete {item.Name}?", "Yes", "No");

        if (sureToDelete)
        {
            shoppingItems.Remove(item);

            await ShoppingService.DeleteItem(item.Id);
        }

        return;
    }

    


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var shoppingList = await ShoppingService.GetItems();
        shoppingItems.Clear();
        foreach(var item in shoppingList)
        {
            shoppingItems.Add(item);
        }
    }
}