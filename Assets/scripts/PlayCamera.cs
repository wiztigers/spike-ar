using UnityEngine;

public class PlayCamera: MonoBehaviour {

	private WebCamTexture cammy;
	private Quaternion rotation;

	void Start() {
		cammy = new WebCamTexture();
		GetComponent<Renderer>().material.mainTexture = cammy;
		cammy.Play();
		rotation = transform.rotation;
	}

	void Update() {
		// https://forum.unity3d.com/threads/webcamtexture-flipping-and-rotating-90-degree-ios-and-android.143856/
		transform.rotation = rotation * Quaternion.AngleAxis(cammy.videoRotationAngle, Vector3.back);
	}

	void OnGUI() {
		if (cammy.isPlaying) {
			if (GUILayout.Button("■")) cammy.Stop();
		} else {
			if (GUILayout.Button("►")) cammy.Play();
		}
	}
}
