using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleConsCrack : MonoBehaviour {
	public Animator AnimConsCrack;
	public EscolhasManager esco;

	public void IniciaAnimacao(){
		AnimConsCrack.gameObject.SetActive (true);
		AnimConsCrack.SetBool ("start", true);
		AnimConsCrack.SetBool ("aceita", true);
	}

	public void FinalAnimacao(){
		if (AnimConsCrack.GetBool ("final")) {
			Debug.Log ("Definir o final do jogo");
		} else {
			AnimConsCrack.SetBool ("final", true);
		}
	}
	/*Criar um estado para final da animação em que apresentará todos os textos e a label informando clique para ir à próxima tela
	 * Usar o click do botão para mudar o state da animação para a final, caso a variavel de controle final não seja true
	 * se a variavel de controle final for true, retira da animação e volta para o jogo
	 * No método de voltar para o jogo, será feito uma verificação da fase e das drogas aceitas antes de ir para a próxima fase.
	*/
}

