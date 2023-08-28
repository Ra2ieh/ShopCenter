# ShopCenter
ShopCenter is a project that serves as an ordering service for clients.
there are 3 web APIs that provide these issues:<br />
Every order has a delivery time and should be delivered on exact time. <br />
If there is an order that has a delay, the client should notify and ask to check the problem.<br />
Agents can check a delay report and probe the matter.<br />
A report of vendors' delayed times in the current week. <br />
## Technologies
ShopCenter has been developed by these nuggets and technologies:
.Net 6<br /> 
EF Core 6<br />
MediatR<br />
Repository pattern<br />
Xunit for test<br />
## Configuring the sample to use SQL Server

1. Open a package manager console and execute the following commands:<br />

   Note: Be careful about the  server and user pass in the  connection string that is located in the Appsetting.json file:<br />
 
    ```
    update-database
    ```
     
    These commands will create a database.<br />
     

2. Run the application.<br />



    Note: If you need to create migrations, you can use these commands:<br />

    ```
    add-migration initialization
    ```




