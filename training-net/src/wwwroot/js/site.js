// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#btnAddComment').click(function(){

    $.ajax({
        type: 'POST',
        url: 'Comments/AddComment',
        contentType: 'application/json',
        dataType: 'json',
        data: {text: $('#Commtext').val()},
        success: function(response){
            alert("success");
        },
        failure: function(response){
            alert('failure');
        }
    });
});
