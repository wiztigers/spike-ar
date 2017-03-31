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

#if UNITY_STANDALONE || UNITY_EDITOR
		HWText.text += "\nmouse: "+Input.GetAxis("Mouse X")+" ; "+Input.GetAxis("Mouse Y");
#else
		HWText.text += "\ncompass.north: "+Input.compass.trueHeading;
		HWText.text += "\ngyro: "+Input.gyro.attitude.ToString();

		HWText.text += "\nsteps: "+GameObject.Find("Scripts").GetComponent<CountSteps>().Steps;
#endif
	}
}
