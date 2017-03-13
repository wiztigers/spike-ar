using UnityEngine;

public class ExceptionHandler: MonoBehaviour {

	void Awake() {
		Application.RegisterLogCallback(OnException);
	}
	private void OnException(string condition, string stack, LogType type) {
		if (type != LogType.Exception) return;
		Logger.Debug("{0}: {1}\n{2}", type, condition, stack);
	}
}
