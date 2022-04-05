# Prerequisites

This is the starting point for the instructions on building and deploying the [MTC IPaaS Order Processor Demo](./README.md).  There is required access and tooling you'll need in order to accomplish this and while you may choose aan alternative specific desired IDE or development SDK, etc., the following are reccommended and utilized in the workshop.

- An active azure subscription with contributor access allowing the creation of the resources outlined in the [Resource Description Overview](./README.md#resources-descriptions).
- IDE -> [Visual Studio Code](https://code.visualstudio.com/)
    - Azure Tools Extension

        ![Azure Tools Extension.](./media/az_tools_ext.png)
    
    - Azure Functions Extension

        ![Azure Tools Extension.](./media/az_fun_ext.png)

- Development SDK -> [.NET 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)

- Rest Client -> [Postman](https://www.postman.com/)

- (Optional) Office 365 user account.  Used to create order confirmation emails and order received Teams channel notifications.