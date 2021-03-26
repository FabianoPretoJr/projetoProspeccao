var enderecoListarEstado = "https://localhost:44360/clientes/obterestado/";
var enderecoListarCidade = "https://localhost:44360/clientes/obtercidade/";

function listarEstados(id) {
    $("#titleEstado").remove();
    $("#estado").remove();
    $("#titleCidade").remove();
    $("#cidade").remove();
    $("#idCidade").val(null);
    var endereco = enderecoListarEstado + id.value;
    $.get(endereco, function (dados, status) {
        $("#renderEstado").append(`
            <label id="titleEstado">Estado</label>
            <select class="form-control" id="estado" onchange="listarCidades(this)" required>
                <option value="">Selecione</option>
                ${dados.map(item => {
                    return `<option key=${item.id} value="${item.id}">${item.nomeEstado}</option>`
                })}
            </select>
        `);
    });
}

function listarCidades(id) {
    $("#titleCidade").remove();
    $("#cidade").remove();
    $("#idCidade").val(null);
    var endereco = enderecoListarCidade + id.value;
    $.get(endereco, function (dados, status) {
        $("#renderCidade").append(`
            <label id="titleCidade">Cidade</label>
            <select class="form-control" id="cidade" onchange="adcIdCidade(this)" required>
                <option value="">Selecione</option>
                ${dados.map(item => {
            return `<option key=${item.id} value="${item.id}">${item.nomeCidade}</option>`
        })}
            </select>
        `);
    });
}

function adcIdCidade(id) {
    $("#idCidade").val(id.value);
}