$(document).ready(function () {
    $('#h1').after('<p style="background-color: blue;">after is used to put html code created in jquery and put it after the selected element(#h1 in this case)</p>');
    $('#h1').before('<p style="background-color: blue;">after is used to put html code created in jquery and put it before the selected element(#h1 in this case)</p>');
    //the insert before function is used to move the selected element(#p in this case) to before the selected element(#h1 in this case)
    $('#p').insertBefore('#h1');
    //the insert after function is used to move the selected element(#p in this case) to after the selected element(#h1 in this case)
    $('#h2').insertAfter('#h1');

    $('#add-table').click(function () {

        $("#tbl-div").append("<table><thead></thead><tbody></tbody></table>");
        $('table thead').append('<tr><th>Name</th><th>Email</th><th>Message</th></tr>');
        $('table tbody').append('<tr><td>Ali</td><td>Ali@email.com</td><td>Hello</td></tr>');
        $('table tbody').append('<tr><td>Nasir</td><td>Nasir@email.com</td><td>Hi</td></tr>');

        $('table').addClass("table table-bordered");
        $('#tbl-div').show();
    });
});