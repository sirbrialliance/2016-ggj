using UnityEngine;
using System.Collections;

public class FlyingSpell : MonoBehaviour {

	public Wizard target;
	public ElementType element;
	public SpellType type;

	Vector3 initialPos;
	float castTime;
	float flyTime = 5;

	void Start() {
		castTime = Time.time;
		initialPos = transform.position;

	
	}
	
	void Update() {
		if (!target) {
			Destroy(gameObject);
			return;
		}
		var t = (Time.time - castTime) / flyTime;

		if (t >= 1) {
			target.BeenHit(this);
			Destroy(gameObject);
		} else {
			transform.position = Vector3.Lerp(initialPos, target.transform.position, t);
		}
	
	}
}
