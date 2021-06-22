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
    public partial class major : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MajorAdd_Click(object sender, EventArgs e)
        {
            String CollegeName = DropDownList1.Text;
            String MajorName = inputMajorName.Text;
            if (inputMajorName.Text == String.Empty)
            {
                String str = "亲，不要什么都不输入哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
            String sql1 = "Select MajorName from Major where MajorName='" + MajorName + "'";
            OracleDataReader sqlDataReader = DB.Search(sql1);
            try
            {
                if (sqlDataReader.HasRows)
                {
                    String str = "你输入的专业名称已被占用,专业名称为" + MajorName;
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
                }
                else
                {
                    sqlDataReader.Close();
                    String sql3 = "Select CollegeID from College where CollegeName='" + CollegeName + "'";
                    OracleDataReader sqlDataReader2 = DB.Search(sql3);
                    if (sqlDataReader2.Read())
                    {
                        int id = int.Parse(sqlDataReader2["CollegeID"].ToString());
                        sqlDataReader2.Close();
                        string sql2 = "INSERT INTO Major ( MajorName,CollegeID) " + "VALUES ('" + MajorName + "' ,'" + id + "')";
                        if (DB.Insert(sql2))
                        {
                            String str = "添加成功！";
                            Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                            Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
                        }
                    }
                }
            }
            catch
            {
                String str = "亲，添加失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
            }
        end: { }
        }

        protected void MajorDelete_Click(object sender, EventArgs e)
        {
            String MajorName = DropDownList2.Text;
            String sql1 = "delete  from Major where MajorName='" + MajorName + "'";
            if (DB.Delete(sql1))
            {
                String str = "删除成功！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
            }
        }

        protected void Majormodify_Click(object sender, EventArgs e)
        {
            String MajorName = DropDownList3.Text;
            String MajorNewName = inputMajorNewName.Text;
            if (inputMajorNewName.Text == String.Empty)
            {
                String str = "亲，不要什么都不输入哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }

            String sql1 = "Select MajorName from Major where MajorName='" + MajorNewName + "'";
            OracleDataReader sqlDataReader = DB.Search(sql1);
            try
            {
                if (sqlDataReader.HasRows)
                {
                    String str = "你输入的专业名称已被占用,专业名称为" + MajorNewName;
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
                }
                else
                {
                    sqlDataReader.Close();
                    String sql2 = "Update Major set MajorName='" + MajorNewName + "' where MajorName='" + MajorName + "'";
                    if (DB.Update(sql2))
                    {
                        String str = "修改成功！";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
                    }
                }
            }
            catch
            {
                String str = "亲，修改失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='major.aspx';</script>");
            }
        end: { }
        }
    }
}