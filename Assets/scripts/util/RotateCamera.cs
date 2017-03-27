using UnityEngine;

public class RotateCamera: MonoBehaviour {

	void Start() {
		Input.location.Start();
	}

	void Update() {
#if UNITY_STANDALONE || UNITY_EDITOR
		float rotationSpeed = 50.0f;
		float ox =  Input.GetAxis("Mouse Y");// vertical
		float oy = -Input.GetAxis("Mouse X");// horizontal
		float oz = 0.0f;
		ox = ox * Time.deltaTime * rotationSpeed;
		oy = oy * Time.deltaTime * rotationSpeed;
		oz = oz * Time.deltaTime * rotationSpeed;
		transform.Rotate(ox, oy, oz);
#else
		transform.rotation = Input.gyro.attitude;
		transform.Rotate( 0f,   0f, 180f, Space.Self);// to avoid "mirror" effect of our cam
		transform.Rotate(90f, 180f,   0f, Space.World);// cams are on the back of smartphones
#endif
	}
}
