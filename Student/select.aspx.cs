using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using 小型管理信息系统.Code;
using System.Data;

namespace 小型管理信息系统.Student
{
    public partial class select : System.Web.UI.Page
    {
        public static string StudentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentID = Request.Cookies["myCookie"].Value;
            if(!IsPostBack)
            {
                String sql1 = "select a.CNO,a.CNAME,b.CNAME,a.CCREDIT from C  a left join C  b on a.CPNO=b.CNO where a.CNO not in(select CNO from SC where SNO='"+StudentID+"') order by a.CNO";
                DataTable ds = DB.getData(sql1);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                String sql2 = "select A.CNO 课程号,C.CNAME 课程名,B.CNAME 前置课程,C.CCREDIT 学分 from APPLY A left join C on A.CNO=C.CNO left join C B on C.CPNO=B.CNO left join S on S.SNO=A.SNO where A.SNO='" + StudentID + "'";
                DataTable ds2 = DB.getData(sql2);
                GridView2.DataSource = ds2;
                GridView2.DataBind();
                String sql3 = "select a.CNO 课程号,a.CNAME 课程名,b.CNAME 前置课程,a.CCREDIT 学分 from C  a left join C  b on a.CPNO=b.CNO where a.CNO in (select CNO from SC where SNO='"+StudentID+ "' and GRADE is NULL) order by a.CNO";
                DataTable ds3 = DB.getData(sql3);
                GridView3.DataSource = ds3;
                GridView3.DataBind();
            }
            
        }

        protected void SelectCourse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                String Cno= this.GridView1.Rows[i].Cells[0].Text;
                CheckBox cBoxItem = (CheckBox)GridView1.Rows[i].FindControl("Checkitem");
                if (cBoxItem.Checked == true)
                {
                    String sql2 = "select CNO from APPLY where CNO='" + Cno + "'and SNO='" + StudentID + "'";
                    OracleDataReader oracleDataReader = DB.Search(sql2);
                    if(oracleDataReader.Read())
                    {
                        String str1 = "不要重复申请选课！";
                        Response.Write("<script language='javascript'>alert('" + str1 + "');</script>");
                        goto end;
                    }
                    String sql = "insert into APPLY(SNO,CNO) values('"+StudentID+"','"+Cno+"')";
                    if (DB.Insert(sql))
                    {
                        String str1 = "申请成功！";
                        Response.Write("<script language='javascript'>alert('" + str1 + "');</script>");
                        Response.Write("<script language='javascript'>window.location='select.aspx';</script>");
                    }
                }
            }
        end: { };
        }
    }
}