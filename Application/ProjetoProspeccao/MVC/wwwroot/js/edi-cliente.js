var enderecoListarEstado = "https://localhost:44360/clientes/obterestado/";
var enderecoListarCidade = "https://localhost:44360/clientes/obtercidade/";

// código do Pais Estado Cidade
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

// código do telefones
var cont = parseInt($("#valorDoContador").val());
var arrIndices = [];
adicionarIndicesDaViewNoArray();
var aux = true;

$("#telefones").click(function () {
    if (aux) {
        $("#render").append(`
            <div id="campoTelefone${cont}">
                <label id="labelNumero${cont}">Número ${cont + 1}</label>
                <div class="row">
                    <div class="col-sm-12 col-md-11">
                        <input type="text" class="form-control" placeholder="Número de Telefone do cliente" maxlength="9" minlength="9" required="" id="NumeroTelefone_${cont}__NumeroTelefone" name="NumeroTelefone[${cont}].NumeroTelefone" value>
                    </div>
                    <div class="col-sm-12 col-md-1">
                        <button class="btn btn-primary" style="margin-left: -30px;" id="btnOk${cont}" type="button" onClick="confirmarTelefone(${cont})">Ok</button>
                        <button class="btn btn-danger" style="margin-left: -30px;" id="btnLimpar${cont}" hidden type="button" onClick="limparTelefone(${cont})">Limpar</button>
                    </div>                                    
                </div><br />
            </div>
        `);
        arrIndices.push(cont);
        cont = cont + 1;
        aux = false;
    }
    else {
        alert("Adicione um telefone antes de criar outro campo!");
    }
});

function limparTelefone(contId) {
    $(`#campoTelefone${contId}`).remove();
    cont = cont - 1;
    acertarArrayIndices(contId);
    aux = true;
}

function confirmarTelefone(contId) {
    if ($(`#NumeroTelefone_${contId}__NumeroTelefone`).val().length == 9) {
        $(`#btnOk${contId}`).hide();
        $(`#btnLimpar${contId}`).prop("hidden", false);
        $(`#NumeroTelefone_${contId}__NumeroTelefone`).prop("readonly", true);
        aux = true;
    }
    else {
        alert("Necessário 9 digitos para um telefone ser válido!");
    }
}

function acertarArrayIndices(contId) {
    var indice = arrIndices.indexOf(contId);
    arrIndices.splice(indice, 1);

    console.log(arrIndices);

    var contIndice = contId;

    arrIndices.forEach(item => {
        if (item > contId) {
            $(`#campoTelefone${item}`).prop("id", `campoTelefone${contIndice}`);
            $(`#labelNumero${item}`).html(`Número ${contIndice + 1}`);
            $(`#labelNumero${item}`).prop("id", `labelNumero${contIndice}`);
            $(`#NumeroTelefone_${item}__NumeroTelefone`).prop("name", `NumeroTelefone[${contIndice}].NumeroTelefone`);
            $(`#NumeroTelefone_${item}__NumeroTelefone`).prop("id", `NumeroTelefone_${contIndice}__NumeroTelefone`);
            $(`#btnOk${item}`).attr("onclick", `confirmarTelefone(${contIndice})`);
            $(`#btnOk${item}`).prop("id", `btnOk${contIndice}`);
            $(`#btnLimpar${item}`).attr("onclick", `limparTelefone(${contIndice})`);
            $(`#btnLimpar${item}`).prop("id", `btnLimpar${contIndice}`);

            arrIndices[item - 1] = contIndice;
            contIndice++;
        }
    });

    console.log(arrIndices);
}

function adicionarIndicesDaViewNoArray() {
    for (let i = 0; i < cont; i++) {
        arrIndices[i] = i;
    }
}