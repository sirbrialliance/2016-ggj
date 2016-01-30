using UnityEngine;
using System.Collections;

public class WizardInput : MonoBehaviour {

	public Wizard wizard;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (wizard.playerNumber == 1) {
			if (Input.GetKeyDown(KeyCode.A)) wizard.CastSpell(ElementType.Fire, SpellType.Attack);
			if (Input.GetKeyDown(KeyCode.W)) wizard.ChangeTarget();

		}
	
	}
}
