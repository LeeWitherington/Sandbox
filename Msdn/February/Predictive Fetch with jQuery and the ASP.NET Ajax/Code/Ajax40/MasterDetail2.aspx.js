var currentQuery = { Selection: "A" };

function pageLoad() {
    // Build the button bar to select customers by initial
    for (var i = 0; i < 26; i++) {
        var newButton = $('<input type="button" onclick="filterQuery(this)" />');
        var text = String.fromCharCode('A'.charCodeAt(0) + i);
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
    // The following won't work:
    //     currentQuery.Selection = button.value;
    Sys.Observer.setValue(currentQuery, "Selection", button.value);

    // Updates the master view
    fillMasterView(currentQuery);
}
function fillMasterView(query) {
    // Retrieves the DataView object being used for the master
    var dataViewInstance = $find("masterDataView");

    // Tell the DataView to fetch fresh data to reflect the current selection 
    var filterString = query.Selection;
    dataViewInstance.set_fetchParameters({ query: filterString });
    dataViewInstance.fetchData();
}
