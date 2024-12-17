var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/member/home/getall',
            type: 'GET'
        },
        "columns": [
            {
                data: 'title',
                "render": function (data, type, row) {
                    return `<a href="/member/home/details/${row.id}" class="text-decoration-none">${data}</a>`;
                },
                width: '25%'
            },
            { data: 'author', width: '15%' },
            { data: 'isbn', width: '15%' },
            { data: 'publicationYear', width: '10%' },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/member/home/lend/${data}" class="btn btn-success mx-2">
                            <i class="bi bi-hand-thumbs-up"></i> Lend
                        </a>
                        <a href="/member/home/return/${data}" class="btn btn-warning mx-2">
                            <i class="bi bi-arrow-return-left"></i> Return
                        </a>
                    </div>`;
                },
                width: '25%'
            }
        ]
    });
}
