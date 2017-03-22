using UnityEngine;

public class VicinitySpawn: MonoBehaviour {

	public float Distance;

	void Start() {
		InvokeRepeating("Blit", 1.0f, 1.0f);
	}

	void Update() {
		// Camera.main is the first camera that is enabled and labelled "MainCamera"
		float d = Vector3.Distance(Camera.main.transform.position, transform.position);
		Display(d < Distance);
	}

	void Display(bool display) {
		gameObject.SetActive(display);
	}

	void Blit() { Display(!gameObject.activeSelf); }
}
