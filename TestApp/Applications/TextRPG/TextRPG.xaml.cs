using System.Collections.ObjectModel;
using System.ComponentModel;
using TestApp.Applications.TextRPG;
using Location = TestApp.Applications.TextRPG.Location;

namespace TestApp;

public partial class TextRPG : ContentPage
{
    private Player _player;
	private Monster _currentMonster;

	public ObservableCollection<InventoryItemsList> inventoryItemsList { get; set; } = new ObservableCollection<InventoryItemsList>();
	public ObservableCollection<QuestList> questList { get; set; } = new ObservableCollection<QuestList>();

	public class InventoryItemsList : INotifyPropertyChanged
    {
		public string Name { get; set; }
		public int Quantity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

	public class QuestList : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public bool IsComplete { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

        public TextRPG()
	{
		InitializeComponent();
		BindingContext = this;

		_player = new Player(10, 10, 0, 0, 1, 1, 1);

		MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
		_player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

		lblHitPoints.Text = _player.CurrentHitPoints.ToString();
		lblGold.Text = _player.Gold.ToString();
		lblExperience.Text = _player.ExperiencePoints.ToString();
		lblLevel.Text = _player.Level.ToString();
    }

	private void MoveNorth(object sender, EventArgs e)
	{
		MoveTo(_player.CurrentLocation.LocationToNorth);
	}

    private void MoveEast(object sender, EventArgs e)
    {
		MoveTo(_player.CurrentLocation.LocationToEast);
    }

    private void MoveSouth(object sender, EventArgs e)
    {
        MoveTo(_player.CurrentLocation.LocationToSouth);
    }

    private void MoveWest(object sender, EventArgs e)
    {
        MoveTo(_player.CurrentLocation.LocationToWest);
    }

