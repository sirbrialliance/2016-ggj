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
			sequence = "rdr",
		},
		new SpellRecipie{
			name = "Fire Attack",
			type = SpellType.Attack,
			element = ElementType.Fire,
			sequence = "ldr",
		},
		new SpellRecipie{
			name = "Earth Attack",
			type = SpellType.Attack,
			element = ElementType.Earth,
			sequence = "ddr",
		},

		new SpellRecipie{
			name = "Ice Defend",
			type = SpellType.Defend,
			element = ElementType.Ice,
			sequence = "rdd",
		},
		new SpellRecipie{
			name = "Fire Defend",
			type = SpellType.Defend,
			element = ElementType.Fire,
			sequence = "ldd",
		},
		new SpellRecipie{
			name = "Earth Defend",
			type = SpellType.Defend,
			element = ElementType.Earth,
			sequence = "ddd",
		},

	};


}
