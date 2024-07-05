<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>



    <div class="row">

        <%--SALON--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <asp:DropDownList runat="server" ID="ddlSalones" CssClass="form-select form-select-lg mb-3" aria-label="Large select example" AutoPostBack="true" OnSelectedIndexChanged="ddlSalones_SelectedIndexChanged"></asp:DropDownList>

            </ContentTemplate>
        </asp:UpdatePanel>  
            
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <%--Agregar Mesa--%>
                <div>
                  <asp:Button runat="server" ID="btnAgregar" type="button" class="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click"></asp:Button>
                </div>

                <%--Eliminar Mesa--%>
                <div>
                    <asp:Button runat="server" ID="btnEliminar" type="button" class="btn btn-success" Text="Eliminar" OnClick="btnEliminar_Click"></asp:Button>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

                
                <%--titulo--%>
                <div class="d-grid gap-2 d-md-flex justify-content-md-center">
                    <p class="fs-1">MESAS DISPONIBLES</p>
                </div>

                <%--MESAS--%>
                <asp:updatepanel runat="server">
                    <ContentTemplate>

                        <asp:Repeater ID="repMesas" runat="server">

                            <ItemTemplate>
                                <div class="col-4">
                                    <div class="container">

                                        <asp:LinkButton ID="lbtMesa" runat="server" CssClass='<%# ObtenerButtonClass(Eval("Estado")) %>' Text='<%# "Mesa " + Eval("NumeroMesa") %>' data-bs-toggle="offcanvas" data-bs-target='<%# "#offcanvasExample" + Container.ItemIndex %>'
                                            aria-controls='<%# "offcanvasExample" + Container.ItemIndex %>' />


                                        <div class="offcanvas offcanvas-end" tabindex="-1" id='<%# "offcanvasExample" + Container.ItemIndex %>' aria-labelledby='<%# "offcanvasExampleLabel" + Container.ItemIndex %>'>

                                            <div class="offcanvas-header">
                                                <label><%#"Mesa "+ Eval("NumeroMesa") %></label>
                                                <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                                            </div>
                                            <div class="offcanvas-body">
                                                
                                                <iframe src='<%# ObtenerIframeMesasSrc(Eval("Estado"), Eval("Id")) %>' style="width: 100%; height: 100%; border: none;"></iframe>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ContentTemplate>
                </asp:UpdatePanel>
    </div>

</asp:Content>
