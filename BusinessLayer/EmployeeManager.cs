using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class EmployeeManager
	{
		public static List<EmployeeDTO> GetEmployees(int pageIndex, int pageSize, int? departemntId, string keyword, string columnName, bool orderASC)
		{
			return EmployeeDAL.GetEmployees(pageIndex, pageSize, departemntId, keyword, columnName, orderASC);
		}

		public static int UpdateEmployee(EmployeeDTO empDto)
		{
			return EmployeeDAL.UpdateEmployee(empDto);
		}

		public static void DeleteEmployee(int employeeId, int deletedBy)
		{
			EmployeeDAL.DeleteEmployee(employeeId, deletedBy);
		}

		public static List<DepartmentDTO> GetDepartment()
		{
			return EmployeeDAL.GetDepartment();
		}
	}
}
