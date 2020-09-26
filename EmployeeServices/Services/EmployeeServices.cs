using BusinessLayer;
using DataLayer.Models;
using EmployeeServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServices.Services
{

	public class EmployeeServices : IEmployeeServices
	{

		public List<EmployeeDTO> GetEmployees(int pageIndex, int pageSize, int? departemntId, string keyword, string columnName, bool orderASC)
		{
			try
			{
				return EmployeeManager.GetEmployees(pageIndex, pageSize, departemntId, keyword, columnName, orderASC);
			}
			catch (Exception ex)
			{
				//log error
				throw;
			}
		}

		public int UpdateEmployee(EmployeeDTO empDto)
		{
			try
			{
				return EmployeeManager.UpdateEmployee(empDto);
			}
			catch (Exception ex)
			{
				//log error
				throw;
			}
		}


		public void DeleteEmployee(int employeeId, int deletedBy)
		{
			try
			{
				EmployeeManager.DeleteEmployee(employeeId, deletedBy);
			}
			catch (Exception ex)
			{
				//log error
				throw;
			}
		}

		public List<DepartmentDTO> GetDepartment()
		{
			try
			{
				return EmployeeManager.GetDepartment();
			}
			catch (Exception ex)
			{
				//log error
				throw;
			}
		}
	}
}
