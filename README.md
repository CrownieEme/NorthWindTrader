# NorthWindTraders
NorthWindTraders is an e-commerce web app used for grocery shopping. It provides a user the ability to view products in a categorized manner. The web app is written in C# for the backend, Javascript, HTML and CSS for the backend.  .

## Adding Database
1. Create Folder App_Data under solution
2. Open file explorer and add both data and log northwnd files
3. Open App_Data in Visual Studio and Add both northwnd files as existing items.

## Updating Web Config
1. Go to the Connection string block 
2. Replace source value with your Database server name. Mine is "DESKTOP-IKCQKHS\SQLEXPRESS;""
3. Replace attachdbfilename with the location path of your .mdf file in file explorer. Mine is C:\Source\Repos\NorthWindTrader\NorhtWindTraders\App_Data\northwnd.mdf;)

> <add name="NWContext" >connectionString="metadata=res://*/App_DAL.NorthwindModel.csdl|res://*/App_DAL.NorthwindModel.ssdl|res://*/App_DAL.NorthwindModel.msl;provider=System.Data.SqlClient;provider >connection string=&quot;data source=DESKTOP-IKCQKHS\SQLEXPRESS;attachdbfilename=C:\Source\Repos\NorthWindTrader\NorhtWindTraders\App_Data\northwnd.mdf;integrated >security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

## How to run the app
1. Either fork or download the app and open the folder in Microsoft Visual Studio preferrably.
2. Select Solution (.sln) as start app
3. Build app to make to rid any errors.
4. Launch app by clicking on Launch in Visual Studio.

## Check for all Products
1. Click on Products to view all available grocery products available
2. Products can also be viewed by categories.

## Purchase Product
1. Click on desired product
2. User is taken to Product page and can choose quantity of item
3. Click on Add cart.

## Update Quantity
1. Click on drop down to select quantity.
2. Click on Update to get final price of item.


## User Stories
- A user can view all a few amount of product on a single page.
- A user can choose product based category.
- A user can select item and taken to its respective product page.
- A user can select quantity of product.
- A user can click on add cart button to add item to cart.
- A user can update quantity of product with a button.
- A user can see final price of total product.

## Features
- Product tab
- Category side bar fo all product.
- Pictorial description of all products
- Prices of items
- Dropdown to select quantity.
- Northwind trader logo

## Future Features
- Ability to place an order by filling out customer form
- Ability to save order to the database.
- Ability to delete item from the cart.



