using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaManager: MonoBehaviour {

	private Dictionary<string,GameObject> scenes;
	private Dictionary<string,bool> isLoaded;

	void Start() {
		scenes   = new Dictionary<string,GameObject>();
		isLoaded = new Dictionary<string,bool>();
		var names = new string[] { "Exterior", "Floor0", "Floor1", };
		foreach(var name in names) {
			scenes[name] = null;
			isLoaded[name] = false;
		}
		InvokeRepeating("UpdateActiveScenes", 0.0f, 0.5f);
	}

	void UpdateActiveScenes() {
		int steps = GameObject.Find("Scripts").GetComponent<CountSteps>().Steps;
		Logger.Debug("Steps: "+steps+" ; #scenes:"+SceneManager.sceneCount);
		string name = "Floor1";
		if (!isLoaded[name] && (steps%10 > 0 && steps%10 <=5)) {
			SceneManager.LoadScene(name, LoadSceneMode.Additive);
			//if Unity version < 5.3, use the following:
			//Application.LoadLevelAdditive("Floor1");

			var scene2go = new GameObject(name);
			scenes[name] = scene2go;
			var scene = SceneManager.GetSceneByName(name);
			foreach(GameObject go in scene.GetRootGameObjects())
				go.transform.parent = scene2go.transform;
			scene2go.transform.parent = transform;
			Logger.Debug("Scene loaded.");
			isLoaded[name] = true;
			
		} else
		if ( isLoaded[name] && (steps%10 ==0 || steps%10 > 5)) {
			scenes[name].transform.parent = null;
			Destroy(scenes[name]);
			scenes[name] = null;
			isLoaded[name] = false;
			Logger.Debug("Scene unloaded.");
		}
	}

}
