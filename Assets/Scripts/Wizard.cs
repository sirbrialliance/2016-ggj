using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WizardInput))]
public class Wizard : MonoBehaviour {
	
	public int hp = 100;
	public int playerNumber = 1;

	WizardInput input;
	Wizard target;

	void Start() {
		input = GetComponent<WizardInput>();
		input.wizard = this;

	}
	
	void Update() {
		if (!target) ChangeTarget();

	
	}

	public void CastSpell(ElementType element, SpellType spellType) {
		if (spellType == SpellType.Attack) {
			var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.name = "Spell";
			go.transform.position = transform.position;
			var spell = go.AddComponent<FlyingSpell>();

			spell.type = spellType;
			spell.element = element;
			spell.target = target;
		} else {

		}

	}

	public void BeenHit(FlyingSpell spell) {
		hp += 20;
		UpdateDamage();
	}

	void UpdateDamage() {
		var hpBar = transform.FindChild("HP");
		var scale = hpBar.localScale;
		scale.y = hp / 100f;
		hpBar.localScale = scale;
	}

	public void ChangeTarget() {
		target = GameManager.Instance.GetNext(this, target);

		var arrow = transform.FindChild("Aim");
		arrow.LookAt(target.transform);
	}


}

