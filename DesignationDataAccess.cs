using EmployeeManagement.BusinessObjects;
using EmployeeManagement.Enums;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeManagement.DAL
{
    public class DesignationDataAccess
    {
        public void Insertdesignation(Designation designation)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["vypak"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PROC_DesignationMaster", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Desig_Name", designation.DesignationName);
                cmd.Parameters.AddWithValue("@Desig_Sht_Name", designation.Shortname);
                cmd.Parameters.AddWithValue("@Operation", OperationEnum.Operations.INSERT.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
        public void Deletedesignation(string ids)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["vypak"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PROC_DesignationMaster", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ids", ids); 
                cmd.Parameters.AddWithValue("@Operation", OperationEnum.Operations.DELETE.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
        public void editdesignation(int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["vypak"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PROC_DesignationMaster", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ids", id);
                cmd.Parameters.AddWithValue("@Operation", OperationEnum.Operations.UPDATE.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                 
            }
        }
        public List<Designation> Getdesignation()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["vypak"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PROC_DesignationMaster", con)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Operation", OperationEnum.Operations.SELECT.ToString());
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();

                // Fill dataset
                int rowCount = da.Fill(ds);
                // Check results
                if (rowCount > 0)
                {
                    // Load business object
                    var myData = ds.Tables[0].AsEnumerable().Select(r => new Designation
                    {
                        Id = r.Field<int>("Desig_Id"),
                        DesignationName = r.Field<string>("Desig_Name"),
                        Shortname = r.Field<string>("Desig_Sht_Name")
                    });
                    var list = myData.ToList();
                    return list;
                }
                else
                {
                    // No data found
                    return null;
                }
            }
        }

        public void Updatedesignation(Designation designation, int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["vypak"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PROC_DesignationMaster", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Desig_Name", designation.DesignationName);
                cmd.Parameters.AddWithValue("@Desig_Sht_Name", designation.Shortname);
                cmd.Parameters.AddWithValue("@Desig_Id", designation.Id);
                cmd.Parameters.AddWithValue("@Operation", OperationEnum.Operations.UPDATE.ToString());
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}