<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAgregarMesa.aspx.cs" Inherits="TPC_AppRestaurante_Equipo17.frmAgregarMesa" %>

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
                <div >
                    <label for="formGroupExampleInput" class="form-label">Numero de Mesa</label>
                    <input type="text" class="form-control" id="formGroupExampleInput" placeholder="Numero de mesa">
                </div>
                <div >
                    <label for="formGroupExampleInput2" class="form-label">Another label</label>
                    <input type="text" class="form-control" id="formGroupExampleInput2" placeholder="Another input placeholder">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
