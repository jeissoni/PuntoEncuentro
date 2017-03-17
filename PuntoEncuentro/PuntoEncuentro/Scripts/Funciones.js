$(document).ready(function () {
    $("#usuarios").DataTable();
});

$("a").on("click", function (e) {
    var $a = $(this);
    var url = $a.prop("href").split("?")[0];
    var param = $a.prop("href").split("?")[1];
  
    var parametro = {
        evento:
            $("#IdEvento").val(),
        usu: param.split("&")[0].split("=")[1],
        usuCrea: param.split("&")[1].split("=")[1]
    };

    $a.prop("href", url + "?" + $.param(parametro));
});
