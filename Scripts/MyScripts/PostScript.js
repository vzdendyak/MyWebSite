$(function () {
   

    $(document).ready(function () {

        var data = $('#postId1').val();

        $.ajax({
            url: '../showComment',
            type: 'POST',
            data: {postId:data},
            
            success: function (data1) {
                $('#com_updt').append(data1);
            },
            error: function () {
                alert("Произошел сбой бла бла бла");
            }
        });

        $('#SendComment').click(function (e) {
            e.preventDefault();
            var comText = $('#BodyText').val();
            var comTitle = $('#Title').val();
            
            $.ajax({
                url: '../CommentAdd',
                type: 'POST',
                data: { Title: comTitle, BodyText: comText, postId1: data },
                success: function (data1) {
                    $('#com_updt').append(data1);
                },
                error: function () {
                    alert("Произошел сбой бла бла бла");
                }
            })

        });
    })
})