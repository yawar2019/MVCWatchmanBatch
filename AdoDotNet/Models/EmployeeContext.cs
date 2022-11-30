using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace AdoDotNet.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=MVC10PMdb;Integrated Security=true");
        public List<EmployeeModel>  GetAllEmployees()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            SqlCommand cmd = new SqlCommand("usp_getEmployees",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();//collection of rows and columns
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                emp.EmpName = Convert.ToString(dr["EmpName"]);
                emp.EmpSalary = Convert.ToInt32(dr["EmpSalary"]);

                listEmp.Add(emp);
            }

            return listEmp;

        }
    }
}