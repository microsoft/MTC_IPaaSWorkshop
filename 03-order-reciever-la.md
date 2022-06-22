# Exercise 3 - Order Receiver Logic App

In the exercise we'll create the Logic App that is responsible for recieving the pre-processed order document and persisting it to the CosmosDB PreProcessed collection.  We'll also integrate the Logic App with our APIM instance.


1) Begin by provisioning the Logic App:

    ![Order Processor Logic App](./media/ex3/la1_or.png)

2) Create a workflow starting with an HTTP rest trigger:

    ![HTTP Trigger](./media/ex3/la1_or_httpreq.png)

    - Use the following sample payload to create the JSON schema:

        	{
	            "product": "Cherry Glue",
	            "quantity": "10",
	            "email": "jasoncoo@onemtc.net"
	        }
    
    - The request method is POST

3) Create an action to create or update a document:

    **Note:** when using a prev V3 action the "Partition Key Value" is required.

    Pre V3
    ![Pre V3 Create or Update Action](./media/ex3/la1_or_cd.png)

    V3
    ![V3 Create or Update Action](./media/ex3/la1_or_cdv3.png)

    - The Database/Collection IDs are FlavoredOfficeSupplies/PendingOrders
    - The document to be persisted should match the structure of the inboud rest JSON document and with values dynamically generated from the HTTP request triggered as pictured.
    - An ID should be programatically created using a dynamic expression for creating a guid().

4) Next, create a response action as follows:

    ![Response Action](./media/ex3/la1_or_resp.png)

5) Save the created workflow and test using the newly generated POST URL:

    - Using Postman we can confirm that the when submitting a JSON order document, we receive a response body and code of 200.

    ![Postman Test 1](./media/ex3/la1_or_test1.png)

