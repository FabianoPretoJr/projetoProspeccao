$("#limparFiltro").click(function () {
    $("#clienteNome").val("");
    $("#clienteCPF").val("");
    $("#dataInicio").val("");
    $("#dataFim").val("");
});

//var enderecoGerarExcel = "https://localhost:44360/Home/ExportarExcel/";

//$("#exportarExcel").click(function () {
//    var jsonListaFluxo = gerarJson();
//    enviarDados(jsonListaFluxo);
//});


//function gerarJson() {
//    var listaFluxos = new Array();
//    $("#tableFluxo").find("tr:gt(0)").each(function () {
//        var clienteNome = $(this).find("td:eq(0)").text();
//        var clienteCPF = $(this).find("td:eq(1)").text();
//        var usuarioLogin = $(this).find("td:eq(2)").text();
//        var statusNome = $(this).find("td:eq(3)").text();
//        var dataHora = $(this).find("td:eq(4)").text();

//        var objFluxo = {};
//        objFluxo.ClienteNome = clienteNome;
//        objFluxo.ClienteCPF = clienteCPF;
//        objFluxo.UsuarioLogin = usuarioLogin;
//        objFluxo.StatusNome = statusNome;
//        objFluxo.DataHora = dataHora;

//        listaFluxos.push(objFluxo);
//    });
//    return listaFluxos;
//}

//function enviarDados(jsonListaFluxo) {
//    $.ajax({
//        type: "POST",
//        url: enderecoGerarExcel,
//        dataType: "json",
//        contentType: "application/json",
//        data: JSON.stringify(jsonListaFluxo),
//        success: function (data) {
//            console.log("Dados enviados com sucesso!");
//            console.log(data);
//        }
//    });
//}