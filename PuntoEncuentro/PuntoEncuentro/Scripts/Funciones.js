$(document).ready(function () {
    $("#usuarios").DataTable();
});

$("a").on("click", function (e) {
    var $a = $(this);
    var url = $a.prop("href").split("?")[0];
    var param = $a.prop("href").split("?")[1];
    //console.log(url);
    // http://localhost/MiControlador/MiAccion/1


    var parametro = {
        evento:
            $("#IdEvento").val(),
        usu: param.split("&")[0],
        usuCrea: param.split("&")[1]
    };

    var mire = param.split("&");
    var otro = "evento=" + $("#IdEvento").val() + "&" + param;
    //console.log($.param(parametro));
    // tipo=1

    //console.log(url + "?" + $.param(parametro));
    // http://localhost/MiControlador/MiAccion/1?tipo=1

    //e.preventDefault();

    $a.prop("href", url + "?" + $.param(otro));
});
