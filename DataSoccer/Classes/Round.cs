using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDataSoccer {
	class Round {
		public int round { get; set; }
		public string url { get; set; }
		public List<Match> matchs { get; set; }


		public List<Match> ExtractRoundByURL(string url) {

			List<Match> res = new List<Match>();

			HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load(url);
			try {
				var equipo1Par = doc.DocumentNode.SelectNodes("//tr[@class='vevent ']//td[@class='equipo1']").ToList();
				var equipo1Impar = doc.DocumentNode.SelectNodes("//tr[@class='vevent impar']//td[@class='equipo1']").ToList();
				var equipo2Par = doc.DocumentNode.SelectNodes("//tr[@class='vevent ']//td[@class='equipo2']").ToList();
				var equipo2Impar = doc.DocumentNode.SelectNodes("//tr[@class='vevent impar']//td[@class='equipo2']").ToList();



				var resultadosPar = doc.DocumentNode.SelectNodes("//tr[@class='vevent ']//span[@class='clase']").ToList();
				var resultadosImpar = doc.DocumentNode.SelectNodes("//tr[@class='vevent impar']//span[@class='clase']").ToList();

				for (int i = 0; i < equipo1Par.Count() - 1; i++) {

					res.Add(new Match() { local = equipo1Par[i].InnerText, resultado = resultadosPar[i].InnerText, visitante = equipo2Par[i].InnerText });
					res.Add(new Match() { local = equipo1Impar[i].InnerText, resultado = resultadosImpar[i].InnerText, visitante = equipo2Impar[i].InnerText });
				}
			}
			catch {
				Console.WriteLine("This round is not available");
			}
			return res;
		}


	}
}
