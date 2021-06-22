<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="小型管理信息系统.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <link href="../css/style.css" rel="stylesheet" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js" crossorigin="anonymous"></script>
    </head>
    <body class="bg-primary">
        <form  runat="server">
        <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header"><h3 class="text-center font-weight-light my-4">Login</h3></div>
                                        <div class="card-body">
                                        
                                            <div class="form-group">
                                                <label class="small mb-1" for="inputadmin">学号</label>
                                    &nbsp;<asp:TextBox ID="inputadmin" runat="server" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;" class="form-control py-3"  placeholder="请输入学号"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="adminerror"  runat="server" ControlToValidate="inputadmin" ErrorMessage="*学号不能为空" Font-Size="Small" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </div>
                                            <div class="form-group">
                                                
                                                <label class="small mb-1" for="inputPassword">Password</label>
                                                <asp:TextBox ID="inputpassword" class="form-control py-3" runat="server" placeholder="Enter password" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="passworderror" runat="server" ControlToValidate="inputpassword" ErrorMessage="*密码不能为空" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        
                                            <div class="form-group d-flex align-items-center  mt-4 mb-0">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="login" class="btn btn-primary" runat="server"  OnClick="Login_Click" Text="Login"  />
                                            </div>
                                    </div>  
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
           </div>
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="../js/scripts.js"></script>
        </form>
    </body>
</html>
