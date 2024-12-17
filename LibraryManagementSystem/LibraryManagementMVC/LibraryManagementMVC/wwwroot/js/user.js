var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "fullName", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "role", "width": "10%" },
            {
                "data": "createdAt",
                "width": "15%",
                "render": function (data) {
                    if (data) {
                        const date = new Date(data);
                        return date.toLocaleDateString('tr-TR', {
                            day: '2-digit',
                            month: '2-digit',
                            year: 'numeric',
                            hour: '2-digit',
                            minute: '2-digit'

                        });
                    }
                    return "";
                }
            },
            {
                "data": "isDeleted",
                "width": "10%",
                "render": function (data) {
                    return data ? "Yes" : "No"; 
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="d-flex justify-content-center gap-2" role="group">
                    <a href="/admin/user/rolemanagement?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Change Role </a>
                     <a onClick=Delete('/admin/user/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
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
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
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