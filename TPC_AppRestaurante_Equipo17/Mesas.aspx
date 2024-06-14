<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="row">

            <%--Agregar Mesa--%>
            <div>

                <button id="btnAgregarMesa" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
                    Agregar Mesa
                </button>

                <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="exampleModalLabel">Agregar Nueva Mesa</h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <iframe src="frmAgregarMesa.aspx" style="width: 100%; height: 100%; border: none;"></iframe>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <button type="button" class="btn btn-success">Agregar</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <p class="fs-5">Sucursal</p>
            <select class="form-select form-select-lg mb-3" aria-label="Large select example">
                <option selected>Sucursal 1</option>
                <option value="1">Sucursal 2</option>
                <option value="2">Sucursal 3</option>
                <option value="3">Sucursal 4</option>
            </select>

            <select class="form-select form-select-sm" aria-label="Small select example">
                <option selected>Salon</option>
                <option value="1">Piso 1</option>
                <option value="2">Terraza</option>
                <option value="3">Vereda</option>
            </select>

            <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                <p class="fs-1">MESAS DISPONIBLES</p>
            </div>

            <asp:Repeater ID="repMesas" runat="server" >

                <ItemTemplate>
                    <div class="col-4">


                        <button class="btn btn-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample">
                            <%#"Mesa "+ Eval("NumeroMesa") %>
                        </button>

                        <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
                            
                            <div class="offcanvas-header">
                                <label><%#"Mesa "+ Eval("NumeroMesa") %></label>
                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                            </div>
                            <div class="offcanvas-body">
                                <iframe src="MesaCerrada.aspx" style="width:100%; height:100%; border:none;"></iframe>
                            </div>
                        </div>


                    </div>
                </ItemTemplate>
            </asp:Repeater>
       </div>


</asp:Content>
