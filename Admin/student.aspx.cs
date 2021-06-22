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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SNO"] = "-1";
                String sql2 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID ";
                DataTable ds = DB.getData(sql2);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            String name = StudentName.Text.ToString();
            String id = inputStudentID.Text.ToString();
            String SClass = Class.Text.ToString();
            String age = Age.Text.ToString();
            String gender = Gender.Text.ToString();
            String major = Major.Text.ToString();
            String college = College.Text.ToString();
            String sql2 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID  where S.SNO like '%"+id+"%' and S.SNAME like '%" + name + "%' and S.SCLASS like '%" + SClass + "%' and S.SAGE like '%"+age+"%' and SGENDER like '%"+gender+"%' and MAJOR.MajorName like '%" + major + "%' and COLLEGE.CollegeName like '%" + college + "%'";
            DataTable ds = DB.getData(sql2);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            
            String name = StudentName.Text.ToString();
            String id = inputStudentID.Text.ToString();
            String SClass = Class.Text.ToString();
            String age = Age.Text.ToString();
            String gender = Gender.Text.ToString();
            String major = Major.Text.ToString();
            String college = College.Text.ToString();
            string majorid;
            try
            {
                String sql1 = "Select MajorID,College.CollegeID from Major  inner join College on College.CollegeID=Major.CollegeID where Major.MajorName='" + major + "' and College.CollegeName='" + college + "'";
                OracleDataReader sqlDataReader = DB.Search(sql1);
                if (sqlDataReader.Read())
                {
                    majorid = sqlDataReader["MajorID"].ToString();
                    sqlDataReader.Close();
                    String str = "INSERT INTO S(SNO,SNAME,SGENDER,SAGE,SMAJORID,SCLASS) values('" + id + "','" + name + "','" + gender + "','" + age + "','" + majorid + "','" + SClass+ "')";
                    if (DB.Insert(str))
                    {
                        String str1 = "添加成功！";
                        Response.Write("<script language='javascript'>alert('" + str1 + "');</script>");
                        Response.Write("<script language='javascript'>window.location='student.aspx';</script>");
                    }
                    String sql2 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID ";
                    DataTable ds = DB.getData(sql2);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    sqlDataReader.Close();
                    String str = "没有这个学院或者学院没有相应专业,请检查是否输入正确！";
                    Response.Write("<script language='javascript'>alert('" + str + "');</script>");
                }
            }
            catch
            {
                String str = "发生了一些不可知的错误,看看是不是学号重复了！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
            }
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            String major = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Trim();
            String sql1 = "Select * from Major where MajorName='" + major + "'";
            OracleDataReader sqlDataReader = DB.Search(sql1);
            if (sqlDataReader.Read())
            {
                int majorid = int.Parse(sqlDataReader["MajorID"].ToString());
                sqlDataReader.Close();
                String sqlstr = "update S set SMAJORID='" + majorid + "' where SNO='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                DB.Update(sqlstr);
            }
            else
            {
                sqlDataReader.Close();
                String str = "此院没有这个专业,请检查是否输入正确！";
                Response.Write("<script language='javascript'>alert('" + str + "');</script>");
            }
            String sqlstr3 = "update S set SNAME='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',SCLASS='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',SAGE='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "',SGENDER='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim() + "'  where SNO='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";

            DB.Update(sqlstr3);
            GridView1.EditIndex = -1;

            String sql3 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID ";
            DataTable ds = DB.getData(sql3);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ViewState["SNO"] = e.NewEditIndex.ToString();
            String sql2 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID "; ;
            DataTable ds = DB.getData(sql2);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String sqlstr = "delete from S where SNO='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            DB.Delete(sqlstr);
            String sql3 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID ";
            DataTable ds = DB.getData(sql3);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ViewState["SNO"] = "-1";
            String sql3 = "SELECT S.SNO,S.SNAME, S.SCLASS,S.SAGE,S.SGENDER, Major.MajorName,College.CollegeName FROM S INNER JOIN Major ON S.SMAJORID = MAJOR.MajorID INNER JOIN College ON MAJOR.COllegeID = COllege.COllegeID ";
            DataTable ds = DB.getData(sql3);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (ViewState["SNO"].ToString() != "-1")
            {
                TextBox myt = (TextBox)GridView1.Rows[Convert.ToInt32(ViewState["SNO"].ToString())].Cells[0].Controls[0];
                myt.ReadOnly=true;
                ViewState["SNO"] = "-1";
            }
        }
    }
}