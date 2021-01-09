<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="PracticaQuinto.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrarse</title>
    <!-- CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="css/login.css">
    <!-- alertas style -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
    <!-- JS, alertas -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>

<script src="js/jquery-3.5.1.min.js"></script>
</head>
<body class="login-page">
    <form id="Frm_Registrarse" runat="server">
        <asp:ScriptManager ID="Scm" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <asp:HiddenField ID="hdf_Cedula" runat="server"></asp:HiddenField>


                <section class="h-100">
                    <div class="container h-100">
                        <div class="row justify-content-md-center h-100">
                            <div class="card-wrapper">

                                <br>
                                <br>

                                <div class="card fat">
                                    <div class="card-body">
                                        <h4 class="card-title">Crear una Cuenta</h4>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtCedula" onkeypress="return SoloNumeros(event);" CssClass="form-control" ClientIDMode="Static" MaxLength="10" placeholder="Cedula" required="true" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre Completo" required="true" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtDireccion" CssClass="form-control" placeholder="Direccion" required="true" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:TextBox ID="txtCorreo" TextMode="Email" title="Formato de correo electronico. Todo en minuscula" pattern="[a-z-0-9_]+([.][a-z-0-9_]+)*@[a-z-0-9_]+([.][a-z-0-9_]+)*[.][a-z]{1,5}" CssClass="form-control" placeholder="Correo Electronico" required="true" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="row">
                                            <div class="col">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" required="true" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtUsuario" ClientIDMode="Static" CssClass="form-control" placeholder="Usuario" required="true" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtContrasenia" CssClass="form-control" placeholder="Contraseña" required="true" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="Drp_Rol" required="true" CssClass="form-control" runat="server">
                                                        <asp:ListItem Text="Seleccionar" Value=""></asp:ListItem>

                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="custom-checkbox custom-control">
                                                <input type="checkbox" name="agree" id="agree" class="custom-control-input">
                                                <label for="agree" class="custom-control-label">
                                                    Estoy de acuerdo con los <a href="#">Términos y Condiciones</a></label>
                                                <div class="invalid-feedback">
                                                    Debes estar de acuerdo con nuestros términos y condiciones.
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group m-0">
                                            <asp:Button ID="btnRegistrarse" OnClientClick="ValidarCedula(); " CssClass="btn btn-dark btn-block" runat="server" OnClick="btnRegistrarse_Click" Text="Registrarse" />
                                        </div>
                                        <div class="mt-4 text-center">
                                            Ya tienes una cuenta? <a href="Login.aspx">Iniciar Sesión</a>
                                        </div>

                                    </div>
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

    <script>

        function SoloNumeros(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) { return false }
            }
        }

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

        function ValidarCedula() {


            var xx = document.getElementById("<%=hdf_Cedula.ClientID%>");
            xx.value = 0;

            var cad = document.getElementById("txtCedula").value.trim();
            var total = 0;
            var longitud = cad.length;
            var longcheck = longitud - 1;

            if (cad !== "" && longitud === 10) {
                for (i = 0; i < longcheck; i++) {
                    if (i % 2 === 0) {
                        var aux = cad.charAt(i) * 2;
                        if (aux > 9) aux -= 9;
                        total += aux;
                    } else {
                        total += parseInt(cad.charAt(i)); // parseInt o concatenará en lugar de sumar
                    }
                }

                total = total % 10 ? 10 - total % 10 : 0;

                if (cad.charAt(longitud - 1) != total) {

                    xx.value = 0;
                } else {
                    xx.value = 1;
                }

            }

        }

    </script>
</body>
</html>


