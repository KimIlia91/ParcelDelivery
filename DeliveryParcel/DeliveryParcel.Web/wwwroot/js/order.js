let dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Home/Index"
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "senderFullName", "width": "15%" },
            { "data": "senderFullAddress", "width": "15%" },
            { "data": "senderCity", "width": "15%" },
            { "data": "recipientFullName", "width": "15%" },
            { "data": "recipientFullAddress", "width": "15%" },
            { "data": "recipientCity", "width": "15%" },
            { "data": "parcel.wieght", "width": "15%" },
            { "data": "shippingDate", "width": "15%" },
        ]
    });
}