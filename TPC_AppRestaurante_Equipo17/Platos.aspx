<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Platos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtCodProd" class="form-label">Codigo Producto</label>
                <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtPrecio" CssClass="form-control" />
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <img src="https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=" class="img-thumbnail" alt="400">
                <div class="row">



                </div>
                
            </div>
        </div>
        <div class="col-4">
                    <div class="col-6"></div>
                <div class="col-4">
                    <div class="mb-4">
                        <br />
                        <asp:Button Text="Agregar Imagen" ID="btnAgregarImagen" cssclass="btn btn-primary" runat="server" />
                    </div>
                    <div class="mb-4">
                    </div>
                    <asp:Button Text="Ingredientes" ID="btnIngredientes" cssclass="btn btn-primary" runat="server" />
                </div>


        </div>
    </div>
</asp:Content>
