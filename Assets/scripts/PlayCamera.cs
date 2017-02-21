using UnityEngine;

public class PlayCamera: MonoBehaviour {

	private WebCamTexture cammy;

	void Start() {
		cammy = new WebCamTexture();
		gameObject.GetComponent<MeshRenderer>().material.mainTexture = cammy;
		cammy.Play();
	}

	void OnGUI() {
		if (cammy.isPlaying) {
			if (GUILayout.Button("■")) cammy.Stop();
		} else {
			if (GUILayout.Button("►")) cammy.Play();
		}
	}
}
