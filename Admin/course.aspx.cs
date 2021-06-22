using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using 小型管理信息系统.Code;
using System.Data;

namespace 小型管理信息系统.Admin
{
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CourseAdd_Click(object sender, EventArgs e)
        {
            String CourseID = inputCourseID.Text.ToString();
            String CourseName = inputCourseName.Text.ToString();
            String CPNAME = DropDownList3.Text.ToString();
            String CREDIT = inputCredit.Text.ToString();
            if (inputCourseName.Text == String.Empty || inputCourseID.Text==String.Empty||inputCredit.Text==String.Empty)
            {
                String str = "亲，你有没输入的东西哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
            String sql1 = "Select CNAME from C where CNAME='" + CourseName + "'or  CNO='"+CourseID+"'";
            OracleDataReader sqlDataReader = DB.Search(sql1);
            try
            {
                if (sqlDataReader.HasRows)
                {
                    String str = "你输入的课程名称或课程号已被占用,课程名称为" + CourseName+",课程号为"+CourseID;
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    goto end;
                }
                else
                {
                    sqlDataReader.Close();
                    String sql3 = "Select * from C where CNAME='" + CPNAME + "'";
                    OracleDataReader sqlDataReader3 = DB.Search(sql3);
                    if (sqlDataReader3.Read())
                    {
                        String Cpno = sqlDataReader3["CNO"].ToString();
                        sqlDataReader3.Close();
                        string sql2 = "INSERT INTO C (CNO,CNAME,CPNO,CCREDIT) VALUES ('" + CourseID + "','" + CourseName + "','" + Cpno + "','" + CREDIT + "' )";
                        if (DB.Insert(sql2))
                        {
                            String str = "添加成功！";
                            Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                            Response.Write("<script language='javascript'>window.location='course.aspx';</script>");
                        }
                    }
                }
            }
            catch
            {
                String str = "亲，添加失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
        end: { }
        }

        protected void CourseDelete_Click(object sender, EventArgs e)
        {
            String CourseName = DropDownList1.Text;          
            String sql1 = "delete  from C where CNAME='" + CourseName + "'";
            if (DB.Delete(sql1))
            {
                String str = "删除成功！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                Response.Write("<script language='javascript'>window.location='course.aspx';</script>");
            }
        }

        protected void Coursemodify_Click(object sender, EventArgs e)
        {
            String CourseName = DropDownList2.Text;
            String CourseNewName = inputCourseNewName.Text;
            String CoursePreName = DropDownList4.Text;
            String CourseCredit = inputCourseNewCredit.Text;
            if (inputCourseNewName.Text == String.Empty||DropDownList4.Text==String.Empty||inputCourseNewCredit.Text==String.Empty)
            {
                String str = "亲，不要什么都不输入哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }
            try
            {
                String sql = "select CNO from C where CNAME='" + CoursePreName + "'";
                OracleDataReader oracleDataReader = DB.Search(sql);
                if (oracleDataReader.Read())
                {
                    String Cpno = oracleDataReader["CNO"].ToString();
                    oracleDataReader.Close();
                    String sql1 = "Select * from C where CNAME='" + CourseNewName + "'";
                    OracleDataReader sqlDataReader = DB.Search(sql1);
                    if (sqlDataReader.HasRows)
                    {
                        String str = "你输入的课程名称已被占用,课程名称为" + CourseNewName;
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        goto end;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        String sql2 = "Update C set CNAME='" + CourseNewName + "',CPNO='"+Cpno+ "',CCREDIT='" + CourseCredit + "' where CNAME='" + CourseName + "'";
                        if (DB.Update(sql2))
                        {
                            String str = "修改成功！";
                            Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                            Response.Write("<script language='javascript'>window.location='course.aspx';</script>");
                        }
                    }
                }
            }
            catch
            {
                String str = "亲，修改失败了哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }         
            
            
        end: { }
        }
    }
}