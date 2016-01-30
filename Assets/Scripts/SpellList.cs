using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellList : MonoBehaviour {
	void Start() {
		var desc = "<b>Spells:</b>\n";

		foreach (var spell in Codex.spells) {
			desc += spell.name + ": ";
			foreach (var c in spell.sequence) {
				desc += Codex.displayChars[c];
			}

			desc += "\n";
		}



		GetComponent<Text>().text = desc;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
