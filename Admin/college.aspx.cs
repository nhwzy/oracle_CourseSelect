using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using 小型管理信息系统.Code;
namespace 小型管理信息系统.Admin
{
    public partial class college : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Collegemodify_Click(object sender, EventArgs e)
        {
            String CollegeName = DropDownList2.Text;
            String CollegeNewName = inputCollegeNewName.Text;
            if (inputCollegeNewName.Text == String.Empty)
            {
                String str = "亲，不要什么都不输入哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
            
            String sql1 = "Select CollegeName from College where CollegeName='" + CollegeNewName + "'";
            OracleDataReader sqlDataReader = DB.Search(sql1);
            try
            {
                if (sqlDataReader.HasRows)
                {
                    String str = "你输入的学院名称已被占用,学院名称为" + CollegeNewName;
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
                }
                else
                {
                    sqlDataReader.Close();
                    String sql2 = "Update College set CollegeName='" + CollegeNewName + "' where CollegeName='" + CollegeName + "'";
                    
                    if (DB.Update(sql2))
                    {
                        String str = "修改成功！";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
                    }
                }
            }
            catch
            {
                String str = "亲，修改失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
            }
        end: { }
        }

        protected void CollegeDelete_Click(object sender, EventArgs e)
        {
            String CollegeName = DropDownList1.Text;
            String sql1 = "delete  from College where CollegeName='" + CollegeName + "'";
            if (DB.Delete(sql1))
            {
                String str = "删除成功！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
            }
        }

        protected void CollegeAdd_Click(object sender, EventArgs e)
        {
            String CollegeName = inputCollegeName.Text;
            if (inputCollegeName.Text == String.Empty)
            {
                String str = "亲，不要什么都不输入哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
            String sql = "select CollegeName from College where CollegeName='" + CollegeName + "'";
            OracleDataReader sqlDataReader = DB.Search(sql);            
            try
            {
                if (sqlDataReader.HasRows)
                {
                    String str = "你输入的学院名称已被占用,学院名称为" + CollegeName;
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
                }
                else
                {
                    sqlDataReader.Close();
                    string sql2 = "INSERT INTO College ( CollegeName) " + "VALUES ('" + CollegeName + "' )";
                    
                    if (DB.Insert(sql2))
                    {
                        String str = "添加成功！";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
                    }
                }
            }
            catch
            {
                String str = "亲，添加失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='college.aspx';</script>");
            }
        end: { }
        }
    }
}