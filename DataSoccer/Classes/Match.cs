using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDataSoccer {
	class Match {
		public string local { get; set; }
		public string visitante { get; set; }
		public string resultado { get; set; }

		public override string ToString() {
			return $"{local} - {resultado} - {visitante}";
		}

		public string ToJSON() {
			return JsonConvert.SerializeObject(this);
		}
	}
}
