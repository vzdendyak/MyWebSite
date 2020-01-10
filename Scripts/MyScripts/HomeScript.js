$(function () {

//$('#otrp').click(function (e) {
//            

//})

    $(document).ready(function () {
        $("#otrp").click(function () {
             $('#name1').val('');
            $('#email1').val('');
            $('#message1').val('');
            $(".blockcentr").slideToggle("2000");
            if ($("div").hasClass("blockall"))
                $(".blockall").remove();
            else $(".tytoknoall").append('<div class="blockall"></div>');
        });
        $(".tytoknoall").click(function () {
            $('#name1').val('');
            $('#email1').val('');
            $('#message1').val('');
            $(".blockcentr").slideToggle("2000");
            $(".blockall").remove();
        });
    });
})