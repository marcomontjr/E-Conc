$('#Categorias').change(function () {
    var categoriaEscolhida = $(this).val();
    if (categoriaEscolhida === "Desenvolvimento") {
        MostraDesenvolvimento();
        return;
    } else if (categoriaEscolhida === "Empreendedorismo") {
        MostraEmpreendedorismo();
        return;
    } else if (categoriaEscolhida === "IniciacaoCientifica") {
        MostraIniciacaoCientifica();
        return;
    } else if (categoriaEscolhida === "PesquisaAcademica") {
        MostraPesquisaAcademica();
        return;
    }

    MostraTudo();
});

function MostraDesenvolvimento() {
    $('.Desenvolvimento').show();
    $(".Empreendedorismo").hide();
    $(".IniciacaoCientifica").hide();
    $(".PesquisaAcademica").hide();
}

function MostraEmpreendedorismo() {
    $(".Empreendedorismo").show();
    $('.Desenvolvimento').hide();
    $(".IniciacaoCientifica").hide();
    $(".PesquisaAcademica").hide();
}

function MostraIniciacaoCientifica() {
    $(".IniciacaoCientifica").show();
    $(".Empreendedorismo").hide();
    $('.Desenvolvimento').hide();
    $(".PesquisaAcademica").hide();
}

function MostraPesquisaAcademica() {
    $(".PesquisaAcademica").show();
    $(".IniciacaoCientifica").hide();
    $(".Empreendedorismo").hide();
    $('.Desenvolvimento').hide();
}

function MostraTudo() {
    $(".PesquisaAcademica").show();
    $(".IniciacaoCientifica").show();
    $(".Empreendedorismo").show();
    $('.Desenvolvimento').show();
}