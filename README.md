# Azure Platform as a Service Workshop / Demo

## Workshop Overview
- [Stub] one pager
- [Stub] presentational options
## Architecture Overview
![IPaaS Order Processor Architecture Overview.](./media/overview.png)
## Resources Descriptions
- Resources group - Contains all workshop resources.
	
- CosmosDB - Stores Pre/Post processed order documents.
	
- API Management service - Serves as ra equest proxy and gateway.

- Service Bus - Serves as an integration point between the order processing system and the enterprise email system.  In practice this messaging bus could also serve as abstraction point between any inter process communication or integration.
	
- Function app - Recieves Cosmos change events and acts as an integration point with other external services (address services, inventory service, etc.)
	
- Logic apps - Provides the business workflows
	- Incoming order receiver
	- Complete order processor
	- Service Bus notification queue producer
	- Service Bus notification consumer / email producer

- Office 365 tenant - Email provider / integration user account provider
	Order Notifier - Notifier service integration
	Orders - Email notification account


## Process Flow

The overall process flow for this architectute is:

  1) The theoretical UI submits an order request via REST interface to the Order API.
  2) An HTTP triggered Logic App recieves the order document and persists it to the CosmosDB pending orders container.
  3) CosmosDB generates a change feed event.
  4) The order processing Function App is triggered by the CosmosDB change feed event.
  5) The Function aApp calls a (mocked) customer address service to obtain customer information. The Function App then creates an aggregated document representing the order that contains original order information (product, quantity, email) as well customer information.
  6) The Function App then calls the order processor HTTP Logic App, which receives the aggregated order document, persists a new complete order document to the processed orders CosmosDB container and deletes the original order received document from the pending order container.
  7) The order processor Logic App then calls the notifification producer Logic App with the finalized order document.

      a) (Optionaly) The order processor Logic App may then use the Office 365 Logic App Connector to produce a teams notification, notifying a theoretical distrobution team that an order is ready to be shipped.
      
  8) The Notifier producer Logic App takes the finalized order document and puts it onto a Service Bus.
  9) A notification consumer Logic App retrieves the processed order from the Service Bus, uses the O365 connector to generate an email that is sent to the email address of the customer that created order, notifying them that their order has been processed.


  NOTES: 

- Service Bus is utilized in the demo as a means to demonstrate how to integrate service bus.  Realistically and in practice SB could sit between any of the Fx/LA API calls to make the architecture more event driven.
- It's implied in the reference architecture and implemented such that all calls to HTTP triggers go through APIM.
- The facilitator supplies the credentials to the O365 connector in order to create the email / Instant message.  It's helpful to have a demo tenant set up that can be used to provision a service user on a per demo basis.
- In terms of extensibility, again all HTTP triggers can be converted to SB events making more of event driven architecture.
- All deployment can be automated and full CI/CD with ARM / Bicep and GH actions.





## Build and deploy the reference Order Processor 
### 1. [Prequisite Setup](./01-prequisites.md)

stub

### 2. [Core Infrastructure Provisioning](./02-core-infra.md)

stub

### 3. [Create Order Receiver Logic App](./03-order-reciever-la.md)

stub

### 4. [Create Order Processor Logic App](./04-order-processor-la.md)

stub

### 5. [Create Integration Trigger Function App](./05-integration-trigger-function.md)

stub

### 6. [Create Integration Service Bus Queue](./06-integration-servicebus.md)

stub

### 7. [Create Service Bus message Producer Logic App](./07-servicebus-producer-la.md)

stub

### 8. [Create Service Bus Consumer Logic App](./08-servicebus-consumer-la.md)

stub

### 9. [(Optional) Integrate Order Notification with Teams](./09-teams-integration.md)

stub

### 10. [End-to-End Functional Test](./10-end-to-end-test.md)

stub

### 11. [End-to-End Monitoring](./11-end-to-end-monitoring.md)

stub


## Additional Considerations

stub



## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
