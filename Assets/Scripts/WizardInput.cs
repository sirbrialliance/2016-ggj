using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WizardInput : MonoBehaviour {
	string input = "";

	const float cooldownTime = .5f;


	public Wizard wizard;

	float inputFreezeTime = 0;

	void fizzle() {
		input = "";
		var fe = GameObject.Instantiate(GameManager.Instance.fizzleEffect);
		fe.transform.position = transform.position;

		StartCoroutine(ClearFizzle(fe));

		FreezeInput();
	}

	private IEnumerator ClearFizzle(GameObject fe) {
		yield return new WaitForSeconds(5f);
		Destructor.DoCleanup(fe);
	}

	/** Stops the player form casting for a period of time. */
	public void FreezeInput() {
		input = "";
		inputFreezeTime = Time.time;
	}

	void GetInput() {
		if (wizard.playerNumber == 1) {
			if (Input.GetKeyDown(KeyCode.W))
				Special();
			else if (Input.GetKeyDown(KeyCode.A))
				input += "l";
			else if (Input.GetKeyDown(KeyCode.S))
				input += "d";
			else if (Input.GetKeyDown(KeyCode.D))
				input += "r";
		} else if (wizard.playerNumber == 2) {
			if (Input.GetKeyDown(KeyCode.U))
				Special();
			else if (Input.GetKeyDown(KeyCode.H))
				input += "l";
			else if (Input.GetKeyDown(KeyCode.J))
				input += "d";
			else if (Input.GetKeyDown(KeyCode.K))
				input += "r";
		} else if (wizard.playerNumber == 3) {
			if (Input.GetKeyDown(KeyCode.UpArrow))
				Special();
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
				input += "l";
			else if (Input.GetKeyDown(KeyCode.DownArrow))
				input += "d";
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				input += "r";
		} else if (wizard.playerNumber == 4) {
			if (Input.GetKeyDown(KeyCode.Keypad8))
				Special();
			else if (Input.GetKeyDown(KeyCode.Keypad4))
				input += "l";
			else if (Input.GetKeyDown(KeyCode.Keypad5))
				input += "d";
			else if (Input.GetKeyDown(KeyCode.Keypad6))
				input += "r";
		}

		//allow aiming, but not new spell strokes if in cooldown
		if (inputFreezeTime != 0 && Time.time - inputFreezeTime < cooldownTime) {
			input = "";
		}
	}

	void Special() {
		if (input.Length == 0) wizard.ChangeTarget();
		else input = "";
	}

	void Update () {
		var numIn = input.Length;

		GetInput();

		if (numIn != input.Length) {
			Recognize();
		}
	}

	protected void Recognize() {
		var mayBeValid = false;

		foreach (var spell in Codex.spells) {
			if (input == spell.sequence) {
				wizard.CastSpell(spell.element, spell.type);
				input = "";
				return;
			}
			if (spell.sequence.StartsWith(input)) {
				mayBeValid = true;
			}
		}

		if (!mayBeValid) fizzle();
	}
	
}
