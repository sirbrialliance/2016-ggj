using UnityEngine;
using System.Collections;

public class FlyingSpell : MonoBehaviour {

	public Wizard target;
	public Wizard caster;
	public ElementType element;
	public SpellType type;

	Vector3 initialPos;
	float castTime;
	float flyTime = 5;

	void Start() {
	}

	public void ResetTo(Wizard sender, Wizard target) {
		this.target = target;
		this.caster = sender;

		castTime = Time.time;
		initialPos = transform.position;

		transform.LookAt(target.transform.position);

		flyTime *= .8f;
	}
	
	void Update() {
		if (!target) {
			Destroy(gameObject);
			return;
		}
		var t = (Time.time - castTime) / flyTime;

		if (t >= 1) {
			target.BeenHit(this);
		} else {
			transform.position = Vector3.Lerp(initialPos, target.transform.position, t);
		}
	
	}
}
