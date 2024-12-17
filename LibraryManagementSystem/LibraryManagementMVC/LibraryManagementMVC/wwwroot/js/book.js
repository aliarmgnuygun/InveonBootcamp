var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/book/getall', type: 'GET' },
        "columns": [
            {
                data: 'title',
                "render": function (data, type, row) {
                    return `<a href="/admin/book/details/${row.id}">${data}</a>`;
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
                    <a href="/admin/book/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
                    <a onClick=Delete('/admin/book/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
                    </div>`
                },
                width: '25%'
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}