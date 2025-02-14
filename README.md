Back to the Checkout Kata
===============
My C# implementation of this known kata, featuring the strategy design pattern. More details about the kata here: [http://codekata.com/kata/kata09-back-to-the-checkout/](http://codekata.com/kata/kata09-back-to-the-checkout/)

**Requirements**

This week, let’s implement the code for a supermarket checkout that calculates the total price of a number of items. In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our store, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multipriced: buy n of them, and they’ll cost you y cents. For example, item ‘A’ might cost 50 cents individually, but this week we have a special offer: buy three ‘A’s and they’ll cost you $1.30. In fact this week’s prices are:

  Item   UnitPrice     SpecialPrice
  --------------------------
    A      50            3 for 130
    B      30            2 for 45
    C      20
    D      15
	
Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass in a set of pricing rules each time we start handling a checkout transaction.