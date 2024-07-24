
//this code ensure that the function LoadDatTable will be invoked when the entire HTML document is loaded
$(document).ready(function () {
   
    LoadDataTable();
});


function LoadDataTable() {
   
    DataTable = $('#BooksTable').DataTable({
        "ajax": {
            url: '/Book/GetAllBooks',
        
        },
        "columns": [
            { data: "id", "width": "20%" }, 
            { data: "name", "width": "20%" },                   
            { data: "shelf.englishName", "width": "20%" },
            { data: "author", "width": "20%" },
            { data: "price", "width": "20%" },
            { data: "shelf.id", "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group w-100" role="group">
                               <a href="/Book/Edit?id=${data}" class="btn btn-outline-primary mx-2">Edit</a>
                               <a href="/Book/Delete?id=${data}" class="btn btn-outline-danger mx-2">Delete</a>
                      </div>`
                },

                "width": "20%"
            }
        ],
      
    });
}