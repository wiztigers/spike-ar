using UnityEngine;

public class RotateCamera: MonoBehaviour {

	public float XRotationSpeed = 10.0f;
	public float YRotationSpeed = 10.0f;
	public float ZRotationSpeed = 10.0f;

	void Update () {
#if UNITY_STANDALONE || UNITY_EDITOR
		float ox =  Input.GetAxis("Mouse Y");// vertical
		float oy = -Input.GetAxis("Mouse X");// horizontal
		float oz = 0.0f;
		ox = ox * Time.deltaTime * XRotationSpeed;
		oy = oy * Time.deltaTime * YRotationSpeed;
		oz = oz * Time.deltaTime * ZRotationSpeed;
		transform.Rotate(ox, oy, oz);
#else
		transform.rotation = Input.gyro.attitude;
		transform.Rotate( 0f,   0f, 180f, Space.Self);// to avoid "mirror" effect of our cam
		transform.Rotate(90f, 180f,   0f, Space.World);// cams are on the back of smartphones
#endif
	}
}
