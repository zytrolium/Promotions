# Promotions
Handling of promotions for a shop by calculating the price of a cart given specified promotions and item prices

-------------------------------------------------------------------------
Overview
-------------------------------------------------------------------------

Setup: Line 15-21
--------------------
Usage: Line 25-47
--------------------
Test suite: Line 50-55
--------------------


-------------------------------------------------------------------------
Setup
-------------------------------------------------------------------------
In order to use the solution you can either open the solution file and
add a new project that you wish to use in order to make use of the promotion
engine or you can start another project and add a reference to the PromotionEngine.dll
file located at /Promotions/PromotionEngine/bin/Release/net5.0/PromotionEngine.dll


-------------------------------------------------------------------------
Usage
-------------------------------------------------------------------------
In order to use the promotion engines cart calculation method ("GetPriceOfCart").
The promotionengine is generic in that sense that the sku type could be of any type.
it relies on the following 3 arguments

 - An implementation of the ICart interface of the type specified for the PromotionEngine.
 - A List of promotions, where each promotion implements the IPromotion interface.
 - A dictionary containing the unit prices of the items in the cart.

Interfaces and imiplementations:

- ICart implementation: An implementation of the ICart interface exist and is named Cart.

It has methods of adding new skus to the cart as well as a method of retrieving a list of all 
the skus in the cart.

- IPromotion implementation: An implementation of the IPromotion interface exist and is named Promotion.

It has a constructor that defines the skus required to trigger the promotion as well as a price.
It implements the two interface functions: GetPrice() and GetSkus() which returns the price and skus.


----------------------------------------------------------------------------
Test suite
----------------------------------------------------------------------------
A test suite is added to the solution file and the project is called "PromotionEngine.Test".
It is written using the xUnit test and tests models behaviour as well as the scenarios A,B, and C.
The test suite can be run using the visual studio test explorer.
