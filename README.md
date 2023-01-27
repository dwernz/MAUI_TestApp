# MAUI_TestApp

This is an app that I will continuously use for development. Mainly testing purposes.

This app will host mini-apps rather than having many small separate apps.

Currently, none of the features save any data.
Exiting or going back a page will erase any session data.
Such as the math quiz's scoring system.

Sales calculator
Tip calculator
Hours calculator
Counter
Math quiz
Fizz buzz generator
TicTacToe
Shopping Total

There is also the National Day message on the homepage.
This feature, based on the day of the year, will display a different message.

The sales calculator has a user enter an item's price and the discount percentage.
The output will calculate the discount amount and the discounted price.

The tip calculator lets a user enter the subtotal and the desired tip percentage or tip amount, and calculate the other and the total.
Users also have the option of rounding the tip or total up to the nearest dollar.

The hours calculator adds the hours selected in a 2 week work week (Mon-Fri).
Lunch time is deducted from the hours worked.
The default hours are set to my wife's normal work week.

The counter app is an extension of MAUI's default programming.
It expands it by adding the decrement ability as well as incrementing or decrementimg in 5s and 10s for quicker counting.

Math quiz is a simple app that generates too random integers and a random operation.
The operations are limited to addition, subtraction, multiplication, and division.
Adding and subtracting the maximum integer is 100.
Subtracting, the second integer will not be higher, so the answer should never be negative.
Multiplication the integers are selected from 0 to 12. With 12 x 12 the maximum.
Division the integers are selected so that the answer will always be an integer.
   This avoids havind irrational answers.
The app keeps track of how many questions have been answered, answers correct, and shows the percentage of answers correct.

The fizz buzz generator accepts a max number and generates a list of numbers from 1 to the max number.
Numbers are replaced with fizz, buzz, and fizzbuzz accordingly.

TicTacToe is a 2 player game set with the same rules.
I originally made TicTacToe apps with Java and JavaScript.
It's a relatively simple game to program and easy to play while waiting.
I used ChatGPT to write most of the code for this.
There were some issues, so I have to resolve them myself.
Overall I would say about 70% is ChatGPT and 30% me.

Shopping Total is an app my sister asked for.
Users can input an item name and price, hit the add button.
This will store the information to the list.
The prices of all the items will be added and displayed as the subtotal.
Users can change the tax percentage to reflect their local sales tax.
Currently, the tax percent has to be changed before adding, editing, or deleting.
I plan on making it so after unfocusing from the entry control, the info is updated.
The tax amount is calculated, added to the subtotal and the total is displayed.
Users can delete an item from the list.
Users can enter a new name or price in the respected entry control, and hit edit name or price. This will edit the item's property.
Currently, there is a user issue for android phones.
Closing the keyboard and hitting the same area will cause users to go back a page.
This erases the list since it is not saved.
There is plans on making it so the list items are saved to a local file.
This feature will carry to a shopping list application where users can add item names and qty to a list.

Current possible applications
Shopping list
Pomodoro timer
Random dice roller
More complex games
Barcode generator
