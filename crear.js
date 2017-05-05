/// <reference path="crear.js" />
(function() {
    'use strict';


    $.ajax({
        method: 'get',
        url: '/Comentario/BuscarUsuario',
        type: 'application/json'

    }).done(function (resultadoUser) {
        var table = $('#opciones');
        for (var i = 0; i < resultadoUser.length; i++) {
            var item = resultadoUser[i];
            table.append('<option value="' + item.IdUsuario + '">' + item.Nombre + '</option>');

        }
    }).fail(function (err) {
        console.error(err);
    });


    $('#verificar').click(function() {
        var email = document.getElementById('Email').value;
        $.ajax({
            method: 'get',
            url: '/CrearUsuario/VerificarDisponibilidad',
            data: $.param({ email: email }),
            type: 'applicaton/json'
        }).done(function (result) {
            if (result.Existe) {
                alert('ya existe un usuario registrado con este correo');
                $('#enviar').prop('disabled', true);
            } else {
                $('#enviar').prop('disabled', false);
            }
        }).fail(function (error) {
            alert('error');
        });
    });

    


    var interval;
    $('#BuscarComent').keyup(function () {

        clearTimeout(interval);
        var self = this;
        interval = setTimeout(function() {
            $.ajax({
                method: 'get',
                url: '/Comentario/Buscar',
                data: 'termino=' + self.value,
                type: 'application/json'
            }).done(function (result) {
                //si esta vacio
                var table = $('#results tbody');
                table.html('');
                if (result.length == 0) {
                    table.html('<tr><td colspan="2">No se encontraron resultados</td></tr>');
                    return;
                }

                //Si hay una letra

                for (var i = 0; i < result.length; i++) {
                    var item = result[i];
                    table.append('<tr><td>'+item.IdUsuario+'</td><td>'+item.Comentario+'</td></tr>');
                }
            }).fail(function (err) {
                console.error(err);
            });
        }, 1500);
    });

           $('#opciones').on('change', function(){
               var id = $('#opciones').val();
            // alert(id)
                   $.ajax({
                       method: 'get',
                       url: '/Comentario/BuscaridUser',
                       data: { 'iduser': id },
                       type: 'application/json'
                   }).done(function (result) {
                       var table = $('#results tbody');

                       table.html('');
                       if (result.length == 0) {
                           table.html('<tr><td colspan="2">No se encontraron resultados</td></tr>');
                           return;
                       }
                       for (var i = 0; i < result.length; i++) {
                           var item = result[i];
                           table.append('<tr><td>' + item.IdUsuario + '</td><td>' + item.Comentario + '</td></tr>');
                       }
                   }).fail(function (error) {
                       console.error(error);
                   });
           });




})();

