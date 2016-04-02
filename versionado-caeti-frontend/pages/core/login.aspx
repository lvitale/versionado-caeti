<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="versionado_caeti_frontend.pages.core.login"  MasterPageFile="~/pages/master-page/default.Master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" Runat="Server">

    <script language="javascript" type="text/javascript">

</script>

<table style="WIDTH:100%; HEIGHT:100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center">
						<table border="0"  cellpadding="2" cellspacing="0" class="TablaContenedora"
							style="WIDTH:375px; HEIGHT:250px">
							<tr class="bgCabecera">
								<td width="67" valign="bottom" style="height: 23px"><div align="center"><img src="../../images/Loguin.gif" width="55" height="16"></div>
								</td>
								<td width="298" valign="bottom" style="height: 23px"><span class="txtCabecera">Ingrese su usuario y contrasenia 
										</span>
								</td>
							</tr>
							<tr class="bgCabecera">
								<td height="5" colspan="2" valign="bottom"></td>
							</tr>
							<tr>
								<td height="150" colspan="2" align="center" valign="top"><fieldset>
										<legend>
											&nbsp;&nbsp;&nbsp;Login&nbsp;&nbsp;&nbsp;</legend>
										<table width="280" border="0" align="center" cellpadding="0" cellspacing="0">
											<tr>
												<td height="10" colspan="2"></td>
											</tr>
											<tr>
												<td height="20" style="width: 180px"><div align="right"><span class="txt"><asp:Label runat="server" Text="Usuario" ID="lblinusuario"></asp:Label>
															<asp:TextBox id="txtUsuario" runat="server" CssClass="campos"></asp:TextBox>&nbsp;
														</span>
													</div>
												</td>
												<td rowspan="3" valign="top" style="width: 100px"><div align="right"><img src="../../images/usuario.png" width="75" height="79" border="1"></div>
												</td>
											</tr>
											<tr>
												<td height="20" style="width: 180px"><div align="right"><span class="txt"><asp:Label runat="server" Text="clave" ID="lblClave"></asp:Label>
															<asp:TextBox id="txtPassword" runat="server" CssClass="campos" TextMode="Password"></asp:TextBox>&nbsp;
														</span>
													</div>
												</td>
											</tr>
											<tr>
												<td style="width: 180px"><div align="right"><span class="txt">
															<asp:Button id="btnIngresar" runat="server" CssClass="botones" Text="ingresar" OnClick="btnIngresar_Click"></asp:Button>&nbsp;
														</span>
													</div>
												</td>
											</tr>
											<tr>
												<td colspan="2" style="height: 10px">
                                                    &nbsp;<asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="* Usuario no válido"></asp:RequiredFieldValidator>
                                                    <br />
                            <asp:RequiredFieldValidator ID="rq2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="* Contraseña no válida."></asp:RequiredFieldValidator><br />
                                                    <asp:Label ID="lblInvalido" runat="server" ForeColor="Red" Text="* Usuario o contraseña inválidos."
                                                        Visible="False" Width="276px"></asp:Label></td>
											</tr>
											<tr>
											  <td><asp:Label ID="lblMessage" Visible="False" runat="server" Font-Bold="True"/></td>
											</tr>
										</table>
									</fieldset>
									<p>        <asp:HyperLink ID="HyperLink1" runat="server" Font-Overline="False" 
                                            Font-Underline="False" ForeColor="#000099" 
                                            NavigateUrl="~/pages/bussiness/lostPassword.aspx" Font-Bold="True" 
                                            Font-Size="Smaller">Olvido su password</asp:HyperLink></p>
								</td>
							</tr>
							<tr>
								<td colspan="2" align="center" valign="top"><span class="txtMenu">
										<asp:Label id="lblAnio" runat="server"></asp:Label>
										- Uai software / todos los derechos reservados</span></td>
							</tr>
						</table>
						<div ><br></br>
						</div>
						<div align="left">
                            &nbsp;</div>
					</td>
				</tr>
			</table>
  </asp:Content>  