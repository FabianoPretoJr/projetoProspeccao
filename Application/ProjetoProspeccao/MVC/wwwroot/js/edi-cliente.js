var enderecoListarEstado = "https://localhost:44360/clientes/obterestado/";
var enderecoListarCidade = "https://localhost:44360/clientes/obtercidade/";

function listarEstados(id_Pais) {
    $("#titleEstado").remove();
    $("#estado").remove();
    $("#titleCidade").remove();
    $("#cidade").remove();
    $("#idCidade").val(null);
    $("#estadoDiv").remove();
    $("#cidadeDiv").remove();
    var endereco = enderecoListarEstado + id_Pais.value;
    $.get(endereco, function (dados, status) {
        $("#renderEstado").append(`
            <label id="titleEstado">Estado</label>
            <select class="form-control" id="estado" onchange="listarCidades(this)" required>
                <option value="">Selecione</option>
                ${dados.map(item => {
            return `<option key=${item.id_Estado} value="${item.id_Estado}">${item.nome_Estado}</option>`
        })}
            </select>
        `);
    });
}

function listarCidades(id_Estado) {
    $("#titleCidade").remove();
    $("#cidade").remove();
    $("#idCidade").val(null);
    $("#cidadeDiv").remove();
    var endereco = enderecoListarCidade + id_Estado.value;
    $.get(endereco, function (dados, status) {
        $("#renderCidade").append(`
            <label id="titleCidade">Cidade</label>
            <select class="form-control" id="cidade" onchange="adcIdCidade(this)" required>
                <option value="">Selecione</option>
                ${dados.map(item => {
            return `<option key=${item.id_Cidade} value="${item.id_Cidade}">${item.nome_Cidade}</option>`
        })}
            </select>
        `);
    });
}

function adcIdCidade(id_Cidade) {
    $("#idCidade").val(id_Cidade.value);
}