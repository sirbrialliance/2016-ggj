using UnityEngine;
using System.Collections.Generic;

public static class Codex {
	public class SpellRecipie {
		public string name;
		public SpellType type;
		public ElementType element;
		public string sequence;
	}

	public static List<SpellRecipie> spells = new List<SpellRecipie> {
		new SpellRecipie{
			name = "Ice Attack",
			type = SpellType.Attack,
			element = ElementType.Ice,
			sequence = "rlrdl",
		},
		new SpellRecipie{
			name = "Fire Attack",
			type = SpellType.Attack,
			element = ElementType.Fire,
			sequence = "lldrl",
		},
		new SpellRecipie{
			name = "Earth Attack",
			type = SpellType.Attack,
			element = ElementType.Earth,
			sequence = "ddrrl",
		},

		new SpellRecipie{
			name = "Block Ice",
			type = SpellType.Defend,
			element = ElementType.Ice,
			sequence = "lrlrd",
		},
		new SpellRecipie{
			name = "Block Fire",
			type = SpellType.Defend,
			element = ElementType.Fire,
			sequence = "drrrll",
		},
		new SpellRecipie{
			name = "Block Earth",
			type = SpellType.Defend,
			element = ElementType.Earth,
			sequence = "rrldd",
		},

	};

	public static Dictionary<char, string> displayChars = new Dictionary<char, string>{
		{'l', "<"},
		{'d', "•"},
		{'r', ">"},
		{'u', "↶"},
	};


}
