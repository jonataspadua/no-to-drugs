using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimacao : MonoBehaviour {
	DialogManager dialogManager;
	public Animator animPersonagem;
	public GameObject olhoDNormal;
	public GameObject olhoDVermelho;
	public GameObject olhoENormal;
	public GameObject olhoEVermelho;

	// Use this for initialization
	void Start () {
		dialogManager = DialogManager.dialogManager;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dialogManager.isSpeakingp) {
			animPersonagem.SetBool ("fala",true);
			if (dialogManager.olhoVermelhoP) {
				animPersonagem.SetBool ("olhoV", true);
			} else {
				animPersonagem.SetBool ("olhoV", false);
			}
		} else {
			animPersonagem.SetBool ("fala",false);
			if (dialogManager.olhoVermelhoP) {
				animPersonagem.SetBool ("olhoV", true);
			} else {
				animPersonagem.SetBool ("olhoV", false);
			}
		}
	}

	public void TrocaOlho(bool OlhoV){
		if (OlhoV) {
			if (dialogManager.olhoVermelhoP) {	
				olhoDNormal.SetActive (false);
				olhoDVermelho.SetActive (true);
				olhoENormal.SetActive (false);
				olhoEVermelho.SetActive (true);
			}
		} else {
			olhoDNormal.SetActive(true);
			olhoDVermelho.SetActive (false);
			olhoENormal.SetActive(true);
			olhoEVermelho.SetActive (false);
		}
	}
}
