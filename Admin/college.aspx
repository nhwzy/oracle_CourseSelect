<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="college.aspx.cs" Inherits="小型管理信息系统.Admin.college" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                学生信息管理系统
                            </a>
                            <div class="sb-sidenav-menu-heading">管理</div>
                            <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts">
                                <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                                信息管理
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div>
                            </a>
                            <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav">
                                    <a class="nav-link" href="college.aspx">学院信息管理</a>
                                    <a class="nav-link" href="major.aspx">专业信息管理</a>
                                    <a class="nav-link" href="student.aspx">学生信息管理</a>
                                    <a class="nav-link" href="course.aspx">课程信息管理</a>
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
                <div class="row">
                    <div class="col-xl-4">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area mr-1"></i>
                                        学院添加
                                    </div> 
                                      <label class="large mb-2" for="insertCollege">学院名称</label>
                                      <asp:TextBox ID="inputCollegeName" runat="server" class="form-control py-2" placeholder="请输入学院名称(中文)" onkeyup="this.value=this.value.replace(/[^\u4e00-\u9fa5]/g,'')" Type="text"></asp:TextBox>  
                                    <div class="form-group d-flex align-items-center  justify-content-center mt-2 mb-1">
                                    &nbsp
                                    <asp:Button ID="CollegeAdd" class="btn btn-primary" runat="server"  Text="确认添加" Width="100px" OnClick="CollegeAdd_Click"/>
                                        </div>
                                </div>
                            </div>
                <div class="col-xl-4">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area mr-1"></i>
                                        学院删除
                                    </div> 
                                      <label class="large mb-2" for="deleteCollege">学院名称</label>
                                       <asp:DropDownList ID="DropDownList1" runat="server" class="form-control py-2" DataSourceID="SqlDataSource1" DataTextField="COLLEGENAME" DataValueField="COLLEGENAME" AppendDataBoundItems="True">
                                           <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                       </asp:DropDownList>
                                    
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;COLLEGENAME&quot; FROM &quot;COLLEGE&quot; ORDER BY &quot;COLLEGEID&quot;"></asp:SqlDataSource>
                                    
                                    <div class="form-group d-flex align-items-center  justify-content-center mt-2 mb-1">
                                    &nbsp
                                    <asp:Button ID="CollegeDelete" class="btn btn-primary" runat="server" Text="确认删除" Width="100px" OnClick="CollegeDelete_Click" />
                                        </div>
                                </div>
                            </div>
                    <div class="col-xl-4">
                                <div class="card mb-4">
                                    <div class="card-header">
                                        <i class="fas fa-chart-area mr-1"></i>
                                        学院名称修改
                                    </div> 
                                      <label class="large mb-2" for="updateCollege">旧学院名称</label>
                                       <asp:DropDownList ID="DropDownList2" runat="server" class="form-control py-2" DataSourceID="SqlDataSource1" DataTextField="COLLEGENAME" DataValueField="COLLEGENAME" AppendDataBoundItems="True">
                                           <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                       </asp:DropDownList>
                                    &nbsp;
                                    <label class="large mb-2">新学院名称</label>
                                    <asp:TextBox ID="inputCollegeNewName" runat="server" class="form-control py-2" placeholder="请新的输入学院名称(中文)" onkeyup="this.value=this.value.replace(/[^\u4e00-\u9fa5]/g,'')" Type="text"></asp:TextBox>
                                    <div class="form-group d-flex align-items-center  justify-content-center mt-2 mb-1">
                                    &nbsp
                                    <asp:Button ID="Collegemodify" class="btn btn-primary" runat="server" Text="确认修改" Width="100px" OnClick="Collegemodify_Click"  />
                                        </div>
                                </div>
                            </div>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table mr-1"></i>
                                学院信息
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="413px" AllowSorting="True">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="COLLEGENAME" HeaderText="学院名称" SortExpression="COLLEGENAME">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                    </asp:GridView>
                                    
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
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>
        <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>
        </form>
        </body>
</html>
