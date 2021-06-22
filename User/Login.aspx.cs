using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using 小型管理信息系统.Code;
using System.Data;

namespace 小型管理信息系统.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {

                String password = inputpassword.Text;
                String sql = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));Persist Security Info=True;User ID=wangziyao;Password=wzysgdbd52;";
                OracleConnection shiyan = new OracleConnection(sql);
                shiyan.Open();
                try
                {
                    int admin = int.Parse(inputadmin.Text);
                    OracleCommand com= new OracleCommand("Select SNO,Password from Login where SNO = '" + admin + "' and Password = '" + password + "'", shiyan);
                    OracleDataReader oracleDataReader = com.ExecuteReader();
                    if (admin == 1234 && password == "0000")
                    {
                        String str;
                        str = "你好啊，尊贵的管理员大人";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='../Admin/index.aspx';</script>");
                    }
                    else
                    if (oracleDataReader.HasRows)
                    {
                        String str;
                        str = "你好，" + inputadmin.Text + "，最近过得怎么样？";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='../Student/index.aspx';</script>");
                    }
                    oracleDataReader.Close();
                    String sql2 = "select TeacherID,Password from TEACHER where TeacherID='" + admin + "'and Password='" + password + "'";
                    OracleDataReader sqlDataReader = DB.Search(sql2);
                    if(sqlDataReader.HasRows)
                    {
                        String str;
                        str = "老师，你好！";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='../Teacher/index.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('用户名或密码错误');</script>");
                    }
                    HttpCookie objCookie = new HttpCookie("myCookie", admin.ToString());
                    Response.Cookies.Add(objCookie);
                }
                catch
                {
                    String str = "亲，你输入了一些奇怪的东西哦~！";
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='login.aspx';</script>");
                }
                shiyan.Close();

            }
        }
    }
}