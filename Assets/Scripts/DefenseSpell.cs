using UnityEngine;
using System.Collections;

public class DefenseSpell : MonoBehaviour {
	public ElementType element;
	public SpellType type;

	float startTime;

	public void Awake() {
		startTime = Time.time;
	
	}

	public bool IsExpired {
		get {
			return Time.time - startTime > 7;
		}
	}
	
}
