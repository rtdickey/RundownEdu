function loadGrid(gridId) {
    var eGridDiv = document.querySelector('#' + gridId);

    var columnDefs = [
        { headerName: "Make", field: "make" },
        { headerName: "Model", field: "model" },
        { headerName: "Price", field: "price" }
    ];

    var rowData = [
        { make: "Toyota", model: "Celica", price: 35000 },
        { make: "Ford", model: "Mondeo", price: 32000 },
        { make: "Porsche", model: "Boxter", price: 72000 }
    ];

    var gridOptions = {
        defaultColDef: {
            resizable: true
        },
        columnDefs: columnDefs,
        rowData: rowData
    };
    
    new agGrid.Grid(eGridDiv, gridOptions);
    gridOptions.api.sizeColumnsToFit();
}