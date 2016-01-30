using UnityEngine;
using System.Collections;

public class Destructor {

	public static void DoCleanup(GameObject obj) {
		foreach (var pe in obj.GetComponentsInChildren<ParticleSystem>()) {
			pe.Stop();
		}

		GameObject.Destroy(obj.gameObject, 20);
	}
}
