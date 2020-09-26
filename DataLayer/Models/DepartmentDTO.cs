using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
	public class DepartmentDTO
	{
		[DataMember]
		public int DepartmentID { get; set; }
		[DataMember]
		public string DepartmentName { get; set; }
	}
}
