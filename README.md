# CPSC 481 - Restaurant Ordering System

Team Name: Spaghetti Coders

Group: 17 

Members: Laura Timm, Trevor Le, Jacky Lam, Maggie Ma, Yihan Wei

Github URL: https://github.com/trvrle/spaghetti-coders

### __Prerequisites:__
1. Download & install Visual Studio 2019 with all the packages required to run a WPF application
2. Disable UI Debugging Tools for XAML by going to Debug > Options > Debugging > General > uncheck the 'Enable UI Debugging Tools for XAML' checkbox
3. Run our application by clicking on the play button

### __Introduction:__
A company wants to design an ordering system for restaurants/bars, allowing users to interact with the menu and order their food from their table directly. We created a system that users can use their phone to view items on the menu, select and modify those items, and order items from their table. They can add and order items at any point in their visit. Once they have completed their meal they can view their receipt and then pay with the restaurant's current payment system.

### __Included Features and How to access:__

__Main Screen:__

* Call server to the table: This is accessed by the bell button at the top of the main screen. Once selected, a notification will pop up and go away after a few seconds.
* Sort by price or calories: On the right hand side of the main screen there is a button with up and down arrows, click this and select how you want your items to be ordered  by. To deselect, click the button again and select your previous option again. 
* You can view your order from the main screen by clicking the shopping cart button in the top left hand corner. A # indicator will show on the corner of the button once items are added to determine the number of unordered items in the cart.
* A user can view different tabs on the main screen to view different categories for items they are looking for.
* View item in more detail: to view an item in more detail, click the item on the main screen 
* Search:  You can dynamically search by clicking the search box and type what you are looking for. When you click the search box the text clears, the items will show up as you are typing, as the search function looks for that string in the item titles. The items show up on a separate page from the main page and to exit the search function you click the "X" next to the search box.

__Item Details Page:__
   * You can either add the item to cart as is from this page by selecting "add item" or add modifications to the item by clicking the "modify item" button.

__Modification Page:__
   * Select Modifications (pre-set modifications or write your own): The modifications are set to how the order comes originally for each item you can add more or less of something from the common modifications, If the modification you are looking for doesn't exist you can write you own in the text box. *a phone keyboard pops up to view placement press enter to close the keyboard when you are done*
   * Add Item to order from modification page: when item is added you will return to the main screen

__Order Page:__
* On the order Page you can increase or decrease the quantity of order (price will adjust accordingly) by selecting the right arrow to increase or left arrow to decrease. You can also remove the item by clicking the "x" in the right hand side next to the item title.
* The Pay now button is disabled until you place your order
* Order button is disabled until items in your cart
* Once you add items to your cart and select "Order" a notification will pop up, and current items will be greyed out. You can add more new items to the order, these will be shown in full color  
* the totals for each item are presented and are summed up as each item is added, showing the subtotal, GST and Total price for ALL the items in cart.
* once you are done order items you can select "Pay now" to view the receipt for your total order


### __Below are a Few Pages from our System:__
<p align="center">
  <img src= "https://github.com/trvrle/spaghetti-coders/blob/main/2021-12-05%2015_20_03-.png" width="280" height="490"> <img src= "https://github.com/trvrle/spaghetti-coders/blob/main/Modify.png" width="280" height="490"> <img src= "https://github.com/trvrle/spaghetti-coders/blob/main/OrderPage.png" width="280" height="490"></p>

