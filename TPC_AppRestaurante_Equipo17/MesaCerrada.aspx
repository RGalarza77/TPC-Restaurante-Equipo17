<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MesaCerrada.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.MesaCerrada" %>

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

                <%--Pesonas--%>

                <div class="btn-group" role="group" aria-label="Basic mixed styles example">

                    <div style="display: block; text-align: center; margin-left: 20px;">

                        <label>Personas <span style="color: #FF0000; font-weight: bold">*</span></label>
                        <asp:Button ID="btnRestar" runat="server" CssClass="btn btn-success" Text=" - " OnClick="btnRestar_Click" />
                        <asp:Label ID="lblCantidadPersonas" runat="server" CssClass="border border-top-0" Width="44">1 <%#Eval("CantidadPersonas") %></asp:Label>
                        <asp:Button ID="btnSumar" runat="server" CssClass="btn btn-success" Text=" + " OnClick="btnSumar_Click" />

                    </div>

                </div>
                <%--Cliente--%>

                <div class="dropdown-center">


                    <label>Cliente  </label>
                    <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Seleccione un cliente
                    </button>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item" href="#">Cliente 1</a></li>
                        <li><a class="dropdown-item" href="#">Cliente 2</a></li>
                        <li><a class="dropdown-item" href="#">Cliente 3</a></li>
                    </ul>
                </div>
                <%--Mozo--%>

                <div class="dropdown-center">


                    <label>Mozo  </label>
                    <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Seleccione un mozo
                    </button>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item" href="#">Mozo 1</a></li>
                        <li><a class="dropdown-item" href="#">Mozo 2</a></li>
                        <li><a class="dropdown-item" href="#">Mozo 3</a></li>
                    </ul>
                </div>

                <%--Comentario--%>
                <label>Comentario  </label>
                <div class="form">
                    <textarea class="form-control" placeholder="Comentario" id="floatingTextarea2" style="height: 100px"></textarea>
                </div>
               
                <asp:Button ID="btnAbrirMesa" runat="server" CssClass="btn btn-success" Text="Abrir Mesa" OnClick="btnAbrirMesa_Click"></asp:Button>

            </div>
        </div>
    </form>
</body>
</html>
