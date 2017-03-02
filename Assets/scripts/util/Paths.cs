using UnityEngine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

public class Paths {

	/** Reimplement this function, as it is not available in Mono. */
	public static string Combine(params string[] paths) {
		if (paths == null) throw new ArgumentNullException("paths");
		return paths.Aggregate(Path.Combine);
	}

	/** This method assumes working directory is Library/ScriptAssemblies. */
	public static string GetProjectPath(params string[] paths) {
		string pwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		return Combine(pwd, "..","..", Combine(paths));
	}

	public static IList<double> ReadStepFile(string path, char separator = ';') {
		var data = new List<double>();
		using (StreamReader stream = new StreamReader(path)) {
			while (stream.Peek() >= 0)  {
				string line = stream.ReadLine();
				string[] array = line.Split(separator);
				foreach(string s in array) {
					double d = ParseDouble(s);
					if (double.IsNaN(d) || double.IsInfinity(d)) continue;
					data.Add(d);
				}
			}
		}
		return data;
	}

	public static IList<Vector3> GetStepData(string folder, int index, string prefix = "acce", string sufix = ".txt") {
		var datax = Paths.ReadStepFile(Paths.Combine(folder, prefix+"x"+index+sufix));
		var datay = Paths.ReadStepFile(Paths.Combine(folder, prefix+"y"+index+sufix));
		var dataz = Paths.ReadStepFile(Paths.Combine(folder, prefix+"z"+index+sufix));
		if ((datax.Count != datay.Count) || (datax.Count != dataz.Count))
			throw new ArgumentException("Step data count mismatch: ("+datax.Count+","+datay.Count+","+dataz.Count+")");
		var coords = new List<Vector3>();
		for (int c = 0; c < datax.Count; c++)
			coords.Add(new Vector3((float)datax[c], (float)datay[c], (float)dataz[c]));
		return coords;
	}

	public static double ParseDouble(string s) {
		double number;
		var style = NumberStyles.Any;
		var culture = CultureInfo.InvariantCulture;
		double.TryParse(s, style, culture, out number);
		return number;
	}
}
