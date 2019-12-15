using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPOST.Models
{
	public class InputParameters: SearchRequest
	{
		public Guid OrganizationId { get; set; }
	}
}
