using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleEstilo : MonoBehaviour {
	DialogManager dialogManager;
	public GameObject Funk;
	public GameObject Rock;
	public GameObject Reggae;
	public GameObject Eletronica;

	// Use this for initialization
	void Start () {
		dialogManager = DialogManager.dialogManager;
		if (dialogManager.Funk == 1) {
			Funk.SetActive (false);
		}
		if (dialogManager.Rock == 1) {
			Rock.SetActive (false);
		}
		if (dialogManager.Reggae == 1) {
			Reggae.SetActive (false);
		}
		if (dialogManager.Eletronica == 1) {
			Eletronica.SetActive (false);
		}
	}
}
