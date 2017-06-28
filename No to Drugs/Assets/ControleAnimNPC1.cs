using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimNPC1 : MonoBehaviour {
	DialogManager dialogManager;
	public Animator animNPC1;

	// Use this for initialization
	void Start () {
		dialogManager = DialogManager.dialogManager;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (dialogManager.isSpeakingn) {
			animNPC1.SetBool ("fala",true);
		} else {
			animNPC1.SetBool ("fala",false);
		}
	}
}
