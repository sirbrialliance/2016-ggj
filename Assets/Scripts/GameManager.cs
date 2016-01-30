using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager Instance { get; private set; }

	public List<Wizard> players;

	public List<GameObject> attackEffcts;
	public List<GameObject> defendEffcts;
	public GameObject fizzleEffect;

	public GameObject winScreen;

	public Wizard GetNext(Wizard me, Wizard currTarget) {
		Assert.IsTrue(players.Contains(me));
		if (currTarget) Assert.IsTrue(players.Contains(currTarget));
		Assert.IsTrue(players.Count > 1);

		Wizard target = currTarget;

		var idx = players.IndexOf(currTarget);
		if (idx < 0) idx = players.IndexOf(me);

		target = players[(idx + 1) % players.Count];
		if (target == me) target = players[(idx + 2) % players.Count];

		return target;
	}

	void Awake() {
		Instance = this;
	
	}
	
	void Update() {
	
	}

	public void KillPlayer(Wizard wizard) {
		players.Remove(wizard);
		Destroy(wizard.gameObject);

		if (players.Count == 1) {
			YouWin();
		}
		
	}

	private void YouWin() {
		Debug.Log("You win!");
		winScreen.SetActive(true);
		
	}
}
