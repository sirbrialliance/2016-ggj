using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(WizardInput))]
public class Wizard : MonoBehaviour {
	
	public const int maxHP = 100;
	public int hp = maxHP;
	public int playerNumber = 1;

	WizardInput input;
	Wizard target;
	Vector3 baseHPScale;
	Transform hpBar;

	List<DefenseSpell> defenses = new List<DefenseSpell>();

	void Start() {
		input = GetComponent<WizardInput>();
		input.wizard = this;

		hpBar = transform.FindChild("HP");
		baseHPScale = hpBar.transform.localScale;

		UpdateDamage();
	}
	
	void Update() {
		if (!target) ChangeTarget();

		for (int i = 0 ; i < defenses.Count; ++i) {
			if (defenses[i].IsExpired) {
				Destructor.DoCleanup(defenses[i].gameObject);
				defenses.RemoveAt(i);
				Debug.Log("expire defense");
				--i;
			}
		}

	
	}

	public void CastSpell(ElementType element, SpellType spellType) {
		input.FreezeInput();

		if (spellType == SpellType.Attack) {
			var go = Instantiate(GameManager.Instance.attackEffcts[(int)element]);
			go.name = "Spell";
			go.transform.position = transform.position;
			var spell = go.AddComponent<FlyingSpell>();

			spell.type = spellType;
			spell.element = element;
			spell.target = target;
		} else {
			var go = Instantiate(GameManager.Instance.defendEffcts[(int)element]);
			go.name = "Defense";
			go.transform.position = transform.position;

			var ds = go.AddComponent<DefenseSpell>();
			ds.type = spellType;
			ds.element = element;

			//only one block at a time
			foreach (var defense in defenses) {
				Destructor.DoCleanup(defense.gameObject);
			}
			defenses.Clear();

			defenses.Add(ds);
		}

	}

	public void BeenHit(FlyingSpell spell) {
		var slightlyDefended = false;

		//Wrong elements cut through unalike defenses with little issue
		while (defenses.Count > 0) {

			if (defenses[0].element != spell.element) {
				Destructor.DoCleanup(defenses[0].gameObject);
				defenses.RemoveAt(0);
				slightlyDefended = true;
			} else {
				//matches element, cancel instantly
				Destroy(spell.gameObject);

				//no damage
				return;
			}
		}

		if (slightlyDefended) hp -= 18;
		else hp -= 20;

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

