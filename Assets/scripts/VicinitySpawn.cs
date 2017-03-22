using UnityEngine;

public class VicinitySpawn: MonoBehaviour {

	public float Distance;

	void Update() {
		// Camera.main is the first camera that is enabled and labelled "MainCamera"
		float d = Vector3.Distance(Camera.main.transform.position, transform.position);
		Display(d < Distance);
	}

	void Display(bool display) {
		gameObject.SetActive(display);
	}
}
