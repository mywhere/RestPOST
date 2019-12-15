using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPOST.Models
{
	public class SearchRequest
	{
		public string LocaleCode { get; set; }

		public string Timezone { get; set; }

		public string Search { get; set; }
	}
}
