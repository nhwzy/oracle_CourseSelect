using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using 小型管理信息系统.Code;
using System.Data;

namespace 小型管理信息系统.Teacher
{
    public partial class select : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void SelectCourse_Click(object sender, EventArgs e)
        {      
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                String StudentID = this.GridView1.Rows[i].Cells[2].Text;
                String Cno = this.GridView1.Rows[i].Cells[0].Text;
                CheckBox cBoxItem = (CheckBox)GridView1.Rows[i].FindControl("Checkitem");
                if (cBoxItem.Checked == true)
                {
                    String sql = "insert into SC(SNO,CNO,GRADE) values('" + StudentID + "','" + Cno + "','')";
                    if (DB.Insert(sql))
                    {
                        String sql2="delete from APPLY where SNO='"+StudentID+"' and CNO='"+Cno+"'";
                        DB.Delete(sql2);
                        String str1 = "选课成功！";
                        Response.Write("<script language='javascript'>alert('" + str1 + "');</script>");
                        Response.Write("<script language='javascript'>window.location='select.aspx';</script>");
                    }
                    
                }
            }
        }
    }
}