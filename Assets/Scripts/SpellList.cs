using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellList : MonoBehaviour {
	void Start() {
		var desc = "<b>Spells:</b>\n";

		var lastType = SpellType.Attack;

		foreach (var spell in Codex.spells) {
			if (spell.type != lastType) desc += "\n";

			var line = "";

			line += spell.name + ": ";
			line += new string('\t', 5 - line.Length / 4);
			foreach (var c in spell.sequence) {
				line += Codex.displayChars[c];
			}

			desc += "<color=#" + ColorUtility.ToHtmlStringRGB(spell.color) + ">";
			desc += line;
			desc += "</color>\n";

			lastType = spell.type;
		}

		desc += "\nCancel/Change Target: ▲\n";



		GetComponent<Text>().text = desc;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
