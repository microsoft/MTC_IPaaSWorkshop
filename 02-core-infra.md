# Exercise 2 - Core Infrastructure

In this exercise you'll create all of the required core infrastructure services that support the workflow of the order processor.  These resources are:

- Resource Group that contains all the resources for the project.
- Log Analytics Workspace for logging related functionality.
- Application Insights for metrics and application performance monitoring.
- API Management to provide gateway and reverse proxy functionality.
- CosmosDB for persistence of order related funcitonality.


Steps:

1) Create the resource group that will contain all of the resources for the project:

    ![Resource Group](./media/ex2/rg1.png)

2) Create the Log Analytics Workspace:

    ![Log Analytics Workspace](./media/ex2/law1.png)

3) Create the Application Insights Instance:

    ![Applicaion Insights](./media/ex2/ai1.png)

4) Provision an APIM instance, 

    **NOTE:** when selecting the Pricing Tier for this service, any SKU higher than Developer will need approximately 1 hour to provision:

    ![API Management](./media/ex2/apim1.png)

5) Provision the CosmosDB instance:

    ![CosmosDB](./media/ex2/cosmos1.png)

    a) Create the database "FlavoredOfficeSupplies" that will contain the two required collections:

    ![Resource Group](./media/ex2/cosmos1_db.png)

    b) Create the Container "PendingOrders" that will hold the pre-processed orders 
    
    **NOTE:** the selection of the partition key being "/product":

    ![Resource Group](./media/ex2/cosmos1_db_c1.png)

    C) Create the Container "ProcessedOrders" that will hold the completed orders 
    
    **NOTE:** the selection of the partition key being "/product":

    ![Resource Group](./media/ex2/cosmos1_db_c2.png)


All required core infrastructure related services are now provisioned and you can now move to [Exercise 3: Create Order Receiver Logic App](./03-order-reciever-la.md).