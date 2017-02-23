using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPSEnabler: MonoBehaviour {

	/** Maximum wait timeout (in seconds) */
	public int Timeout = 20;
/*
	public void Start() {
		bool isRunning = Input.location.status == LocationServiceStatus.Running;
		if (isRunning) return; // nothing to do
		StartCoroutine(StartService(Timeout));
	}
	
	public IEnumerator StartService(int timeout) {
		if (!Input.location.isEnabledByUser) {
			yield break;
		}

		Input.location.Start();
		int wait = timeout;
		while (wait > 0 && Input.location.status == LocationServiceStatus.Initializing) {
//			Debug.Log("waiting ("+wait+") ...");
			yield return new WaitForSeconds(1);
			wait--;
		}
		if (wait < 1) {
//			Debug.Log("timeout!");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			yield break;
		} else {
//			Input.location.lastData.latitude
//			Input.location.lastData.longitude 
//			Input.location.lastData.altitude
//			Input.location.lastData.horizontalAccuracy
//			Input.location.lastData.timestamp
//			Debug.Log("enabled!");
		}

	}

	public void StopService() {
        Input.location.Stop();
		Debug.Log("disabled!");
    }
*/
}
