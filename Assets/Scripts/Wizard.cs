using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WizardInput))]
public class Wizard : MonoBehaviour {
	
	public const int maxHP = 100;
	public int hp = maxHP;
	public int playerNumber = 1;

	WizardInput input;
	Wizard target;
	Vector3 baseHPScale;
	Transform hpBar;

	void Start() {
		input = GetComponent<WizardInput>();
		input.wizard = this;

		hpBar = transform.FindChild("HP");
		baseHPScale = hpBar.transform.localScale;

		UpdateDamage();
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
		hp -= 50;
		UpdateDamage();
	}

	void UpdateDamage() {
		var scale = baseHPScale;
		scale.y *= hp / (float)maxHP;
		hpBar.localScale = scale;

		if (hp <= 0) GameManager.Instance.KillPlayer(this);
	}

	public void ChangeTarget() {
		target = GameManager.Instance.GetNext(this, target);

		var arrow = transform.FindChild("Aim");
		arrow.LookAt(target.transform);
	}


}

