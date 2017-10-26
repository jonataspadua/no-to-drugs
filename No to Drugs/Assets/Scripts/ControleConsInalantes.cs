using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleConsInalantes : MonoBehaviour {
	public Animator AnimConsInalantes;
	public EscolhasManager esco;

	public void IniciaAnimacao(){
		AnimConsInalantes.gameObject.SetActive (true);
		AnimConsInalantes.SetBool ("start", true);
		AnimConsInalantes.SetBool ("aceita", true);
	}

	public void FinalAnimacao(){
		if (AnimConsInalantes.GetBool ("final")) {
			esco.CarregaFase3 ();
			gameObject.SetActive (false);
		} else {
			AnimConsInalantes.SetBool ("final", true);
		}
	}
	/*Criar um estado para final da animação em que apresentará todos os textos e a label informando clique para ir à próxima tela
	 * Usar o click do botão para mudar o state da animação para a final, caso a variavel de controle final não seja true
	 * se a variavel de controle final for true, retira da animação e volta para o jogo
	 * No método de voltar para o jogo, será feito uma verificação da fase e das drogas aceitas antes de ir para a próxima fase.
	*/
}

