<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorpages.aspx.cs" Inherits="versionado_caeti_frontend.pages.core.errorpages" MasterPageFile="~/pages/master-page/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">

    <script language="javascript" type="text/javascript">

</script>

  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;<br />
    <center>
    <br />
    <asp:TextBox ForeColor="red" runat="server" id="txtError" style="margin-left: 0px" 
            Width="423px"  Enabled="false"></asp:TextBox><br />
    <br />
    &nbsp; &nbsp; &nbsp;&nbsp;<asp:Image ID="Image1" runat="server" 
            ImageUrl="~/images/peligro.jpg" Height="200px" Width="200"/><br />
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
