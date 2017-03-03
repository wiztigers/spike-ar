using UnityEngine;

public class CountSteps: MonoBehaviour {

	/** Update time (in seconds) */
	public float Delay = 0.020f;
	/** The sum of standard deviations must be greater than this for movment to be detected */
	public double MovmentThreshold = 25.0;
	/** A local maximum must be greater than the average plus this for it to be detected as a step. */
	public double StepThreshold = 1.5;
	/** Steps count */
	public int Steps {
		get {
			if (counter == null) return 0;
			return counter.Steps;
		}
	}

	private StepsCounter counter = null;

	void Start() {
		if (counter == null)
			counter = new StepsCounter(MovmentThreshold, StepThreshold);

		if (SystemInfo.supportsAccelerometer)
			InvokeRepeating("UpdateSteps", 0.0f, Delay);
	}

	void UpdateSteps() {
		counter.UpdateSteps(Input.acceleration * 9.8f);
	}
}
