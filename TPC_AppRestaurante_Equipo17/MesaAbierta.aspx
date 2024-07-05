<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MesaAbierta.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.MesaAbierta" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script type="text/javascript">
            function handleImageError(image) {
                image.onerror = null; // prevents looping
                image.src = 'https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg';
            }
    </script>
    <%--Iconos de FontAwesome--%>
    <script src="https://kit.fontawesome.com/0a44d9e8d2.js" crossorigin="anonymous"></script>

    <%--Css--%>
    <link href="Estilos/estiloMiMaster.css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">

                <div>

                    <button id="btnImprimirPreCuenta" class="btn btn-primary" type="button">
                        <svg xmlns="http://www.w3.org/2000/svg" width="26" height="26" fill="currentColor" class="bi bi-cash-coin" viewBox="0 0 16 16" style="--darkreader-inline-fill: currentColor;" data-darkreader-inline-fill="">
                            <path fill-rule="evenodd" d="M11 15a4 4 0 1 0 0-8 4 4 0 0 0 0 8m5-4a5 5 0 1 1-10 0 5 5 0 0 1 10 0"></path>
                            <path d="M9.438 11.944c.047.596.518 1.06 1.363 1.116v.44h.375v-.443c.875-.061 1.386-.529 1.386-1.207 0-.618-.39-.936-1.09-1.1l-.296-.07v-1.2c.376.043.614.248.671.532h.658c-.047-.575-.54-1.024-1.329-1.073V8.5h-.375v.45c-.747.073-1.255.522-1.255 1.158 0 .562.378.92 1.007 1.066l.248.061v1.272c-.384-.058-.639-.27-.696-.563h-.668zm1.36-1.354c-.369-.085-.569-.26-.569-.522 0-.294.216-.514.572-.578v1.1zm.432.746c.449.104.655.272.655.569 0 .339-.257.571-.709.614v-1.195z"></path>
                            <path d="M1 0a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h4.083q.088-.517.258-1H3a2 2 0 0 0-2-2V3a2 2 0 0 0 2-2h10a2 2 0 0 0 2 2v3.528c.38.34.717.728 1 1.154V1a1 1 0 0 0-1-1z"></path>
                            <path d="M9.998 5.083 10 5a2 2 0 1 0-3.132 1.65 6 6 0 0 1 3.13-1.567"></path>
                        </svg>
                        Imprimir Pre-Cuenta
                    </button>
   
                </div>
                

                <div>
                    <label>Personas </label>
                    <asp:Label ID="lblCantidadPersonas" runat="server" CssClass="border border-top-0" Width="44">1 <%#Eval("CantidadPersonas") %></asp:Label>
                </div>

                <div>
                     <label>Cliente  </label>
                     <asp:Label ID="lblCliente" runat="server" Width="44">NombreCliente <%#Eval("NombreUsuario") %></asp:Label>
                </div>

                <div>
                    <label>Mozo  </label>
                     <asp:Label ID="lblMozo" runat="server" Width="44">NombreMozo <%#Eval("NombreMozo") %></asp:Label>
                </div>

                <div>
                    <label>Comentario  </label>
                    <br />
                    <asp:TextBox runat="server" ID="tbxComentario" Enabled="false">Comentario....</asp:TextBox>     
                </div>

                <%--Pedido--%>
                <div>

                    <br />
                    <label>PEDIDO  </label>

                    <%--ventana agregar insumos--%>
                    <div class="container mt-4">
                        <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal">
                            Agregar Platos
                        </button>

                        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-scrollable">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title fs-5" id="exampleModalLabel">Lista Menu</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                                    </div>
                                    <div class="modal-body" >
                                        <iframe src="VentanaAgregarInsumos.aspx" style="width: 100%; height: 100%; border: none;"> </iframe> 

                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary">Save changes</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <br />
                    <ol class="list-group list-group-numbered">
                        <li class="list-group-item">A list item</li>
                        <li class="list-group-item">A list item</li>
                        <li class="list-group-item">A list item</li>
                    </ol>
                </div>
                <label>Subtotal: </label>
                <label>Descuento: </label>
                <label>Total: </label>

                <asp:Button id="btnCerrarMesa" runat="server" CssClass="btn btn-danger" text="Cerrar Mesa" OnClick="btnCerrarMesa_Click"></asp:Button>

            </div>
        </div>
    </form>
</body>
</html>
