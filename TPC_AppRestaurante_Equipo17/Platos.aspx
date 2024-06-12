<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Platos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <a class="btn btn-primary" data-bs-toggle="offcanvas" href="#Agregar" role="button">NUEVO PLATO</a>
    </div>

    <div class="offcanvas offcanvas-start" tabindex="-1" id="Agregar" aria-labelledby="offcanvasExampleLabel">
        <div class="offcanvas-header">
            <h3 class="offcanvas-title display-5" id="offcanvasExampleLabel">Agregar Plato</h3>
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <div>

                <label for="txtCodProd" class="form-label">Codigo Producto</label>
                <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" />
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtPrecio" CssClass="form-control" /><br />
                <asp:Button Text="Agregar Plato" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />


            </div>
        </div>
    </div>


</asp:Content>
