# Exercise 4 - Order PRocessor Logic App

In the exercise we'll create the Logic App that is responsible for processing the recieved order document that has been persisted in the "PendingOrders" collection.  The Logic App is implemented as an HTTP request trigger that will recieve the conceptually completed order document.  It will persist the order to the "ProcessedOrders" collection and delete the preprocessed order document.  We'll again front the API with APIM and test/ Later we'll modify this Logic App to also put the completed order onto a Service Bus queue to continue processing.

1) Create the order processor Logic App:

    ![HTTP Trigger](./media/ex3/la1_or_httpreq.png)


