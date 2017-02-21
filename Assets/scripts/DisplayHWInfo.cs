using UnityEngine;

public class DisplayHWInfo: MonoBehaviour {

	/** Time between refreshes (in seconds) */
	public float Delay = 0.25f;
	/** Text entity */
	public UnityEngine.UI.Text HWText;

	void Start() {
		Input.gyro.enabled = true;
		Input.compass.enabled = true;
		InvokeRepeating("DisplaySystemInfo", 0.5f, Delay);
	}

	void DisplaySystemInfo() {
		HWText.text = "";
		HWText.text += "refresh: "+Delay*1000+"ms";

#if UNITY_STANDALONE || UNITY_EDITOR
		HWText.text += "\nmouse: "+Input.GetAxis("Mouse X")+" ; "+Input.GetAxis("Mouse Y");
#else
		HWText.text += "\ncompass.enabled: "+Input.compass.enabled;
		HWText.text += "\ncompass.magnetic: "+Input.compass.magneticHeading;

		HWText.text += "\nsystem.gyro: " + SystemInfo.supportsGyroscope;
		HWText.text += "\ngyro.enabled: "+Input.gyro.enabled;
		HWText.text += "\ngyro: "+Input.gyro.attitude.ToString();

		HWText.text += "\nsystem.accel: "+SystemInfo.supportsAccelerometer;
		HWText.text += "\naccel: "+Input.acceleration.ToString();
#endif	
	}
}
