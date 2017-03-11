$(document).ready(function () {
    $("#usuarios").DataTable();
});

$("a").on("click", function (e) {
    var $a = $(this);
    var url = $a.prop("href").split("?")[0];
    var param = $a.prop("href").split("?")[1];
    //console.log(url);
    // http://localhost/MiControlador/MiAccion/1

    var evento="evento="+$("#IdEvento").val();
    var parametro = {
        evento:
            $("#IdEvento").val(),
        usu: param.split("&")[0].split("=")[1],
        usuCrea: param.split("&")[1].split("=")[1]
    };

    
    var otro = param+"&"+evento;
    //console.log($.param(parametro));
    // tipo=1

    //console.log(url + "?" + $.param(parametro));
    // http://localhost/MiControlador/MiAccion/1?tipo=1

    //e.preventDefault();

    $a.prop("href", url + "?" + $.param(parametro));
});
