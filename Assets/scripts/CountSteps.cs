using UnityEngine;

public class CountSteps: MonoBehaviour {

	/** Update time (in seconds) */
	public float Delay = 0.020f;
	/** The sum of standard deviations must be greater than this for movment to be detected */
	public double MovmentThreshold = 35.0;
	/** Steps count */
	public int Steps {
		get {
			if (counter == null) return 0;
			return counter.Steps;
		}
	}

	private StepsCounter counter = null;

	void Start() {
		if (counter == null) counter = new StepsCounter(MovmentThreshold);

		if (SystemInfo.supportsAccelerometer)
			InvokeRepeating("UpdateSteps", 0.0f, Delay);
	}

	void UpdateSteps() {
		counter.UpdateSteps(Input.acceleration * 9.8f);
	}
}
