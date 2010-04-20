var currentQuery = { Selection: "A" };
var currentCustomer = "";

Sys.require([Sys.scripts.jQuery]);

Sys.onReady(
    function() {
    }
);



function display() {
    if (currentCustomer == "") {
        currentCustomer = $("#itemCustomer0").attr("commandargument");
        fetchOrders($("#itemCustomer0")[0]);    // Extract the DOM element
    }

    var cachedInfo = $('#viewOfCustomers').data(currentCustomer);
    if (typeof (cachedInfo) !== 'undefined')  
        data = cachedInfo;
    else
        data = "No orders found yet. Please wait ...";
    $("#listOfOrders0").html(data);
}

// Fetch orders asynchronously. 
// 
function fetchOrders(elem) {
    // Set the customer ID
    var id = elem["commandargument"];
    currentCustomer = id;
    
    // Check the jQuery cache  
    var cachedInfo = $('#viewOfCustomers').data(id);
    if (typeof (cachedInfo) !== 'undefined') {
        return;
    }

    // Download orders
    $.ajax({
        type: "POST",
        url: "/aspnetajax4/mydataservice.asmx/FindOrdersByCustomerAsMarkup",
        data: "id=" + id,
        success: function(response) {
            $('#viewOfCustomers').data(id, response.text);
            if (id == currentCustomer)
                $("#listOfOrders0").html(response.text);
        }
    });
}

function pageLoad() {
    // Build the button bar to select customers by initial
    for (var i = 0; i < 26; i++) {
        var text = String.fromCharCode('A'.charCodeAt(0) + i);
        var newButton = $('<input type="button" onclick="filterQuery(this)" />');
        newButton.attr("value", text).appendTo("#menuBar").show();
    }

    // Make the current query object observable so that live binding can update
    // the displayed selection string 
    Sys.Observer.makeObservable(currentQuery);

    // Refresh the list of customers
    fillMasterView(currentQuery);
}
function filterQuery(button) {
    // Enables live binding on the internal object that contains 
    // the current filter.
    Sys.Observer.setValue(currentQuery, "Selection", button.value);
    currentCustomer = "";

    // Updates the master view
    fillMasterView(currentQuery);
}
function fillMasterView(query) {
    // Check cache first: if not, go thorugh the data provider
    if (!reloadFromCache(query))
        reloadFromSource(query);
}
function reloadFromCache(query) {
    // Using the query string as the cache key
    var filterString = query.Selection;

    // Check the jQuery cache and update
    var cachedInfo = $('#viewOfCustomers').data(filterString);

    if (typeof (cachedInfo) !== 'undefined') {
        var dv = $find("masterView");
        dv.set_data(cachedInfo);
        dv.refresh();
        return true;
    }

    return false;
}
function reloadFromSource(query) {
    // Set the query string for the provider
    var filterString = query.Selection;

    // Tell the DataView to fetch
    var dv = $find("masterView");
    dv.set_fetchParameters({ query: filterString });
    dv.fetchData(cacheOnFetchCompletion, null, null, filterString);
}
function cacheOnFetchCompletion(fetchedData, filterString) {
    if (fetchedData !== null) {
        $('#viewOfCustomers').data(filterString, fetchedData);
    }
}
