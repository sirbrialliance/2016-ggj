using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager Instance { get; private set; }

	public List<Wizard> players;

	public Wizard GetNext(Wizard me, Wizard currTarget) {
		Assert.IsTrue(players.Contains(me));
		if (currTarget) Assert.IsTrue(players.Contains(currTarget));
		Assert.IsTrue(players.Count > 1);

		Wizard target = currTarget;

		var idx = players.IndexOf(currTarget);
		if (idx < 0) players.IndexOf(me);

		target = players[(idx + 1) % players.Count];
		if (target == me) target = players[(idx + 2) % players.Count];

		Debug.Log("new target it " + target);

		return target;
	}

	void Awake() {
		Instance = this;
	
	}
	
	void Update() {
	
	}
}
