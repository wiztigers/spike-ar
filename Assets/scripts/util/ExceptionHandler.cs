using UnityEngine;

public class ExceptionHandler: MonoBehaviour {

	void Awake() {
		Application.logMessageReceived += OnException;
		//if Unity version < 5.0, use the following:
		//Application.RegisterLogCallback(OnException);
	}
	private void OnException(string condition, string stack, LogType type) {
		if (type != LogType.Exception) return;
		Logger.Debug("{0}: {1}\n{2}", type, condition, stack);
	}
}
