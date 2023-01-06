$(function () {
    $('#btnPostSimpleDataType').on('click', function () {
        var data = { name: $('#inputName').val(), age: $('#inputAge').val() };
        $.ajax({
            type: 'post',
            url: '/Home/AjaxPostSimpleDataType',
            contentType: 'application/x-www-form-urlencoded',
            data: data,
            success: function (res) {
                if (res.responseCode == 0) {
                    $('#msg').html(res.responseMessage);
                }
            },
            error: function (xhr, status, error) { alert("error"); }
        });
    });

    $('#btnPostObject').on('click', function () {
        var data = { name: $('#inputName').val(), age: $('#inputAge').val() };
        $.ajax({
            type: 'post',
            url: '/Home/AjaxPostObject',
            contentType: 'application/json; charset=urf-8',
            data: JSON.stringify(data),
            dataType: "json",
            success: function (res) { 
                if (res.responseCode == 0) {
                    $('#msg').html(res.responseMessage);
                }
            },
            error: function (xhr, status, error) { alert("error"); }
        });
    });

    $('#btnPostCollection').on('click', function () {
        var arr = [];
        $('.list-group li').each(function () {
            var person = {};
            person.Id = $(this).val();
            person.Name = $(this).find('div').text().split(" ")[0];
            person.Age = $(this).find('div').text().split(" ")[1];
            arr.push(person);
        })
        $.ajax({
            type: 'post',
            url: '/Home/AjaxPostCollection',
            contentType: 'application/json; charset=urf-8',
            data: JSON.stringify(arr),
            dataType: "json",
            success: function (res) {
                if (res.responseCode == 0) {
                    $('#msg').html(res.responseMessage);
                }
            },
            error: function (xhr, status, error) { alert("error"); }
        });
    });
});
