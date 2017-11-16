
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTrocaFases : MonoBehaviour {
	public Animator TrocaFase;
	public AnimationClip[] ClipTrocaFase;

	public void IniciaAnimacao(int Fase){		
		TrocaFase.gameObject.SetActive (true);
		if (TrocaFase.GetBool ("start")) {
			TrocaFase.SetBool ("start", false);
			IniciaAnimacao (Fase);
		} else {
			TrocaFase.SetInteger ("Fase", Fase);
			TrocaFase.SetBool ("start", true);
		}
		Invoke ("FinalAnimacao", ClipTrocaFase[Fase-1].length);
	}

	public void FinalAnimacao(){
		if (TrocaFase.GetBool ("start")) {
			TrocaFase.SetInteger ("Fase", 0);
			TrocaFase.SetBool ("start", false);
			gameObject.SetActive (false);
		}

	}
}
