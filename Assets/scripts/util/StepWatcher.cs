using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepWatcher: MonoBehaviour {

	/** Time between refreshes (in seconds) */
	public float Delay = 0.25f;
	/** */
	private List<StepListener> listeners = new List<StepListener>();
	/** Last known steps count */
	private int steps = 0;

	void Start() {
		InvokeRepeating("WatchYourStep", 0.0f, Delay);
	}

	void WatchYourStep() {
		int current = GameObject.Find("Scripts").GetComponent<CountSteps>().Steps;
		if (current == steps) return; //DO nothing
		steps = current;
		foreach(var listener in listeners) listener.OnStep(steps);
	}

	public void Register(StepListener listener)   { listeners.Add(listener); }
	public void Unregister(StepListener listener) { listeners.Remove(listener); }
}

public interface StepListener {
	/** Use this to be notified when step count has changed.
	 *  @param steps New steps count
	 */ void OnStep(int steps);
}
