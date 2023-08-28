# ShopCenter
ShopCenter is a project that serves as an ordering service for clients.
there are 3 web APIs that provide these issues:
Every order has a delivery time and should be delivered on exact time. 
If there is an order that has a delay, the client should notify and ask to check the problem.
Agents can check a delay report and probe the matter.
A report of vendors' delayed times in the current week. 
## Technologies
ShopCenter has been developed by these nuggets and technologies:
.Net 6<br /> 
EF Core 6<br />
MediatR<br />
Repository pattern<br />
Xunit for test<br />
## Configuring the sample to use SQL Server

1. Open a package manager console and execute the following commands:<br />

    ```
update-database
    ```

    These commands will create a database.<br />

2. Run the application.<br />



    Note: If you need to create migrations, you can use these commands:<br />

    ```
add-migration initialization
    ```




