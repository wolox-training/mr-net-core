$('#btn-add-comment').click(function(){
    var text = $('#comment-text').val();
    var rating = $('#comment-rating').val();
    $.ajax({
        type: 'POST',
        url: '/api/v1/Comments/AddComment',
        data: { id:$('#movie-id').val(),text: text, rating: rating },
        success: function(response){
            alert(response.message);
            $('#comments-box').append(
                '<tr> <td> <label>Comment: </label>' +
                    text+'</td></tr><tr><td><label>Date: </label>' +
                    response.date+
                '</td></tr><tr><td><label>Rate: </label>' +
                    rating+'</td></tr>'
            );
        },
        failure: function(response){
            alert('failure');
        },
    });
});
