


$(document).ready(function () {
    $('#button2').click(function () {
        var charType = $('#CharType').val();
        var div = document.getElementById('div');
        div.innerHTML = '&nbsp;'
        $("#div").append('<canvas id="myChart" style="max-width:600px;max-height:430px;"></canvas>')

        $.ajax({
            type: "POST",
            url: "/Home/GetBooksData",
            data:"",
            contentType: "application/json; charset=utf-8",
            DataType: "json",
            success: OnsuccessResult,
            Error:onerror

        });
       
        function OnsuccessResult(data) {
          
            var _data = data
            
            var charlabel = _data[0];
            var chardata = _data[1];
            var barColor = ["red", "blue", "green", "yellow", "orange", "brown"]

            new Chart("myChart", {

                type: charType,
                data: {
                    labels: charlabel,
                    datasets: [{
                        label:"counts",
                        backgroundColor: barColor,
                        data: chardata
                    }] 
                }
            });

            
        }

        function onerror() {

        }
    });
});