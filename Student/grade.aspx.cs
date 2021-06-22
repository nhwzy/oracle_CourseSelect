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
    public partial class grade : System.Web.UI.Page
    {
        public static string StudentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentID = Request.Cookies["myCookie"].Value;
            if (!IsPostBack)
            {
                String sql1 = "select C.CNO 课程号,C.CNAME 课程名,C.CCREDIT 学分,SC.GRADE 成绩 from C left join SC on C.CNO=SC.CNO where SC.SNO='"+StudentID+"'order by SC.SNO";
                DataTable ds = DB.getData(sql1);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            String name = CourseName.Text.ToString();
            String id = inputCourseID.Text.ToString();
            String credit = CourseCredit.Text.ToString();
            if (CourseGrade.Text.ToString() == String.Empty)
            {
                String sql = "Select C.CNO 课程号,C.CNAME 课程名,C.CCREDIT 学分,SC.GRADE 成绩 from C left join SC on C.CNO=SC.CNO where SC.SNO='" + StudentID + "' and C.CNO like '%" + id + "%' and C.CNAME like '%" + name + "%' and C.CCREDIT like '%" + credit + "%'  order by C.CNO ";
                DataTable dt = DB.getData(sql);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                int grade = int.Parse(CourseGrade.Text.ToString());
                String sql2 = "Select C.CNO 课程号,C.CNAME 课程名,C.CCREDIT 学分,SC.GRADE 成绩 from C left join SC on C.CNO=SC.CNO where SC.SNO='" + StudentID + "' and C.CNO like '%" + id + "%' and C.CNAME like '%" + name + "%' and C.CCREDIT like '%" + credit + "%' and SC.GRADE>='"+grade+ "'  order by C.CNO ";
                DataTable ds = DB.getData(sql2);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}