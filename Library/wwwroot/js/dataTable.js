
//this code ensure that the function LoadDatTable will be invoked when the entire HTML document is loaded
$(document).ready(function () {

    var id = $('#shelfid').val();
    var increment = 1;
    $.ajax({
        url: '/Book/GetAllBooks',
        type: "GET",
        data: { ShelfId: id }, // i send a parameter to the method in the serverside by ajax technics
        dataType: "json",
        success: function (response) { //responses is the data that ajax retrive from the end point
   

                  var  columnsBase=[
                      {
                          data: "id", width: "auto",
                          visible:true, // if i want the column to not be visible
                          render: function (id) {
                              

                              return increment++;
                          }

                      },
                      { data: "name", width: "auto" },
                      { data: "author", width: "auto" },
                      {
                          data: "price", width: "auto",
                      
                          render: function (price) { //if i want the cell in the column to be shown in a specific way (modify or change displaying)
                              return "$" + price;
                          }
                      },
                        {
                            data: 'id',
                            sortable: false, //if i nwant this column not sortable 
                            searchable: false,//if i nwant this column not searchable 
                            render: function (data) {
                                return `<div class="btn-group w-100" role="group">
                               <a href="/Book/Edit?id=${data}" class="btn btn-outline-primary mx-2">Edit</a>
                               <a href="/Book/Delete?id=${data}" class="btn btn-outline-danger mx-2">Delete</a>
                                   </div>`
                            },

                            "width": "auto"
                        }
                      ];
               

                 if (id==0){
                     columnsBase.splice(2, 0, {
                         data: "shelf.englishName", width: "auto",
                         searchable: false,
                         sortable:false,
                     });
                 }
           
            $('#BooksTable').DataTable({
                data: response.data,
                paging: true, // if i want paging or not in the datatable
                sort: true, // if i want sorting or not on the dattable
                searching: true,
               columns: columnsBase 
            });
        },
        error: function (result) {
            return console.error("error fetching data");
        }
    });
});

            

  


