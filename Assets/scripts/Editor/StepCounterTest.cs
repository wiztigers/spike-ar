using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class StepCounterTest {
		
	[Test]
	public void PreviousRange_7_5_10() {
		var iterable_range = StepsCounter.GetPreviousRange(7, 5, 10);
		var range = new System.Collections.Generic.List<int>(iterable_range);
		foreach(int i in range) Debug.Log("["+i+"]");
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
		foreach(int i in range) Debug.Log("["+i+"]");
		Assert.AreEqual( 8, range[0]);
		Assert.AreEqual( 9, range[1]);
		Assert.AreEqual( 0, range[2]);
		Assert.AreEqual( 1, range[3]);
		Assert.AreEqual( 2, range[4]);
	}

	[Test]
	public void PreviousRange_2_5_100() {
		var iterable_range = StepsCounter.GetPreviousRange(2, 5, 100);
		var range = new System.Collections.Generic.List<int>(iterable_range);
		foreach(int i in range) Debug.Log("["+i+"]");
		Assert.AreEqual(98, range[0]);
		Assert.AreEqual(99, range[1]);
		Assert.AreEqual( 0, range[2]);
		Assert.AreEqual( 1, range[3]);
		Assert.AreEqual( 2, range[4]);
	}

}
