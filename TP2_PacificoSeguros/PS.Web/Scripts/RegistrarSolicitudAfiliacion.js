$(document).ready(function (e) {
    $("#btnValidar").click(function (event) {
        event.preventDefault();
        var ruc = $("#RUC").val();
        if (ruc.length == 11 && Math.floor(ruc) == ruc && $.isNumeric(ruc)) {
            $.ajax({
                url: "/Gestion/ValidarRUC",
                type: "GET",
                data: { RUC: ruc },
                success: function (data) {
                    if (data == false) {
                        alert('El RUC ingresado no se encuentra en la lista de prestadoras invitadas.');
                        $("#Nombre").val('');
                        $("#Direccion").val('');
                        $("#Tipo_Descripcion").val('');
                        $("#Tipo_Id").val('');
                    } else {
                        $("#Nombre").val(data.Nombre);
                        $("#Direccion").val(data.Direccion);
                        $("#Tipo_Descripcion").val(data.Tipo.Descripcion);
                        $("#Tipo_Id").val(data.Tipo.Id);
                    }
                },
                error: function (data) {
                    alert('error');
                }
            })
        } else {         
            
        alert('Ingrese un RUC válido de 11 dígitos.')
                $("#RUC").focus();
                
        }           

    });
});
