using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPOST.Models
{
	public class SearchResponse
	{
		public Guid OrganizationId { get; set; }

		public string ControllerName { get; set; }

		public string ActionName { get; set; }

		public string InputSearch { get; set; }
	}
}
