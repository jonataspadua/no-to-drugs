using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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
							Analytics.CustomEvent ("Final: 3A1");
						} else {//else crack
							index = 1;
							Analytics.CustomEvent ("Final: 3A2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 2;
							Analytics.CustomEvent ("Final: 3B1");
						} else {//else crack
							index = 3;
							Analytics.CustomEvent ("Final: 3B2");
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 4;
							Analytics.CustomEvent ("Final: 3C1");
						} else {//else crack
							index = 5;
							Analytics.CustomEvent ("Final: 3C2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 6;
							Analytics.CustomEvent ("Final: 3D1");
						} else {//else crack
							index = 7;
							Analytics.CustomEvent ("Final: 3D2");
						}
					}
				}
			} else {//else cigarro
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 8;
							Analytics.CustomEvent ("Final: 3E1");
						} else {//else crack
							index = 9;
							Analytics.CustomEvent ("Final: 3E2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 10;
							Analytics.CustomEvent ("Final: 3F1");
						} else {//else crack
							index = 11;
							Analytics.CustomEvent ("Final: 3F2");
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 12;
							Analytics.CustomEvent ("Final: 3G1");
						} else {//else crack
							index = 13;
							Analytics.CustomEvent ("Final: 3G2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 14;
							Analytics.CustomEvent ("Final: 3H1");
						} else {//else crack
							index = 15;
							Analytics.CustomEvent ("Final: 3H2");
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
							Analytics.CustomEvent ("Final: 3I1");
						} else {//else crack
							index = 17;
							Analytics.CustomEvent ("Final: 3I2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 18;
							Analytics.CustomEvent ("Final: 3J1");
						} else {//else crack
							index = 19;
							Analytics.CustomEvent ("Final: 3J2");
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 20;
							Analytics.CustomEvent ("Final: 3K1");
						} else {//else crack
							index = 21;
							Analytics.CustomEvent ("Final: 3K2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 22;
							Analytics.CustomEvent ("Final: 3L1");
						} else {//else crack
							index = 23;
							Analytics.CustomEvent ("Final: 3L2");
						}
					}
				}
			} else {//else cigarro
				if (dialog.Maconha == 1) {
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 24;
							Analytics.CustomEvent ("Final: 3M1");
						} else {//else crack
							index = 25;
							Analytics.CustomEvent ("Final: 3M2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 26;
							Analytics.CustomEvent ("Final: 3N1");
						} else {//else crack
							index = 27;
							Analytics.CustomEvent ("Final: 3N2");
						}
					}
				} else {//else maconha
					if (dialog.Cocaina == 1 || dialog.Inalantes == 1 || dialog.Alucinogeno == 1 || dialog.Ecstasy == 1) {
						if (dialog.Crack == 1) {
							index = 28;
							Analytics.CustomEvent ("Final: 3O1");
						} else {//else crack
							index = 29;
							Analytics.CustomEvent ("Final: 3O2");
						}
					} else {//else 4ª droga
						if (dialog.Crack == 1) {
							index = 30;
							Analytics.CustomEvent ("Final: 3P1");
						} else {//else crack
							index = 31;
							Analytics.CustomEvent ("Final: 3P2");
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
		Analytics.CustomEvent ("Fim");
		esco.FinalDoJogo ();
	}
}

