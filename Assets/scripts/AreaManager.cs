using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaManager: MonoBehaviour, StepListener {

	private Dictionary<string,GameObject> objects;
	private Dictionary<string,Scene> scenes;
	private Dictionary<string,bool> isLoaded;

	private StepWatcher watcher;

	void Start() {
		objects  = new Dictionary<string,GameObject>();
		scenes   = new Dictionary<string,Scene>();
		isLoaded = new Dictionary<string,bool>();
		var names = new string[] { "Exterior", "Floor0", "Floor1", };
		foreach(var name in names) {
			objects[name]  = null;
			isLoaded[name] = false;
		}
		watcher = GameObject.Find("Scripts").GetComponent<StepWatcher>();
		watcher.Register(this);
	}
	void OnApplicationQuit() {
		if (watcher != null)
			watcher.Unregister(this);
		watcher = null;
	}

	public void OnStep(int steps) {
		string area = "Floor1";
		if (steps >= 0 && steps < 100) Load(area);
		else
		if (steps >= 100) Unload(area);
	}

	/** Adds a new area to rendering.
	 *  @param uid Area unique identifier
	 */
	private bool Load(string uid) {
		if (isLoaded[uid]) return true; // nothing to do

		isLoaded[uid] = true;
		Logger.Debug("Load scene: \"{0}\".", uid);
		SceneManager.LoadScene(uid, LoadSceneMode.Additive);
		//if Unity version < 5.3, use the following:
		//Application.LoadLevelAdditive("Floor1");

		var scene2go = new GameObject(uid);
		objects[uid] = scene2go;
		var scene = SceneManager.GetSceneByName(uid);
		scenes[uid] = scene;
		foreach(GameObject go in scene.GetRootGameObjects())
			go.transform.parent = scene2go.transform;
		scene2go.transform.parent = transform;

		return true;
	}
	/** Stops rendering of a specific area.
	 *  @param uid Area unique identifier
	 */
	private bool Unload(string uid) {
		if (!isLoaded[uid]) return true; // nothing to do

		isLoaded[uid] = false;
		objects[uid].transform.parent = null;
		Destroy(objects[uid]);
		objects[uid] = null;
		SceneManager.UnloadSceneAsync(scenes[uid]);
		scenes.Remove(uid);
		Logger.Debug("Scene \"{0}\" unloaded.", uid);

		return true;
	}
}
