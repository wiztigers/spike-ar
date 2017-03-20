using UnityEngine;
using System.Diagnostics;
using System.IO;

public class Logger: MonoBehaviour {
	/** Logger file will be: /sdcard/$ProductName<Suffix> */
	public string FileSuffix = ".txt";
	/** Set this to true if you want console output to remain enabled. */
	public bool IsConsoleEnabled = true;
	/** Set this to true if you want to timestamp Logger messages. */
	public bool HasTimestamp = true;

	private StreamWriter writer;
	private string path;
	private static Logger instance { get; set; }

	void Awake() {
		if (instance != null) throw new System.InvalidOperationException();
		instance = this;
#if !FINAL
		string filename = Application.productName+FileSuffix;
		path = Application.persistentDataPath+"/"+filename;
		writer = new StreamWriter(path, true);
#endif
		Logger.Debug("Application opened.");
	}
	void OnApplicationQuit() {
		Logger.Debug("Application closed.");
#if !FINAL
		if (writer != null) {
			writer.Close();
			writer = null;
		}
#endif
	}

	private void Write(string message) {
#if !FINAL
		if (HasTimestamp) {
			var now = System.DateTime.Now;
			message = string.Format("[{0:H:mm:ss}] {1}", now, message);
		}
		if (writer != null) {
			writer.WriteLine(message);
			writer.Flush();
		}
		if (IsConsoleEnabled) {
			UnityEngine.Debug.Log(message);
		}
#endif
	}

	[Conditional("DEBUG"), Conditional("PROFILE")]
	public static void Debug(string message, params System.Object[] args) {
#if !FINAL
		message = string.Format(message, args);
		if (Logger.instance != null) Logger.instance.Write(message);
		else UnityEngine.Debug.Log(message); // fallback
#endif
	}



	/** /!\ HACK:
	 *	This allows proper display of our files in W$ Explorer without needing to reboot.
	 *	Seriously, after like 5 years, to heck with G00gle and M$'s MTP:
	 *	https://code.google.com/p/android/issues/detail?id=38282
	 *	TL;DR: on native Android, you'd do ...
	 *	MediaScannerConnection.scanFile(this, new String[] { path }, null, null);
	 * ... which translate in Unity as the contents of this function.
	 */
	private static void SeriouslyGoogleDoYourJob38282(string path) {
	#if UNITY_ANDROID && !UNITY_EDITOR
		using (AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		using (AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity"))
		using (AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext"))
		using (AndroidJavaClass MediaScannerConnection = new AndroidJavaClass("android.media.MediaScannerConnection"))
		using (AndroidJavaClass os = new AndroidJavaClass("android.os.Environment"))
		using (AndroidJavaObject storage = os.CallStatic<AndroidJavaObject>("getExternalStorageDirectory")) {
			string p = storage.Call<string>("toString")+path;
			MediaScannerConnection.CallStatic("scanFile", context, new string[]{ p }, null, null);
		}
	#endif
	}

}