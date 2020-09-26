using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServices.Interfaces
{
	[ServiceContract]
	public interface IEmployeeServices
	{
		[OperationContract]
		List<EmployeeDTO> GetEmployees(int pageIndex, int pageSize, int? departemntId, string keyword, string columnName, bool orderASC);

		[OperationContract]
		int UpdateEmployee(EmployeeDTO empDto);

		[OperationContract]
		void DeleteEmployee(int employeeId, int deletedBy);

		[OperationContract]
		List<DepartmentDTO> GetDepartment();
	}
}
