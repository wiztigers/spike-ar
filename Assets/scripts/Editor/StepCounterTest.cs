using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class StepCounterTest {

	[Test]
	public void PreviousRange_7_5_10() {
		var iterable_range = StepsCounter.GetPreviousRange(7, 5, 10);
		var range = new System.Collections.Generic.List<int>(iterable_range);
		Assert.AreEqual( 3, range[0]);
		Assert.AreEqual( 4, range[1]);
		Assert.AreEqual( 5, range[2]);
		Assert.AreEqual( 6, range[3]);
		Assert.AreEqual( 7, range[4]);
	}

	[Test]
	public void PreviousRange_2_5_10() {
		var iterable_range = StepsCounter.GetPreviousRange(2, 5, 10);
		var range = new System.Collections.Generic.List<int>(iterable_range);
		Assert.AreEqual( 8, range[0]);
		Assert.AreEqual( 9, range[1]);
		Assert.AreEqual( 0, range[2]);
		Assert.AreEqual( 1, range[3]);
		Assert.AreEqual( 2, range[4]);
	}

	[Test]
	public void PreviousRange_2_5_100() {
		var stopwatch = System.Diagnostics.Stopwatch.StartNew();
		var iterable_range = StepsCounter.GetPreviousRange(2, 5, 100);
		stopwatch.Stop();
		Debug.Log("indexes: Elapsed="+stopwatch.Elapsed+" Frequency="+System.Diagnostics.Stopwatch.Frequency);
		var range = new System.Collections.Generic.List<int>(iterable_range);
		Assert.AreEqual(98, range[0]);
		Assert.AreEqual(99, range[1]);
		Assert.AreEqual( 0, range[2]);
		Assert.AreEqual( 1, range[3]);
		Assert.AreEqual( 2, range[4]);
	}

	[Test]
	public void PreviousRange_2_50_100_array() {
		var array = new double[] {
				 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
				10,11,12,13,14,15,16,17,18,19,
				20,21,22,23,24,25,26,27,28,29,
				30,31,32,33,34,35,36,37,38,39,
				40,41,42,43,44,45,46,47,48,49,
				50,51,52,53,54,55,56,57,58,59,
				60,61,62,63,64,65,66,67,68,69,
				70,71,72,73,74,75,76,77,78,79,
				80,81,82,83,84,85,86,87,88,89,
				90,91,92,93,94,95,96,97,98,99,
			};
		var stopwatch = System.Diagnostics.Stopwatch.StartNew();
		var iterable_range = StepsCounter.GetPreviousRange(2, 50, array);
		stopwatch.Stop();
		Debug.Log("values:  Elapsed="+stopwatch.Elapsed+" Frequency="+System.Diagnostics.Stopwatch.Frequency);
		var range = new System.Collections.Generic.List<double>(iterable_range);
		Assert.AreEqual( array[53], range[ 0]);
		Assert.AreEqual( array[54], range[ 1]);
		Assert.AreEqual( array[55], range[ 2]);
		Assert.AreEqual( array[98], range[45]);
		Assert.AreEqual( array[99], range[46]);
		Assert.AreEqual( array[ 0], range[47]);
		Assert.AreEqual( array[ 1], range[48]);
		Assert.AreEqual( array[ 2], range[49]);
	}

}
