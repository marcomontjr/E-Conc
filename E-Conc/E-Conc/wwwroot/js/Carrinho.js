$(document).ready(function () {
    $('#CarrinhoModal').modal('show')

    $("#removeButton").click(function() {
        $('#RemoverItemCarrinhoModal').modal('show')
    });

    $("#resumoButton").click(function () {
        $('#FinalizarPedidoModal').modal('show')
    });
});