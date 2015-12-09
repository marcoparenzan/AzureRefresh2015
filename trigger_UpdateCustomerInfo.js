function UpdateCustomerInfo() {
    var customer = getContext().getRequest().getBody();
    var collection = getContext().getCollection();

    var customerID = customer.CustomerID;
    var firstName = customer["FirstName"];
    var lastName = customer["LastName"];

    var callback = function (err, documents, responseOptions) {

        for (var i = 0; i < documents.length; i++) {
            var salesOrder = documents[i];
            salesOrder.Customer.FirstName = firstName;
            salesOrder.Customer.LastName = lastName;

            var accept1 = collection.replaceDocument(salesOrder._self,
			   salesOrder, function (err, docReplaced) {
			       if (err) throw "Unable to update metadata, abort";
			   });
        }
    }

    var filterQuery = 'SELECT * FROM s WHERE s.CustomerID = ' + customerID + ' AND s.SalesOrderID > 0';
    var accept = collection.queryDocuments(collection.getSelfLink(), filterQuery,
        callback);
    if (!accept) throw "Unable to update metadata, abort";
}
