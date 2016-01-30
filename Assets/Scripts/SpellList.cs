using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellList : MonoBehaviour {
	void Start() {
		var desc = "<b>Spells:</b>\n";

		var lastType = SpellType.Attack;

		foreach (var spell in Codex.spells) {
			if (spell.type != lastType) desc += "\n";

			desc += spell.name + ": ";
			foreach (var c in spell.sequence) {
				desc += Codex.displayChars[c];
			}

			desc += "\n";

			lastType = spell.type;
		}

		desc += "\nCancel/Change Target: ▲\n";



		GetComponent<Text>().text = desc;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
