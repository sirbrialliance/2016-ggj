using UnityEngine;
using System.Collections.Generic;

public static class Codex {
	public class SpellRecipe {
		public string name;
		public SpellType type;
		public ElementType element;
		public string sequence;
		public int sequenceLength;
		public Color color;
	}

	public static List<SpellRecipe> spells = new List<SpellRecipe> {
		new SpellRecipe{
			name = "Icicle Crash",
			type = SpellType.Attack,
			element = ElementType.Ice,
			sequenceLength = 4,
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Lava Lash",
			type = SpellType.Attack,
			element = ElementType.Fire,
			sequenceLength = 4,
			color = Color.red,
		},
		new SpellRecipe{
			name = "Shale Shatter",
			type = SpellType.Attack,
			element = ElementType.Earth,
			sequenceLength = 4,
			color = Color.green,
		},

		new SpellRecipe{
			name = "Ice Aegis",
			type = SpellType.Defend,
			element = ElementType.Ice,
			sequenceLength = 3,
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Lava Aegis",
			type = SpellType.Defend,
			element = ElementType.Fire,
			sequenceLength = 3,
			color = Color.red,
		},
		new SpellRecipe{
			name = "Stone Aegis",
			type = SpellType.Defend,
			element = ElementType.Earth,
			sequenceLength = 3,
			color = Color.green,
		},

	};

	private static string MakeSpell(int len) {
		var ret = "";
		while (ret.Length < len) {
			switch (Random.Range(0, 3)) {
				case 0: ret += "l"; break;
				case 1: ret += "r"; break;
				case 2: ret += "d"; break;
			}
		}
		return ret;
	}

	public static void CreateSpells() {
		foreach (var spell in spells) {

			var needSpell = true;
			while (needSpell) {
				spell.sequence = MakeSpell(spell.sequenceLength);
				needSpell = false;

				//does the spell overlap anything?
				foreach (var otherSpell in spells) {
					if (string.IsNullOrEmpty(otherSpell.sequence)) continue;
					if (otherSpell == spell) continue;

					if (otherSpell.sequence.StartsWith(spell.sequence) || spell.sequence.StartsWith(otherSpell.sequence)) {
						needSpell = true;
					}
				}
			}
		}
	}

	public static Dictionary<char, string> displayChars = new Dictionary<char, string>{
		{'l', "◀"},
		{'d', "▼"},
		{'r', "▶"},
		{'u', "↶"},
	};


}
