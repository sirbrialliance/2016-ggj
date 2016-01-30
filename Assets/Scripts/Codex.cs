using UnityEngine;
using System.Collections.Generic;

public static class Codex {
	public class SpellRecipe {
		public string name;
		public SpellType type;
		public ElementType element;
		public string sequence;
		public Color color;
	}

	public static List<SpellRecipe> spells = new List<SpellRecipe> {
		new SpellRecipe{
			name = "Ice Attack",
			type = SpellType.Attack,
			element = ElementType.Ice,
			sequence = "rlrdl",
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Fire Attack",
			type = SpellType.Attack,
			element = ElementType.Fire,
			sequence = "lldrl",
			color = Color.red,
		},
		new SpellRecipe{
			name = "Earth Attack",
			type = SpellType.Attack,
			element = ElementType.Earth,
			sequence = "ddrrl",
			color = Color.green,
		},

		new SpellRecipe{
			name = "Block Ice",
			type = SpellType.Defend,
			element = ElementType.Ice,
			sequence = "lrlrd",
			color = Color.blue,
		},
		new SpellRecipe{
			name = "Block Fire",
			type = SpellType.Defend,
			element = ElementType.Fire,
			sequence = "drrrll",
			color = Color.red,
		},
		new SpellRecipe{
			name = "Block Earth",
			type = SpellType.Defend,
			element = ElementType.Earth,
			sequence = "rrldd",
			color = Color.green,
		},

	};

	public static Dictionary<char, string> displayChars = new Dictionary<char, string>{
		{'l', "◀"},
		{'d', "▼"},
		{'r', "▶"},
		{'u', "↶"},
	};


}
