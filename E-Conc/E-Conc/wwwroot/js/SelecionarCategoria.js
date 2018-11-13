$('#Categorias').change(function () {
    var categoriaEscolhida = $(this).val();
    if (categoriaEscolhida === "Desenvolvimento") {
        MostraDesenvolvimento();
        return;
    } else if (categoriaEscolhida === "Empreendedorismo") {
        MostraEmpreendedorismo();
        return;
    } else if (categoriaEscolhida === "Iniciacao_Cientifica") {
        MostraIniciacaoCientifica();
        return;
    } else if (categoriaEscolhida === "Pesquisa_Academica") {
        MostraPesquisaAcademica();
        return;
    }

    MostraTudo();
});

function MostraDesenvolvimento() {
    $('.Desenvolvimento').show();
    $(".Empreendedorismo").hide();
    $(".Iniciacao_Cientifica").hide();
    $(".Pesquisa_Academica").hide();
}

function MostraEmpreendedorismo() {
    $(".Empreendedorismo").show();
    $('.Desenvolvimento').hide();
    $(".Iniciacao_Cientifica").hide();
    $(".Pesquisa_Academica").hide();
}

function MostraIniciacaoCientifica() {
    $(".Iniciacao_Cientifica").show();
    $(".Empreendedorismo").hide();
    $('.Desenvolvimento').hide();
    $(".Pesquisa_Academica").hide();
}

function MostraPesquisaAcademica() {
    $(".Pesquisa_Academica").show();
    $(".Iniciacao_Cientifica").hide();
    $(".Empreendedorismo").hide();
    $('.Desenvolvimento').hide();
}

function MostraTudo() {
    $(".Pesquisa_Academica").show();
    $(".Iniciacao_Cientifica").show();
    $(".Empreendedorismo").show();
    $('.Desenvolvimento').show();
}