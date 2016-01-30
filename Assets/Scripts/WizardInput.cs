using UnityEngine;
using System.Collections;

public class WizardInput : MonoBehaviour {

	/*
		fire attack: left, down, right
		fire defend: left, down, down
		ice attack: down, left, right

	*/

	public ArrayList Inputs = new ArrayList();



	public Wizard wizard;
	// Use this for initialization
	void Start () {
	
	}

	void fizzle(){
		//Inputs.clear ();
		Inputs.Clear();
		Debug.Log ("fizzle");
	}

	void Update () {
	
		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.W))
				Inputs.Clear();
			else if (Input.GetKeyDown (KeyCode.A))
				Inputs.Add ("left");
			else if (Input.GetKeyDown (KeyCode.S))
				Inputs.Add ("down");
			else if (Input.GetKeyDown (KeyCode.D))
				Inputs.Add ("right");
		}

		if (Inputs.Count == 3) {
			if (Inputs[0]== "left") {
				if (Inputs[1] == "down") {
					if (Inputs[2] == "right") {
						wizard.CastSpell (ElementType.Fire, SpellType.Arttack);
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
						wizard.CastSpell (ElementType.Ices, SpellType.Arttack);
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
