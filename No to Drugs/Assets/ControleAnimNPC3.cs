using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimNPC3 : MonoBehaviour {
	DialogManager dialogManager;
	public Animator animNPC3;

	// Use this for initialization
	void Start () {
		dialogManager = DialogManager.dialogManager;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (dialogManager.isSpeakingn) {
			animNPC3.SetBool ("fala",true);
		} else {
			animNPC3.SetBool ("fala",false);
		}
	}
}
