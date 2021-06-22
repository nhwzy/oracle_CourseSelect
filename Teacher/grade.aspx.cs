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
    public partial class grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String sql2 = "select S.SNO 学号,S.SNAME 姓名,C.CNAME 课程名,SC.GRADE 成绩 from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO order by S.SNO";
                DataTable ds = DB.getData(sql2);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            
        }

        protected void Gradeadd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                String CourseName = DropDownList1.Text;
                String StudentName = DropDownList2.Text.ToString();
                String Grade = inputGrade.Text;
                if (inputGrade.Text == String.Empty)
                {
                    String str = "亲，不要什么都不输入哦！";
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    goto end;
                }
                String sql1 = "select C.CNO from SC left join S on S.SNO=SC.SNO left join C on C.CNO=SC.CNO where SNAME='"+StudentName+"' and CNAME='"+CourseName+"' and GRADE is not NULL ";
                OracleDataReader sqlDataReader = DB.Search(sql1);
                try
                {
                    if (sqlDataReader.Read())
                    {
                        String str = "这个学生已经考过这门课了~";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        goto end;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        String sql3 = "select S.SNO,C.CNO from SC left join S on S.SNO=SC.SNO left join C on SC.CNO=C.CNO where CNAME='" + CourseName + "'and SNAME='"+StudentName+"' ";
                        OracleDataReader sqlDataReader2 = DB.Search(sql3);
                        if (sqlDataReader2.Read())
                        {
                            String courseid = sqlDataReader2["CNO"].ToString();
                            string Studentid = sqlDataReader2["SNO"].ToString();
                            sqlDataReader2.Close();
                            string sql2 = "Update SC set Grade ='" + Grade + "'where SNO='"+Studentid+"' and CNO='"+courseid+"'"; 
                            if (DB.Update(sql2))
                            {
                                String str = "添加成功！";
                                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                                Response.Write("<script language='javascript'>window.location='grade.aspx';</script>");
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
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String CourseName = DropDownList1.Text.ToString();
            String sql = "select S.SNAME from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO where C.CNAME='"+CourseName+"' and SC.GRADE is NULL";
            DataTable ds = new DataTable();
            ds = DB.getData(sql);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "SNAME";
            DropDownList2.DataValueField = "SNAME";
            DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String CourseName = DropDownList3.Text.ToString();
            String sql = "select S.SNAME from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO where C.CNAME='" + CourseName + "' and SC.GRADE is not NULL";
            DataTable ds = new DataTable();
            ds = DB.getData(sql);
            DropDownList4.DataSource = ds;
            DropDownList4.DataTextField = "SNAME";
            DropDownList4.DataValueField = "SNAME";
            DropDownList4.DataBind();
        }

        protected void Gradedelete_Click(object sender, EventArgs e)
        {
            String CourseName = DropDownList3.Text;
            String StudentName = DropDownList4.Text;
            if (DropDownList3.Text == String.Empty||DropDownList4.Text==String.Empty)
            {
                String str = "亲，不要什么都不选哦！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                goto end;
            }

            String sql3 = "select S.SNO,C.CNO from SC left join S on S.SNO=SC.SNO left join C on SC.CNO=C.CNO where CNAME='" + CourseName + "'and SNAME='" + StudentName + "' ";
            OracleDataReader sqlDataReader2 = DB.Search(sql3);
            if (sqlDataReader2.Read())
            {
                String courseid = sqlDataReader2["CNO"].ToString();
                String StudentID = sqlDataReader2["SNO"].ToString();
                sqlDataReader2.Close();
                String sql1 = "Update  SC set GRADE='' where SNO='" + StudentID + "'and CNO='" + courseid + "'";
                if (DB.Update(sql1))
                {
                    String str = "删除成功！";
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    Response.Write("<script language='javascript'>window.location='grade.aspx';</script>");
                }
            }
        end: { };
        }

        protected void Grademodify_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                String CourseName = DropDownList5.Text;
                String StudentName = DropDownList6.Text;
                String Grade = NewCourseGrade.Text;
                if (NewCourseGrade.Text == String.Empty || DropDownList6.Text.ToString() == String.Empty)
                {
                    String str = "亲，不要什么都不输入哦！";
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                    goto end;
                }
                String sql = "select S.SNO,C.CNO from SC left join S on S.SNO=SC.SNO left join C on SC.CNO=C.CNO where CNAME='" + CourseName + "'and SNAME='" + StudentName + "' ";
                OracleDataReader sqlDataReader = DB.Search(sql);
                if (sqlDataReader.Read())
                {
                    String courseid = sqlDataReader["CNO"].ToString();
                    string Studentid = sqlDataReader["SNO"].ToString();
                    sqlDataReader.Close();
                    string sql2 = "Update SC set Grade ='" + Grade + "'where SNO='" + Studentid + "' and CNO='" + courseid + "'";
                    if (DB.Update(sql2))
                    {
                        String str = "修改成功！";
                        Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                        Response.Write("<script language='javascript'>window.location='grade.aspx';</script>");
                    }
                }
            end: { }
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            String CourseName = DropDownList5.Text.ToString();
            String sql = "select S.SNAME from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO where C.CNAME='" + CourseName + "' and SC.GRADE is not NULL";
            DataTable ds = new DataTable();
            ds = DB.getData(sql);
            DropDownList6.DataSource = ds;
            DropDownList6.DataTextField = "SNAME";
            DropDownList6.DataValueField = "SNAME";
            DropDownList6.DataBind();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            String name = StudentName.Text.ToString();
            String id = inputStudentID.Text.ToString();
            String coursename = CourseName.Text.ToString();
            if(CourseGrade.Text.ToString()==String.Empty)
            {
                String sql = "select S.SNO 学号,S.SNAME 姓名,C.CNAME 课程名,SC.GRADE 成绩 from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO where S.SNO like '%" + id + "%' and S.SNAME like '%" + name + "%' and C.CNAME like '%" + coursename + "%'order by S.SNO ";
                DataTable dt = DB.getData(sql);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                int grade = int.Parse(CourseGrade.Text.ToString());
                String sql2 = "select S.SNO 学号,S.SNAME 姓名,C.CNAME 课程名,SC.GRADE 成绩 from SC left join S on SC.SNO=S.SNO left join C on SC.CNO=C.CNO where S.SNO like '%"+id+"%' and S.SNAME like '%"+name+"%' and C.CNAME like '%"+coursename+"%' and SC.GRADE >= '"+grade+"' order by S.SNO ";
                DataTable ds = DB.getData(sql2);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }            
            
        }

    }
}