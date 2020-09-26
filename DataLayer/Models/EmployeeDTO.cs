using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
	public class EmployeeDTO
	{
		[DataMember]
		public int EmployeeId { get; set; }
		[DataMember]
		public string EmployeeName { get; set; }
		[DataMember]
		public int DepartmentId { get; set; }
		[DataMember]
		public string DepartmentName { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Address { get; set; }
		[DataMember]
		public string Gender { get; set; }
		[DataMember]
		public decimal Salary { get; set; }
		[DataMember]
		public int CreatedBy { get; set; }
		[DataMember]
		public int TotalCount { get; set; }
	}
}
