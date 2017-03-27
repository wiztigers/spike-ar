using UnityEngine;
using UnityEngine.SceneManagement;

public class VicinitySpawn: MonoBehaviour {

	public float DistanceToCamera;

	private bool isDisplayed = true;
	public bool IsDisplayed {
		get {
			return isDisplayed;
		}
		private set {
			if (isDisplayed == value) return;
			isDisplayed = value;
			// we cannot just call gameObject.SetActive(isDisplayed);
			// because then our Update() method would not be called anymore.
			// and using renderer.enabled = isDisplayed sometimes seems unreliable
			if (isDisplayed)
			     transform.localScale = Vector3.one;
			else transform.localScale = Vector3.zero;
		}
	}

	void Start() {
		IsDisplayed = false;
	}

	void Update() {
		if (Camera.main == null) {
			var scene = SceneManager.GetActiveScene().name;
			var iamerror = string.Format("Scene {0} is not meant to be run.", scene);
			throw new System.InvalidOperationException(iamerror);
		}
		// Camera.main is the first camera that is enabled and labelled "MainCamera"
		float d = Vector3.Distance(Camera.main.transform.position, transform.position);
		Logger.Debug("d="+d);
		IsDisplayed = d < DistanceToCamera;
	}
}
