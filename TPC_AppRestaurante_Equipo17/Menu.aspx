<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <asp:Repeater ID="repInsumos" runat="server">
            <ItemTemplate>
                <div class="col 4">

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

</asp:Content>
