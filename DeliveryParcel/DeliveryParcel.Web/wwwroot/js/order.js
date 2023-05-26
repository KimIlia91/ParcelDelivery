$(document).ready(function () {
    loadDataTable();
})
function formatDateTime(dateString) {
    let date = new Date(dateString);
    let year = date.getFullYear();
    let month = padZero(date.getMonth() + 1);
    let day = padZero(date.getDate());
    let formattedDate = day + '.' + month + '.' + year;
    return formattedDate;
}

function padZero(value) {
    return value < 10 ? '0' + value : value;
}

function loadDataTable() {
    dataTable = $('#orderTable').DataTable({
        scrollX: 400,
        select: true,
        "language": {
            "sEmptyTable": "Нет данных",
            "sInfo": "Показано от _START_ до _END_ из _TOTAL_ записей",
            "sInfoEmpty": "Показано 0 записей",
            "sInfoFiltered": "(отфильтровано из _MAX_ записей)",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "Показать _MENU_ записей",
            "sLoadingRecords": "Загрузка...",
            "sProcessing": "Обработка...",
            "sSearch": "Поиск:",
            "sZeroRecords": "Нет записей",
            "oPaginate": {
                "sFirst": "Первая",
                "sLast": "Последняя",
                "sNext": "Следующая",
                "sPrevious": "Предыдущая"
            },
        },
        "ajax": {
            url: '/home/getallorders'
        },
        "columns": [
            { data: 'id' },
            { data: 'senderFullName' },
            { data: 'senderFullAddress' },
            { data: 'senderCity' },
            { data: 'recipientFullName' },
            { data: 'recipientFullAddress' },
            { data: 'recipientCity' },
            { data: 'parcelWeight' },
            { data: 'shippingDate', render: function (data) { return formatDateTime(data); } }
        ]
    });
}