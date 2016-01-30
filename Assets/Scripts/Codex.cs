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
			sequenceLength = 5,
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Lava Lash",
			type = SpellType.Attack,
			element = ElementType.Fire,
			sequenceLength = 5,
			color = Color.red,
		},
		new SpellRecipe{
			name = "Shale Shatter",
			type = SpellType.Attack,
			element = ElementType.Earth,
			sequenceLength = 5,
			color = Color.green,
		},

		new SpellRecipe{
			name = "Ice Aegis",
			type = SpellType.Defend,
			element = ElementType.Ice,
			sequenceLength = 4,
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Lava Aegis",
			type = SpellType.Defend,
			element = ElementType.Fire,
			sequenceLength = 4,
			color = Color.red,
		},
		new SpellRecipe{
			name = "Stone Aegis",
			type = SpellType.Defend,
			element = ElementType.Earth,
			sequenceLength = 4,
			color = Color.green,
		},

	};

	public static void CreateSpells() {
		foreach (var spell in spells) {
			spell.sequence = "";
			while (spell.sequence.Length < spell.sequenceLength) {
				switch (Random.Range(0, 3)) {
					case 0: spell.sequence += "l"; break;
					case 1: spell.sequence += "r"; break;
					case 2: spell.sequence += "d"; break;
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
