using MySqlConnector;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDAL
{
    public class DataAccessLayer
    {
        public string ConnectionString;

        public DataAccessLayer(string connString)
        {
            //ConnectionString = @"Data Source=0PG00BXPK\JINDEV;Initial catalog=EmployeeDB;uid=sa; Password=AdminPwd@123;connection timeout=60";
            ConnectionString = connString;
        }

        #region SQL Server

        //public DataSet GetEmployees()
        //{
        //    DataSet empDS = new DataSet();

        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("GetEmployees", connection))
        //        {
        //            connection.Open();

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            var reader = cmd.ExecuteReader();


        //            empDS.Tables.Add("Employees");

        //            //Load DataReader into the DataTable.
        //            empDS.Tables[0].Load(reader);
        //        }
        //    }

        //    return empDS;
        //}

        //public void InsertEmployee(string firstName, string lastName, double salary, double experience, string team)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("InsertEmployee", connection))
        //        {
        //            connection.Open();

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@FirstName", firstName);
        //            cmd.Parameters.AddWithValue("@LastName", lastName);
        //            cmd.Parameters.AddWithValue("@Salary", salary);
        //            cmd.Parameters.AddWithValue("@Experience", experience);
        //            cmd.Parameters.AddWithValue("@Team", team);

        //            var response = cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void UpdateEmployee(int id, string firstName, string lastName, double salary, double experience, string team)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("UpdateEmployee", connection))
        //        {
        //            connection.Open();

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@Id", id);
        //            cmd.Parameters.AddWithValue("@FirstName", firstName);
        //            cmd.Parameters.AddWithValue("@LastName", lastName);
        //            cmd.Parameters.AddWithValue("@Salary", salary);
        //            cmd.Parameters.AddWithValue("@Experience", experience);
        //            cmd.Parameters.AddWithValue("@Team", team);

        //            var response = cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public DataSet GetEmployeeById(int id)
        //{
        //    DataSet empDS = new DataSet();

        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("GetEmployeeById", connection))
        //        {
        //            connection.Open();

        //            cmd.Parameters.AddWithValue("@Id", id);

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            var reader = cmd.ExecuteReader();

        //            empDS.Tables.Add("Employees");

        //            //Load DataReader into the DataTable.
        //            empDS.Tables[0].Load(reader);
        //        }
        //    }

        //    return empDS;
        //}

        //public void DeleteEmployee(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("DeleteEmployee", connection))
        //        {
        //            connection.Open();

        //            cmd.Parameters.AddWithValue("@Id", id);

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        #endregion SQL Server

        #region MySQL

        public DataSet GetEmployees()
        {
            DataSet empDS = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("select * from employee", connection))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    var reader = cmd.ExecuteReader();

                    empDS.Tables.Add("Employees");

                    //Load DataReader into the DataTable.
                    empDS.Tables[0].Load(reader);
                }
            }

            return empDS;
        }

        public void InsertEmployee(string firstName, string lastName, double salary, decimal experience, string team)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("InsertEmployee", connection))
                {
                    connection.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("Salary", salary);
                    cmd.Parameters.AddWithValue("Experience", experience);
                    cmd.Parameters.AddWithValue("Team", team);

                    var response = cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(int id, string firstName, string lastName, double salary, decimal experience, string team)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("UpdateEmployee", connection))
                {
                    connection.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("EmpId", id);
                    cmd.Parameters.AddWithValue("FirstName", firstName);
                    cmd.Parameters.AddWithValue("LastName", lastName);
                    cmd.Parameters.AddWithValue("Salary", salary);
                    cmd.Parameters.AddWithValue("Experience", experience);
                    cmd.Parameters.AddWithValue("Team", team);

                    var response = cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetEmployeeById(int id)
        {
            DataSet empDS = new DataSet();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetEmployeeById", connection))
                {
                    connection.Open();

                    cmd.Parameters.AddWithValue("EmpId", id);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();

                    empDS.Tables.Add("Employees");

                    //Load DataReader into the DataTable.
                    empDS.Tables[0].Load(reader);
                }
            }

            return empDS;
        }

        public void DeleteEmployee(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("DeleteEmployee", connection))
                {
                    connection.Open();

                    cmd.Parameters.AddWithValue("EmpId", id);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion MySQL
    }
}
