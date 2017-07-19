using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimNPC2 : MonoBehaviour {

	DialogManager dialogManager;
	public Animator animNPC2;

	// Use this for initialization
	void Start () {
		dialogManager = DialogManager.dialogManager;
	}

	// Update is called once per frame
	void Update () {
		if (dialogManager.isSpeakingn) {
			animNPC2.SetBool ("fala",true);
		} else {
			animNPC2.SetBool ("fala",false);
		}
	}
}
