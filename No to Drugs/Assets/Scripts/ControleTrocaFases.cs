using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTrocaFases : MonoBehaviour {
	public Animator TrocaFase;
	public AnimationClip ClipTrocaFase;

	public void IniciaAnimacao(int Fase){
		TrocaFase.gameObject.SetActive (true);
		TrocaFase.SetInteger ("Fase", Fase);
		TrocaFase.SetBool ("start", true);

		Invoke ("FinalAnimacao", ClipTrocaFase.length);
	}

	public void FinalAnimacao(){
		gameObject.SetActive (false);
	}
}
