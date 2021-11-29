using EmployeeBAL.Model;
using EmployeeDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace EmployeeBAL
{
    public class BusinessAccessLayer
    {
        DataAccessLayer dbLayer;

        string ConnectionString;

        public BusinessAccessLayer(string connStr)
        {
            ConnectionString = connStr;
        }

        public void InsertEmployee(Employee emp)
        {
            CheckAndCreateServiceObjects();

            dbLayer.InsertEmployee(emp.FirstName, emp.LastName, emp.Salary, Math.Round(emp.Experience, 2), emp.Team);
        }

        public void UpdateEmployee(Employee emp)
        {
            CheckAndCreateServiceObjects();

            dbLayer.UpdateEmployee(emp.Id, emp.FirstName, emp.LastName, emp.Salary, Math.Round(emp.Experience, 2), emp.Team);
        }

        public List<Employee> GetEmployees()
        {
            CheckAndCreateServiceObjects();

            var empDS = dbLayer.GetEmployees();

            List<Employee> employees = new List<Employee>();

            foreach (DataRow row in empDS.Tables[0].Rows)
            {
                Employee emp = new Employee();

                emp.Id = Convert.ToInt32(row[0]);
                emp.FirstName = row[1].ToString();
                emp.LastName = row[2].ToString();
                emp.Experience = Math.Round(Convert.ToDecimal(row[3]),2);
                emp.Salary = Convert.ToDouble(row[4]);
                emp.Team = row[5].ToString();

                employees.Add(emp);
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            CheckAndCreateServiceObjects();

            var empDS = dbLayer.GetEmployeeById(id);

            var empRow = empDS.Tables[0].Rows[0];

            Employee emp = new Employee();

            emp.Id = Convert.ToInt32(empRow[0]);
            emp.FirstName = empRow[1].ToString();
            emp.LastName = empRow[2].ToString();
            emp.Salary = Convert.ToDouble(empRow[4]);
            emp.Experience = Math.Round(Convert.ToDecimal(empRow[3]), 2);
            emp.Team = empRow[5].ToString();

            return emp;
        }

        public void DeleteEmployee(int id)
        {
            CheckAndCreateServiceObjects();

            dbLayer.DeleteEmployee(id);
        }

        private void CheckAndCreateServiceObjects()
        {
            if (dbLayer == null)
                dbLayer = new DataAccessLayer(ConnectionString);
        }
    }
}