	private void MoveTo(Location newLocation)
	{
		// Does the location have any required items
		if(newLocation.ItemRequiredToEnter != null)
		{
			// See if the player has the required item in their inventory
			bool playerHasRequiredItem = false;

			foreach(InventoryItem ii in _player.Inventory)
			{
				if(ii.Details.ID == newLocation.ItemRequiredToEnter.ID)
				{
					// We found the required item
					playerHasRequiredItem = true;
					break; // Exit out of the foreach loop
				}
			}

			if(!playerHasRequiredItem)
			{
				// We didn't find the required item in their inventory, so display a message and stop trying to move
				rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
				return;
			}
		}

		_player.CurrentLocation = newLocation;

		// Show/hide available movement buttons
        btnNorth.IsEnabled = (newLocation.LocationToNorth != null);
        btnEast.IsEnabled = (newLocation.LocationToEast != null);
        btnSouth.IsEnabled = (newLocation.LocationToSouth != null);
        btnWest.IsEnabled = (newLocation.LocationToWest != null);

        // Display current location name and description
        rtbLocation.Text = newLocation.Name + Environment.NewLine;
        rtbLocation.Text += newLocation.Description + Environment.NewLine;

		// Completely heal the player
		_player.CurrentHitPoints = _player.MaximumHitPoints;

		// Update Hit Points in UI
		lblHitPoints.Text = _player.CurrentHitPoints.ToString();

		// Does the location have a quest?
		if (newLocation.QuestAvailableHere != null)
		{
			// See if the plater already has the quest, and if they've completed it
			bool playerAlreadyHasQuest = false;
			bool playerAlreadyCompletedQuest = false;

			foreach(PlayerQuest playerQuest in _player.Quests)
			{
				if (playerQuest.Details.ID == newLocation.QuestAvailableHere.ID)
				{
					playerAlreadyHasQuest = true;

					if(playerQuest.IsCompleted)
					{
						playerAlreadyCompletedQuest = true;
					}
				}
			}

			// See if the player already has the quest
			if (playerAlreadyHasQuest)
			{
				if(!playerAlreadyCompletedQuest)
				{
					// See if the player has all the items needed to complete the quest
					bool playerHasAllItemsToCompleteQuest = true;

					foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
					{
						bool foundItemInPlayersInventory = false;

						// Check each item in the player's inventory, to see if they have it, and enough of it
						foreach(InventoryItem ii in _player.Inventory)
						{
							// The player has this item in their inventory
							if(ii.Details.ID == qci.Details.ID)
							{
								foundItemInPlayersInventory = true;

								if(ii.Quantity < qci.Quantity)
								{
									playerHasAllItemsToCompleteQuest = false;

									// There is no reason to continue checking for the other quest completion items
									break;
								}

								// We found the item, so don't check the rest of the player's inventory
								break;
							}
						}

						// If we didn't find the required item, set out variable and stop looking for other items
						if(!foundItemInPlayersInventory)
						{
							// The player does not have this item in their inventory
							playerHasAllItemsToCompleteQuest = false;

							// There is no reason to continue checking for other quest completion items
							break;
						}
					}

					// The player has all items required to complete the quest
					if(playerHasAllItemsToCompleteQuest)
					{
						// Display message
						rtbMessages.Text += Environment.NewLine;
						rtbMessages.Text += "You completed the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

						// Remove quest items from inventory
						foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
						{
							foreach(InventoryItem ii in _player.Inventory)
							{
								if(ii.Details.ID == qci.Details.ID)
								{
									// subtract the quantity from the player's inventory that was needed to complete the quest
									ii.Quantity -= qci.Quantity;
									break;
								}
							}
						}

						// Give quest rewards
						rtbMessages.Text += "You receive: " + Environment.NewLine;
						rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                        rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                        rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                        rtbMessages.Text += Environment.NewLine;

                        _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                        _player.Gold += newLocation.QuestAvailableHere.RewardGold;

						// Add the reward item to the player's inventory
						bool addedItemToPlayerInventory = false;

						foreach(InventoryItem ii in _player.Inventory)
						{
							if(ii.Details.ID == newLocation.QuestAvailableHere.RewardItem.ID)
							{
								// They have the item in their inventory, so increase the quantity by one
								ii.Quantity++;

								addedItemToPlayerInventory = true;

								break;
							}
						}

						// They didn't have the item, so add it to their inventory, with a quantity of 1
						if(!addedItemToPlayerInventory)
						{
							_player.Inventory.Add(new InventoryItem(newLocation.QuestAvailableHere.RewardItem, 1));
						}

						// Mark the quest as completed
						// Find the quest in the player's quest list
						foreach(PlayerQuest pq in _player.Quests)
						{
							if(pq.Details.ID == newLocation.QuestAvailableHere.ID)
							{
								// Mark it as completed
								pq.IsCompleted = true;

								break;
							}
						}
                    }
				}
			}
			else
			{
                // The player does not already have the quest

                // Display the messages
                rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;

				foreach(QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
				{
					if(qci.Quantity == 1)
					{
						rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                    }
					else
					{
                        rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                    }
				}
                rtbMessages.Text += Environment.NewLine;

                // Add the quest to the player's quest list
                _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
            }
		}

		// Does the location have a monster?
		if(newLocation.MonsterLivingHere != null)
		{
            rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

			// Make a new monster, using the values from the standard monster in the World.Monster list
			Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

			_currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
				standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints,
				standardMonster.MaximumHitPoints);

			foreach(LootItem lootItem in standardMonster.LootTable)
			{
				_currentMonster.LootTable.Add(lootItem);
			}

            cboWeapons.IsEnabled = true;
			cboPotions.IsEnabled = true;
			cboArmor.IsEnabled = true;
			cboShield.IsEnabled = true;
			btnUseWeapon.IsEnabled = true;
			btnUsePotion.IsEnabled = true;
        }
		else
		{
			_currentMonster = null;

            cboWeapons.IsEnabled = false;
            cboPotions.IsEnabled = false;
            cboArmor.IsEnabled = false;
            cboShield.IsEnabled = false;
            btnUseWeapon.IsEnabled = false;
            btnUsePotion.IsEnabled = false;
        }

		// Refresh the player's inventory list
		foreach(InventoryItem inventoryItem in _player.Inventory)
		{
			if(inventoryItem.Quantity > 0)
			{
				var ii = new InventoryItemsList { Name = inventoryItem.Details.Name, Quantity = inventoryItem.Quantity };
				inventoryItemsList.Add(ii);
			}
		}

		// Refresh player's quest list
		foreach(PlayerQuest playerQuest in _player.Quests)
		{
			var pq = new QuestList { Name = playerQuest.Details.Name, IsComplete = playerQuest.IsCompleted };
			questList.Add(pq);
		}

		List<Weapon> weapons = new List<Weapon>();

		var sword = new Weapon(1, "Rusty Sword", "Rusty Swords", 0, 1);

        weapons.Add(sword);

		foreach(InventoryItem inventoryItem in _player.Inventory)
		{
			if(inventoryItem.Details is Weapon)
			{
				if(inventoryItem.Quantity > 0)
				{
					weapons.Add((Weapon)inventoryItem.Details);
				}
			}
		}

		if(weapons.Count == 0)
		{
			// The player doesn't have any weapons, so disable the weapon combobox and "Use" button
			cboWeapons.IsEnabled = true;
			btnUseWeapon.IsEnabled = true;
		}
		else {
			cboWeapons.ItemsSource = weapons;
			cboWeapons.SelectedIndex = 0;
		}

    }
}