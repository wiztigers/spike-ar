using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsCounter {

	/** Steps count */
	public int Steps { get; private set; }
	/** The sum of standard deviations must be greater than this for movment to be detected */
	public double MovmentThreshold { get; private set; }
	/** A local maximum must be greater than the average plus this for it to be detected as a step. */
	public double StepThreshold { get; private set; }

	public StepsCounter(double MovmentThreshold = 25.0, double StepThreshold = 1.5) {
		this.MovmentThreshold = MovmentThreshold;
		this.StepThreshold = StepThreshold;
		this.Steps = 0;
	}

	private static double GetNorm(Vector3 v) {
		return System.Math.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
	}
	private static int modulo(int x, int m) {
		int r = x % m;
		return r < 0 ? r + m : r;
	}
	public static IEnumerable<int> GetPreviousRange(int i, int range, int size) {
		int j = modulo(i-range, size);
		while (j != i) {
			j++;
			if (j == size) j = 0;
			yield return j;
		}
	}
	public static IEnumerable<double> GetPreviousRange(int i, int range, double[] values) {
		int j = modulo(i-range, values.Length);
		while (j != i) {
			j++;
			if (j == values.Length) j = 0;
			yield return values[j];
		}
	}
	public static double Average(ICollection<double> values) {
		double sum = 0;
		foreach (double v in values) sum += v;
		return sum / values.Count;
	}
	public static double SumStandardDeviations(IEnumerable<double> values, double average) {
		double result = 0;
		foreach(double v in values) {
			result += Mathf.Abs((float)(v - average));
		}
		return result;
	}
	public int CountLocalMaxima(IList<double> values, int local, double average) {
		int count = 0;
		int range = values.Count;
		for(int i = local ; i < range-local ; i++) {
			if ((values[i] > average +StepThreshold) && IsLocalMaximum(values, i, local)) {
				if (!lasts.Contains(values[i])) {
					count++;
					lasts.Enqueue(values[i]);
				}
			}
		}
		return count;
	}
	public static bool IsLocalMaximum(IList<double> values, int index, int local) {
		double candidate = values[index];
		for (int i = index-local ; i < index + local ; i++) {
			if (values[i] > candidate) return false;
		}
		return true;
	}

	private bool active = false;
	private int i = 0;
	private double[] array_norms = new double[100];
	private IList<double> values = null;
	private double average;
	private double sum_deviations;
	/** Last detected steps (so we don't detect the same step twice). */
	private FixedSizeQueue<double> lasts = new FixedSizeQueue<double>(3);

	public void UpdateSteps(Vector3 acceleration) {
		double norm = GetNorm(acceleration);

		if (i == 100) i = 0;

		if (i == 99) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 98) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 97) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 96) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 95) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 94) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 93) {
			array_norms[i] = norm;

			i++;
		}
		if (i == 92) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 91) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 90) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 89) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 88) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 87) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 86) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 85) {
			array_norms[i] = norm;
			i++;

			if (sum_deviations >= MovmentThreshold) {
				// count the number of steps (ie. local maximum) accross 50 values
				Steps += CountLocalMaxima(values, 10, average);
			}
		}
		if (i == 84) {
			array_norms[i] = norm;
			i++;

			// check if we are curently moving ;
			// we are if the sum of standard deviations is greater than a threshold
			average = Average(values);
			sum_deviations = SumStandardDeviations(values, average);
		}
		if (i == 83) {
			array_norms[i] = norm;
			// get (50) last values, from most ancient to now
			var iterable = GetPreviousRange(i, 50, array_norms);
			values = new List<double>(iterable);
			i++;
		}
		if (i == 82) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 81) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 80) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 79) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 78) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 77) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 76) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 75) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 74) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 73) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 72) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 71) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 70) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 69) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 68) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 67) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 66) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 65) {
			array_norms[i] = norm;
			i++;

			if (sum_deviations >= MovmentThreshold) {
				// count the number of steps (ie. local maximum) accross 50 values
				Steps += CountLocalMaxima(values, 10, average);
			}
		}
		if (i == 64) {
			array_norms[i] = norm;
			i++;

			// check if we are curently moving ;
			// we are if the sum of standard deviations is greater than a threshold
			average = Average(values);
			sum_deviations = SumStandardDeviations(values, average);
		}
		if (i == 63) {
			array_norms[i] = norm;
			// get (50) last values, from most ancient to now
			var iterable = GetPreviousRange(i, 50, array_norms);
			values = new List<double>(iterable);
			i++;
		}
		if (i == 62) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 61) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 60) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 59) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 58) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 57) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 56) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 55) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 54) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 53) {
			array_norms[i] = norm;
			i++;

			active = true;
		}
		if (i == 52) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 51) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 50) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 49) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 48) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 47) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 46) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 45) {
			array_norms[i] = norm;
			i++;

			if (active)
			if (sum_deviations >= MovmentThreshold) {
				// count the number of steps (ie. local maximum) accross 50 values
				Steps += CountLocalMaxima(values, 10, average);
			}
		}
		if (i == 44) {
			array_norms[i] = norm;
			i++;

			// check if we are curently moving ;
			// we are if the sum of standard deviations is greater than a threshold
			if (active) {
				average = Average(values);
				sum_deviations = SumStandardDeviations(values, average);
			}
		}
		if (i == 43) {
			array_norms[i] = norm;
			// get (50) last values, from most ancient to now
			if (active) {
				var iterable = GetPreviousRange(i, 50, array_norms);
				values = new List<double>(iterable);
			}
			i++;
		}
		if (i == 42) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 41) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 40) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 39) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 38) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 37) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 36) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 35) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 34) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 33) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 32) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 31) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 30) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 29) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 28) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 27) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 26) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 25) {
			array_norms[i] = norm;
			i++;

			if (active)
			if (sum_deviations >= MovmentThreshold) {
				// count the number of steps (ie. local maximum) accross 50 values
				Steps += CountLocalMaxima(values, 10, average);
			}
		}
		if (i == 24) {
			array_norms[i] = norm;
			i++;

			// check if we are curently moving ;
			// we are if the sum of standard deviations is greater than a threshold
			if (active) {
				average = Average(values);
				sum_deviations = SumStandardDeviations(values, average);
			}
		}
		if (i == 23) {
			array_norms[i] = norm;
			// get (50) last values, from most ancient to now
			if (active) {
				var iterable = GetPreviousRange(i, 50, array_norms);
				values = new List<double>(iterable);
			}
			i++;
		}
		if (i == 22) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 21) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 20) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 19) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 18) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 17) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 16) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 15) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 14) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 13) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 12) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 11) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 10) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 9) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 8) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 7) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 6) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 5) {
			array_norms[i] = norm;
			i++;

			if (active)
			if (sum_deviations >= MovmentThreshold) {
				// count the number of steps (ie. local maximum) accross 50 values
				Steps += CountLocalMaxima(values, 10, average);
			}
		}
		if (i == 4) {
			array_norms[i] = norm;
			i++;

			// check if we are curently moving ;
			// we are if the sum of standard deviations is greater than a threshold
			if (active) {
				average = Average(values);
				sum_deviations = SumStandardDeviations(values, average);
			}
		}
		if (i == 3) {
			array_norms[i] = norm;
			// get (50) last values, from most ancient to now
			if (active) {
				var iterable = GetPreviousRange(i, 50, array_norms);
				values = new List<double>(iterable);
			}
			i++;
		}
		if (i == 2) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 1) {
			array_norms[i] = norm;
			i++;
		}
		if (i == 0) {
			array_norms[i] = norm;
			i++;
		}
	}

}
