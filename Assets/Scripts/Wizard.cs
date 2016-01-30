using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WizardInput))]
public class Wizard : MonoBehaviour {
	

	public int hp = 100;

	WizardInput input;


	void Start() {
		input = GetComponent<WizardInput>();
		input.wizard = this;	
	}
	
	void Update() {

	
	}

	public void CastSpell(ElementType element, SpellType spellType) { }

	public void CancelSpell() { }

	public void ChangeTarget() { }


}

