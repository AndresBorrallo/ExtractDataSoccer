using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDataSoccer {

	class Program
	{

		private static readonly ILog _log = LogManager.GetLogger(typeof(Program));
		static void Main(string[] args) {
			BasicConfigurator.Configure();
			_log.Info("Init()");
			
			//http://www.resultados-futbol.com
			
			///Extraer primera division
			using (StreamWriter outputFile = new StreamWriter("../../Results/primeraDivision.json")) {
				var league = new league().GetAllRounds(1);
				outputFile.WriteLine(JsonConvert.SerializeObject(league));
			}
			
			//Extraer segunda division
			using (StreamWriter outputFile = new StreamWriter("../../Results/segundaDivision.json")) {
				var league = new league().GetAllRounds(2);
				outputFile.WriteLine(JsonConvert.SerializeObject(league));
			}

			using (StreamWriter outputFile = new StreamWriter("../../Results/jornada16.json")) {
				List<Match> matchs = new Round().ExtractRoundByURL("http://www.resultados-futbol.com/segunda/grupo1/jornada16");
				outputFile.WriteLine(JsonConvert.SerializeObject(matchs));
			}

			_log.Info("End()");

			Console.ReadLine();

		}

	}
}
