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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

                    <%--ventana agregar pedido--%>
                    <div class="container mt-4">
                        <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal">
                            Agregar Pedido
                        </button>
                        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" style="border: solid;">
                            <div class="modal-dialog modal-fullscreen">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title fs-5" id="exampleModalLabel">Lista Menu</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                                    </div>
                                    <div class="modal-body">

                                        <%--NavBar--%>
                                        <nav>
                                            <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                                <button class="nav-link active" id="nav-principal-tab" data-bs-toggle="tab" data-bs-target="#nav-principal" type="button" role="tab" aria-controls="nav-principal" aria-selected="true">Platos Principales</button>
                                                <button class="nav-link" id="nav-postre-tab" data-bs-toggle="tab" data-bs-target="#nav-postre" type="button" role="tab" aria-controls="nav-postre" aria-selected="false">Postres</button>
                                                <button class="nav-link" id="nav-bebida-tab" data-bs-toggle="tab" data-bs-target="#nav-bebida" type="button" role="tab" aria-controls="nav-bebida" aria-selected="false">Bebidas</button>
                                            </div>
                                        </nav>
                                        <div class="tab-content" id="nav-tabContent">
                                            <%--Menu Platos pricipales--%>
                                            <div class="tab-pane fade show active" id="nav-principal" role="tabpanel" aria-labelledby="nav-principal-tab" tabindex="0">
                                                <asp:GridView runat="server" ID="dgvPrincipal" OnSelectedIndexChanged="dgvPrincipal_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-striped">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" ControlStyle-CssClass="form-check-label" />
                                                        <asp:CheckBoxField HeaderText="Pedir" DataField="Agregado" ControlStyle-CssClass="form-check-input me-1" />
                                                        <asp:CommandField ShowSelectButton="true" SelectText="Agregar" HeaderText="Agregar" />

                                                    </Columns>
                                                </asp:GridView>

                                            </div>

                                            <%--Menu Postres--%>
                                            <div class="tab-pane fade" id="nav-postre" role="tabpanel" aria-labelledby="nav-postre-tab" tabindex="0">
                                                <asp:GridView runat="server" ID="dgvPostre" OnSelectedIndexChanged="dgvPostre_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-striped">

                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" ControlStyle-CssClass="form-check-label" />
                                                        <asp:CheckBoxField HeaderText="Pedir" DataField="Agregado" ControlStyle-CssClass="form-check-input me-1" />
                                                        <asp:CommandField ShowSelectButton="true" SelectText="Agregar" HeaderText="Agregar" />
                                                    </Columns>

                                                </asp:GridView>

                                            </div>

                                            <%--Menu Bebidas--%>
                                            <div class="tab-pane fade" id="nav-bebida" role="tabpanel" aria-labelledby="nav-bebida-tab" tabindex="0">
                                                <asp:GridView runat="server" ID="dgvBebida" OnSelectedIndexChanged="dgvBebida_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-striped">

                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" ControlStyle-CssClass="form-check-label" />
                                                        <asp:CheckBoxField HeaderText="Pedir" DataField="Agregado" ControlStyle-CssClass="form-check-input me-1" />
                                                        <asp:CommandField ShowSelectButton="true" SelectText="Agregar" HeaderText="Agregar" />

                                                    </Columns>

                                                </asp:GridView>
                                            </div>
                                        </div>

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
                    <%--Lista Pedido--%>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Repeater runat="server" ID="repListaPedido">
                                <HeaderTemplate>
                                    <ul class="list-group list-group-numbered">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="list-group-item"><%# Eval("Nombre")%>
                                    <div class="col-10">
                                        <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                            <asp:Button ID="btnRestar" runat="server" CssClass="btn btn-success" Text=" - " OnClick="btnRestar_Click" CommandArgument='<%#Eval("Id") %>' />
                                            <div style="display: block; text-align: justify; margin: auto;">
                                                <asp:Label ID="lblCantidadPedido" runat="server" Width="50" BorderStyle="None" Text='<%# Eval("Cantidad") %>'></asp:Label>
                                            </div>
                                            <asp:Button ID="btnSumar" runat="server" CssClass="btn btn-success" Text=" + " OnClick="btnSumar_Click" CommandArgument='<%#Eval("Id") %>' />
                                        </div>

                                        <asp:Button runat="server" ID="btnEliminarInsumo" CssClass="btn btn-secondary" Text="Eliminar Pedido" OnClick="btnEliminarInsumo_Click" CommandArgument='<%# Eval("Id") %>'></asp:Button>
                                    </div>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--vaciar lista--%>
                    <br />
                    <asp:Button runat="server" ID="btnVaciarLista" Text="Vaciar Listado" OnClick="btnVaciarLista_Click" CssClass="btn btn-danger" Visible="false"></asp:Button>

                </div>
                <hr />

                <figure class="text-center">
                    <blockquote class="blockquote">
                        <div>
                            <asp:Label runat="server" ID="lblSubtotal"></asp:Label>
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblDescuento"> </asp:Label>
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblTotal" CssClass="h2"> </asp:Label>
                        </div>
                        <asp:Label runat="server" ID="lblListaSinPedidos" Visible="false">No posee insumos agregados en el listado de pedidos</asp:Label>

                    </blockquote>
                </figure>
                <hr />

            </div>
            <div class="text-center">
                <asp:Button ID="btnCerrarMesa" runat="server" CssClass="btn btn-danger" Text="Cerrar Mesa" OnClick="btnCerrarMesa_Click" Width="80%"></asp:Button>
            </div>

        </div>
    </form>
</body>
</html>
