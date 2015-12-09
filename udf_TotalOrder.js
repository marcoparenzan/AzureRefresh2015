function totalOrder(doc) {
    var total = 0;
    for (var i = 0; i < doc.SalesOrderDetail.length; i++)
    {
        var detail = doc.SalesOrderDetail[i];
        total += detail.Quantity * detail.UnitPrice;
    }
    return total;
}