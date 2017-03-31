using UnityEngine;

public class MoveCamera: MonoBehaviour, StepListener {

	private StepWatcher watcher;
	private WalkStrategy strategy = new WalkStrategy();

	void Start() {
		watcher = GameObject.Find("Scripts").GetComponent<StepWatcher>();
		watcher.Register(this);
	}
	void OnApplicationQuit() {
		if (watcher != null)
			watcher.Unregister(this);
		watcher = null;
	}

	public void OnStep(int steps) {
		transform.position = strategy.GetPosition(transform.position, steps);
	}



	class WalkStrategy {
		public float speed = 0.70f;
		public Vector3 GetPosition(Vector3 p, int steps) {
			if (steps < 40) {
				return new Vector3(-steps*speed, p.y, p.z);
			} else
			if (steps < 45) {
				return new Vector3(-40*speed, p.y, (steps-40)*speed);
			} else {
				return new Vector3(-40*speed + (steps-45)*speed, p.y, 5*speed);
			}
		}
	}
}
