using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleConsMaconha : MonoBehaviour {
	public EscolhasManager esco;
	public GameObject Controle;
	public ControleConsCocaina cocaina;
	public ControleConsAlucinogeno aluc;
	public ControleConsInalantes inala;
	public ControleConsEcstasy ecstasy;

	public Animator AnimConsMaconha;

	public void IniciaAnimacao(){
		/*if (DialogManager.dialogManager.Maconha == 1) {
			Controle.SetActive (true);
			AnimConsMaconha.SetBool ("start", true);
			AnimConsMaconha.SetBool ("aceita", true);
		} else if (DialogManager.dialogManager.Cocaina == 1) {
			cocaina.IniciaAnimacao ();
			gameObject.SetActive (false);
		} else if (DialogManager.dialogManager.Alucinogeno == 1) {
			aluc.IniciaAnimacao ();
			gameObject.SetActive (false);
		} else if (DialogManager.dialogManager.Inalantes == 1) {
			inala.IniciaAnimacao ();
			gameObject.SetActive (false);
		} else if (DialogManager.dialogManager.Ecstasy == 1) {
			ecstasy.IniciaAnimacao ();
			gameObject.SetActive (false);
		} else {
			esco.CarregaFase3 ();
			gameObject.SetActive (false);
		}*/
		esco.CarregaFase3 ();
		//gameObject.SetActive (false);
	}

	public void FinalAnimacao(){
		/*if (AnimConsMaconha.GetBool ("final")) {
			if (DialogManager.dialogManager.Cocaina == 1) {
				cocaina.IniciaAnimacao ();
				gameObject.SetActive (false);
			} else if (DialogManager.dialogManager.Alucinogeno == 1) {
				aluc.IniciaAnimacao ();
				gameObject.SetActive (false);
			} else if (DialogManager.dialogManager.Inalantes == 1) {
				inala.IniciaAnimacao ();
				gameObject.SetActive (false);
			} else if (DialogManager.dialogManager.Ecstasy == 1) {
				ecstasy.IniciaAnimacao ();
				gameObject.SetActive (false);
			} else {
				esco.CarregaFase3 ();
				gameObject.SetActive (false);
			}
		} else {
			AnimConsMaconha.SetBool ("final", true);
		}*/
	}
	/*Criar um estado para final da animação em que apresentará todos os textos e a label informando clique para ir à próxima tela
	 * Usar o click do botão para mudar o state da animação para a final, caso a variavel de controle final não seja true
	 * se a variavel de controle final for true, retira da animação e volta para o jogo
	 * No método de voltar para o jogo, será feito uma verificação da fase e das drogas aceitas antes de ir para a próxima fase.
	*/
}

