<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grade.aspx.cs" Inherits="小型管理信息系统.Student.grade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>主页</title>
        <link href="../css/style.css" rel="stylesheet" />
        <link href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css" rel="stylesheet" crossorigin="anonymous" />
        <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js" crossorigin="anonymous"></script>
    </head>
    <body class="sb-nav-fixed">
        <form id="form1" runat="server">
        <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <a class="navbar-brand" href="index.aspx">学生信息管理系统</a>
            <button class="btn btn-link btn-sm order-1 order-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
            <!-- Navbar Search-->
                <div class="input-group">
                    
                </div>
            <!-- Navbar-->
            <ul class="navbar-nav ml-auto ml-md-0">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="userDropdown" href="#!" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="userDropdown">
                        <a class="dropdown-item" href="#!">Settings</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="login.aspx">Logout</a>
                    </div>
                </li>
                
            </ul>
            </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <div class="sb-sidenav-menu-heading">总览</div>
                            <a class="nav-link" href="index.aspx">
                                <div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                                学生选课系统
                            </a>
                            <div class="sb-sidenav-menu-heading">菜单</div>
                            <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts">
                                <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                                菜单
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div>
                            </a>
                            <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav">
                                    <a class="nav-link" href="select.aspx">选课</a>
                                    <a class="nav-link" href="grade.aspx">成绩</a>
                                </nav>
                            </div>
                            <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePages" aria-expanded="false" aria-controls="collapsePages">
                                <div class="sb-nav-link-icon"><i class="fas fa-book-open"></i></div>
                                快速跳转
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div>
                            </a>
                            <div class="collapse" id="collapsePages" aria-labelledby="headingTwo" data-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav accordion" id="sidenavAccordionPages">
                                            <a class="nav-link" href="../User/login.aspx">登陆页面</a>
                                        </nav>
                            </div> 
                    </div> 
                  </div>
                </nav>
            
            </div>
            <div id="layoutSidenav_content">
            <main>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table mr-1"></i>
                                成绩总览
                            </div>
                            <div class="card-body">
                                <div class="form-row">
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label class="small mb-1" >课程号</label>
                                            <asp:TextBox ID="inputCourseID" runat="server" class="form-control py-2 "   oninput = "this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                        </div>
                                        </div>
                                       <div class="col-md-2">
                                        <div class="form-group">
                                            <label class="small mb-1" >课程名</label>  
                                            <asp:DropDownList ID="CourseName" runat="server"  class="form-control py-2"  AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="CNAME" DataValueField="CNAME" >
                                                <asp:ListItem Value="">--请选择--</asp:ListItem>
                                            </asp:DropDownList>                              

                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;CNAME&quot; FROM &quot;C&quot; ORDER BY &quot;CNO&quot;"></asp:SqlDataSource>

                                        </div>                                   
                                      </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label class="small mb-1">学分</label>
                                            <asp:TextBox ID="CourseCredit" runat="server" class="form-control py-2"   onkeyup="this.value=this.value.replace(/[^\d]/g,'')" ></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label class="small mb-1" >成绩</label>
                                            <asp:TextBox ID="CourseGrade" runat="server" class="form-control py-2"   oninput = "this.value=this.value.replace(/[^\d]/g,'')" Type="text">
                                            </asp:TextBox>
                                        </div>                                   
                                      </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label class="small mb-3" ></label>
                                            <asp:Button ID="search" class="form-control py-2 btn btn-primary" runat="server" Text="查找" BorderStyle="None" OnClick="search_Click" />
                                        </div>                                   
                                      </div>
                                    </div>


                                <div class="form-group">
                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="527px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />

                                </asp:GridView>
                                    </div>
                                </div>
                            </div>
                </main>
                </div>
            </div>
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="../js/scripts.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>
        </form>
        </body>
</html>
