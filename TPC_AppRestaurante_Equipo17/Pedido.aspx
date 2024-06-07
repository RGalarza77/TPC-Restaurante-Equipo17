<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-6">
            <h2>Platos Disponibles</h2>
            <div class="row">
                <asp:Repeater ID="repInsumos" runat="server">
                    <ItemTemplate>
                        <div class="col-6">

                            <div class="card" style="width: 18rem">
                                <img src="https://static.vecteezy.com/system/resources/thumbnails/004/141/669/small/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" class="card-img-top">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Name") %></h5>
                                    <p class="card-text"><%#Eval("Categoria") %></p>
                                </div>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item"><%#Eval("Precio") %></li>
                                </ul>
                                <div class="card-body">
                                    <button type="button" class="btn btn-success">Agregar al Carrito</button>
                                </div>
                            </div>
                            <hr />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <h2>Orden mesa 1</h2>
            <ul class="list-group">
                <li class="list-group-item">An item</li>
                <li class="list-group-item">A second item</li>
                <li class="list-group-item">A third item</li>
                <li class="list-group-item">A fourth item</li>
                <li class="list-group-item">And a fifth one</li>
            </ul>
        </div>
    </div>
</asp:Content>
