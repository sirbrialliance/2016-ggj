using UnityEngine;
using System.Collections.Generic;

public class WizardInput : MonoBehaviour {

	/*
		fire attack: left, down, right
		fire defend: left, down, down
		ice attack: down, left, right

	*/

	public List<string> Inputs = new List<string>();



	public Wizard wizard;
	// Use this for initialization
	void Start () {
	
	}

	void fizzle(){
		Inputs.Clear();
		var fe = GameObject.Instantiate(GameManager.Instance.fizzleEffect);
		fe.transform.position = transform.position;
	}

	void GetInput() {
		if (wizard.playerNumber == 1) {
			if (Input.GetKeyDown(KeyCode.W))
				Special();
			else if (Input.GetKeyDown(KeyCode.A))
				Inputs.Add("left");
			else if (Input.GetKeyDown(KeyCode.S))
				Inputs.Add("down");
			else if (Input.GetKeyDown(KeyCode.D))
				Inputs.Add("right");
		} else if (wizard.playerNumber == 2) {
			if (Input.GetKeyDown(KeyCode.I))
				Special();
			else if (Input.GetKeyDown(KeyCode.J))
				Inputs.Add("left");
			else if (Input.GetKeyDown(KeyCode.K))
				Inputs.Add("down");
			else if (Input.GetKeyDown(KeyCode.L))
				Inputs.Add("right");
		} else if (wizard.playerNumber == 3) {
			if (Input.GetKeyDown(KeyCode.UpArrow))
				Special();
			else if (Input.GetKeyDown(KeyCode.LeftArrow))
				Inputs.Add("left");
			else if (Input.GetKeyDown(KeyCode.DownArrow))
				Inputs.Add("down");
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				Inputs.Add("right");
		} else if (wizard.playerNumber == 4) {
			if (Input.GetKeyDown(KeyCode.Keypad8))
				Special();
			else if (Input.GetKeyDown(KeyCode.Keypad4))
				Inputs.Add("left");
			else if (Input.GetKeyDown(KeyCode.Keypad5))
				Inputs.Add("down");
			else if (Input.GetKeyDown(KeyCode.Keypad6))
				Inputs.Add("right");
		}

	}

	void Special() {
		if (Inputs.Count == 0) wizard.ChangeTarget();
		else Inputs.Clear();
	}

	void Update () {
		//if (wizard.playerNumber == 1) {
		//	if (Input.GetKeyDown(KeyCode.A)) wizard.CastSpell(ElementType.Fire, SpellType.Attack);
		//if (Input.GetKeyDown(KeyCode.W)) wizard.ChangeTarget();

		//}
		GetInput();

	
		if (Inputs.Count == 3) {
			if (Inputs[0]== "left") {
				if (Inputs[1] == "down") {
					if (Inputs[2] == "right") {
						wizard.CastSpell (ElementType.Fire, SpellType.Attack);
						Inputs.Clear();
						Debug.Log ("Fire attack");
					} else if (Inputs[2] == "down") {
						wizard.CastSpell (ElementType.Fire, SpellType.Defend);
						Inputs.Clear();
						Debug.Log ("Fire defend");
					} else
						fizzle ();
				} else
					fizzle ();
			} else if (Inputs[0] == "down") {
				if (Inputs[1] == "left") {
					if (Inputs[2] == "right") {
						wizard.CastSpell (ElementType.Ice, SpellType.Attack);
						Inputs.Clear();
						Debug.Log ("Ice attack");
					} else
						fizzle ();
				} else
					fizzle ();
			} else
				fizzle ();
		}
			
	}
}
