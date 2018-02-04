using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDataSoccer {
	class league {
		private static ILog _log = LogManager.GetLogger(typeof(league));
		
		public List<Round> GetAllRounds(int league) {
			List<Round> rounds = new List<Round>();
			var urls = generateAllURL(league);
			int round = 1;
			foreach (var url in urls) {
				rounds.Add(new Round() {url = url, matchs = new Round().ExtractRoundByURL(url),round = round});
				_log.Info($"Getting league:{league} round {round} -- {url} ");
				round++;
			}
			
			return rounds;

		}

		public List<string> generateAllURL(int league) {

			List<string> urls = new List<string>();

			string leagueText;
			int rounds;
			switch (league) {
				case 1:
					leagueText = "primera";
					rounds = 38;
					break;
				case 2:
					leagueText = "segunda";
					rounds = 42;
					break;
				default:
					leagueText = "primera";
					rounds = 38;
					break;
			}

			for (int i = 1; i <= rounds; i++) {
				urls.Add("http://www.resultados-futbol.com/" + leagueText + "/grupo1/jornada" + i);
			}

			return urls;
		}
	}
}
