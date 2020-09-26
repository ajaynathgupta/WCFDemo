using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class EmployeeDAL
	{
		#region GetEmployees
		public static List<EmployeeDTO> GetEmployees(int pageIndex, int pageSize, int? departemntId, string keyword, string columnName, bool orderASC)
		{
			var employeeList = new List<EmployeeDTO>();

			using (var context = new EmployeeDBContext())
			{
				var query = from emp in context.Employees
							join empDetail in context.EmployeeDetails on emp.EmployeeID equals empDetail.EmployeeID
							join dept in context.Departments on emp.DepartmentID equals dept.DepartmentID
							where !emp.IsDeleted
							select new EmployeeDTO
							{
								EmployeeId = emp.EmployeeID,
								EmployeeName = emp.Name,
								DepartmentId = dept.DepartmentID,
								DepartmentName = dept.Name,
								Email = empDetail.Email,
								Address = empDetail.Address,
								Gender = empDetail.Gender,
								Salary = empDetail.Salary
							};

				if (departemntId != null)
				{
					query = query.Where(x => x.DepartmentId == departemntId);
				}
				if (!string.IsNullOrWhiteSpace(keyword))
				{
					query = query.Where(x => x.EmployeeName.Contains(keyword));
				}
				if (!string.IsNullOrWhiteSpace(columnName))
				{
					if (columnName == "EmployeeName" && orderASC)
					{
						query = query.OrderBy(x => x.EmployeeName);
					}
					else if (columnName == "EmployeeName" && !orderASC)
					{
						query = query.OrderByDescending(x => x.EmployeeName);
					}
					else if (columnName == "DepartmentName" && orderASC)
					{
						query = query.OrderBy(x => x.DepartmentName);
					}
					else if (columnName == "DepartmentName" && !orderASC)
					{
						query = query.OrderByDescending(x => x.DepartmentName);
					}
					else if (columnName == "Email" && orderASC)
					{
						query = query.OrderBy(x => x.Email);
					}
					else if (columnName == "Email" && !orderASC)
					{
						query = query.OrderByDescending(x => x.Email);
					}
					else if (columnName == "Gender" && orderASC)
					{
						query = query.OrderBy(x => x.Gender);
					}
					else if (columnName == "Gender" && !orderASC)
					{
						query = query.OrderByDescending(x => x.Gender);
					}
					else if (columnName == "Salary" && orderASC)
					{
						query = query.OrderBy(x => x.Salary);
					}
					else if (columnName == "Salary" && !orderASC)
					{
						query = query.OrderByDescending(x => x.Salary);
					}
					else if (columnName == "Address" && orderASC)
					{
						query = query.OrderBy(x => x.Address);
					}
					else if (columnName == "Address" && !orderASC)
					{
						query = query.OrderBy(x => x.Address);
					}
				}
				else
				{
					query = query.OrderBy(x => x.EmployeeName);
				}

				employeeList = query.Skip(pageIndex * pageSize).Take(pageSize).ToList();
				if (employeeList != null && employeeList.Count > 0)
				{
					employeeList[0].TotalCount = query.Count();
				}
			}

			return employeeList;
		}
		#endregion

		#region UpdateEmployee
		public static int UpdateEmployee(EmployeeDTO empDto)
		{
			using (var context = new EmployeeDBContext())
			{
				if (empDto.EmployeeId == 0)
				{
					var employee = new Employee();
					employee.Name = empDto.EmployeeName;
					employee.DepartmentID = empDto.DepartmentId;
					employee.CreatedBy = empDto.CreatedBy;
					employee.CreatedDate = DateTime.Now;

					context.Employees.Add(employee);

					var employeeDetail = new EmployeeDetail();
					employeeDetail.EmployeeID = employee.EmployeeID;
					employeeDetail.Email = empDto.Email;
					employeeDetail.Address = empDto.Address;
					employeeDetail.Gender = empDto.Gender;
					employeeDetail.Salary = empDto.Salary;
					employeeDetail.CreatedBy = empDto.CreatedBy;
					employeeDetail.CreatedDate = DateTime.Now;
					employeeDetail.Salary = empDto.Salary;

					employee.EmployeeDetails.Add(employeeDetail);
				}
				else
				{
					var employee = context.Employees.Where(x => x.EmployeeID == empDto.EmployeeId).FirstOrDefault();
					if (employee != null)
					{
						if (employee.Name != empDto.EmployeeName || employee.DepartmentID != empDto.DepartmentId)
						{
							employee.Name = empDto.EmployeeName;
							employee.DepartmentID = empDto.DepartmentId;
							employee.EditBy = empDto.CreatedBy;
							employee.EditDate = DateTime.Now;
						}
					}

					var employeeDetail = context.EmployeeDetails.Where(x => x.EmployeeID == empDto.EmployeeId).FirstOrDefault();
					if (employee != null)
					{
						if (employeeDetail.Email != empDto.Email
							|| employeeDetail.Address != empDto.Address
							|| employeeDetail.Gender != empDto.Gender
							|| employeeDetail.Salary != empDto.Salary)
						{
							employeeDetail.Email = empDto.Email;
							employeeDetail.Address = empDto.Address;
							employeeDetail.Gender = empDto.Gender;
							employeeDetail.Salary = empDto.Salary;

							employeeDetail.EditBy = empDto.CreatedBy;
							employeeDetail.EditDate = DateTime.Now;
						}
					}
				}
				context.SaveChanges();

				return empDto.EmployeeId;
			}
		}
		#endregion

		#region DeleteEmployee
		public static void DeleteEmployee(int employeeId, int deletedBy)
		{
			using (var context = new EmployeeDBContext())
			{
				var employee = context.Employees.Where(x => x.EmployeeID == employeeId).FirstOrDefault();
				if (employee != null)
				{
					employee.IsDeleted = true;
					employee.EditBy = deletedBy;
					employee.EditDate = DateTime.Now;

					var employeeDetail = context.EmployeeDetails.Where(x => x.EmployeeID == employeeId).FirstOrDefault();
					if (employeeDetail != null)
					{
						employeeDetail.IsDeleted = true;
						employeeDetail.EditBy = deletedBy;
						employeeDetail.EditDate = DateTime.Now;
					}
				}
				context.SaveChanges();
			}
		}
		#endregion

		public static List<DepartmentDTO> GetDepartment()
		{
			var departmentList = new List<DepartmentDTO>();
			using (var context = new EmployeeDBContext())
			{
				departmentList = (from d in context.Departments
								  select new DepartmentDTO
								  {
									  DepartmentID = d.DepartmentID,
									  DepartmentName = d.Name
								  }).OrderBy(x => x.DepartmentName).ToList();
			}
			return departmentList;
		}
	}
}
