using UnityEngine;
using System.Collections;

public class DefenseSpell : MonoBehaviour {
	public ElementType element;
	public SpellType type;

	float startTime;

	public void Awake() {
		Debug.Log("call start " + Time.time);
		startTime = Time.time;
	
	}

	public bool IsExpired {
		get {
			Debug.Log("t " + (Time.time - startTime));
			return Time.time - startTime > 3;
		}
	}
	
}
