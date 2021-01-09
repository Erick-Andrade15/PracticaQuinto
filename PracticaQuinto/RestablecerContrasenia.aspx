<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerContrasenia.aspx.cs" Inherits="PracticaQuinto.RestablecerContrasenia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Restablecer Contraseña</title>
    <!-- CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="css/login.css">
    <!-- alertas style -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
    <!-- JS, alertas -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
</head>
<body class="login-page">
    <form id="Frm_RestablecerContrasenia" runat="server">

        <asp:ScriptManager ID="Scm" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <section class="h-100">
                    <div class="container h-100">
                        <div class="row justify-content-md-center align-items-center h-100">
                            <div class="card-wrapper">
                                <div class="brand">
                                    <img src="img/logo.jpg" alt="Logo" />
                                </div>
                                <div class="card fat">
                                    <div class="card-body">
                                        <h4 class="card-title">Restablecer la contraseña</h4>

                                        <div class="form-group">
                                            <label for="new-password">Nueva contraseña</label>
                                            <asp:TextBox ID="txtContrasenia" CssClass="form-control" required="" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="new-password">Confirmar contraseña</label>
                                            <asp:TextBox ID="txtConfirmarContrasenia" CssClass="form-control" required="" runat="server"></asp:TextBox>

                                            <div class="form-text text-muted">
                                                Asegúrese de que su contraseña sea segura y fácil de recordar
                                            </div>
                                        </div>

                                        <div class="form-group m-0">
                                            <asp:Button ID="btnRestablecer" OnClick="btnRestablecer_Click" CssClass="btn btn-dark btn-block" runat="server" Text="Restablecer" />
                                        </div>

                                    </div>
                                </div>
                                <div class="footer">
                                    Copyright &copy; 2020 | Anaramsa 
                                </div>
                            </div>
                        </div>
                    </div>
                </section>

            </ContentTemplate>
        </asp:UpdatePanel>



    </form>

    <!-- jQuery and JS bundle w/ Popper.js -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>

    <script type="text/javascript">            

        function MostrarAlerta(Mensaje, Tipo) {

            switch (Tipo) {

                case 'Error':
                    Command: toastr["error"](Mensaje, "Error")

                    toastr.options = {
                        "closeButton": false,
                        "debug": false,
                        "newestOnTop": false,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }

                    break;
                case 'Exitoso':
                    Command: toastr["success"](Mensaje, "Operacion Exitosa")

                    toastr.options = {
                        "closeButton": false,
                        "debug": false,
                        "newestOnTop": false,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }
                    break;
                case 'Informativo':

                    Command: toastr["info"](Mensaje, "Informacion")

                    toastr.options = {
                        "closeButton": false,
                        "debug": false,
                        "newestOnTop": false,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }

                    break;
                default:
                    console.log('Lo lamentamos, Error al mostrar la Alerta.');
            }
        }



    </script>

</body>
</html>
