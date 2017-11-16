using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleConsCrack : MonoBehaviour {
	Animator AnimConsCrack;
	public EscolhasManager esco;
	public DialogManager dialog;
	public GameObject[] Cons;
	private int index;

	void Start(){
		dialog = DialogManager.dialogManager;
	}

	public void IniciaAnimacao(){
		if (dialog.Alcool == 1) {
			if (dialog.Cigarro == 1) {
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 0;
						} else {//else crack
							index = 1;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 2;
						} else {//else crack
							index = 3;
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 4;
						} else {//else crack
							index = 5;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 6;
						} else {//else crack
							index = 7;
						}
					}
				}
			} else {//else cigarro
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 8;
						} else {//else crack
							index = 9;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 10;
						} else {//else crack
							index = 11;
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 12;
						} else {//else crack
							index = 13;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 14;
						} else {//else crack
							index = 15;
						}
					}
				}
			}
		} else {//else alcool
			if (dialog.Cigarro == 1) {
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 16;
						} else {//else crack
							index = 17;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 18;
						} else {//else crack
							index = 19;
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 20;
						} else {//else crack
							index = 21;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 22;
						} else {//else crack
							index = 23;
						}
					}
				}
			} else {//else cigarro
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 24;
						} else {//else crack
							index = 25;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 26;
						} else {//else crack
							index = 27;
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 28;
						} else {//else crack
							index = 29;
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 30;
						} else {//else crack
							index = 31;
						}
					}
				}
			}
		}

		Cons [index].SetActive (true);
		AnimConsCrack = Cons [index].GetComponentInChildren<Animator> ();
		AnimConsCrack.SetBool ("start", true);
		if (index == 0) {
			Invoke ("FinalAnimacao", 90);
		} else {
			Invoke ("FinalAnimacao", 120);
		}
	}

	public void FinalAnimacao(){
		Cons [index].SetActive (false);	
		esco.FinalDoJogo ();
	}
}

