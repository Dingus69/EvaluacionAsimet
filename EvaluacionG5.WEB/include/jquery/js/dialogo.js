function mostrarAlert(objeto, titulo, mensaje){
//      $('#'+ objeto + '').html('<p>' + mensaje + '</p>'); 
      var texto = mensaje
      //$('#'+ objeto + '').html('<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>' + texto + '</p>'); 
      $('#'+ objeto + '').dialog({
        title: titulo,
        resizable: false,
        width: 'auto',
        height: 'auto',
        show: "fade",
        hide: "fade",
        modal: true,
        buttons: {
          Aceptar: function() {
            $( this ).dialog( "close" );
          }
        }
      });
    }
function mostrarForm(dialog_form, titulo){
      $('#'+ dialog_form + '').dialog({
        title: titulo,
        show: "fade",
        hide: "fade",
        modal: true,   
        width:'auto',
        open:function(){{
          $(this).parent().appendTo($("form:first"));
        }},
        close: function(){
          $(this).remove();
        }
      });
      return false;          
    }
    
function cerrarForm(dialog_form){
      $( this ).dialog( "close" );
  }

  function mostrarAlertRedirigir(objeto, titulo, mensaje, url) {
      //      $('#'+ objeto + '').html('<p>' + mensaje + '</p>'); 
      var texto = mensaje
      $('#' + objeto + '').html('<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>' + texto + '</p>');
      $('#' + objeto + '').dialog({
          title: titulo,
          resizable: false,
          width: 'auto',
          height: 'auto',
          show: "fade",
          hide: "fade",
          modal: true,
          buttons: {
              Aceptar: function() {
              window.location = url;
              return false;
              }
          }
      });
  }