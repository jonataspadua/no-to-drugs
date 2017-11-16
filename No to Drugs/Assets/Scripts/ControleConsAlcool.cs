using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleConsAlcool : MonoBehaviour {
	public GameObject Controle;
	public ControleConsCigarro cig;
	public EscolhasManager esco;
	public Animator AnimConsAlcool;

	public void IniciaAnimacao(){
		//if (DialogManager.dialogManager.Alcool == 1) { // se aceitou o alcool começa a animação
			//Controle.SetActive (true);
			//AnimConsAlcool.SetBool ("start", true);
			//AnimConsAlcool.SetBool ("aceita", true);
			esco.CarregaFase2 ();
			//gameObject.SetActive (false);
		//} else if (DialogManager.dialogManager.Cigarro == 1) { //se não aceitou o alcool mas aceitou o cigarro, começa a do cigarro
			//cig.IniciaAnimacao ();
			//gameObject.SetActive (false);
		//	esco.CarregaFase2 ();
		//	gameObject.SetActive (false);
		//} else { //se não aceitou nenhum só vai para a fase 2
		//	esco.CarregaFase2 ();
		//	gameObject.SetActive (false);
		//}
	}

	public void FinalAnimacao(){
		/*if (AnimConsAlcool.GetBool ("final")) {
			if (DialogManager.dialogManager.Cigarro == 1) {
				//cig.IniciaAnimacao ();
				esco.CarregaFase2 ();
				gameObject.SetActive (false);
			} else {
				esco.CarregaFase2 ();
				gameObject.SetActive (false);
			}
		} else {
			esco.CarregaFase2 ();
			gameObject.SetActive (false);
			//AnimConsAlcool.SetBool ("final", true);
		}*/
		//esco.CarregaFase2 ();
		//gameObject.SetActive (false);
	}
	/*Criar um estado para final da animação em que apresentará todos os textos e a label informando clique para ir à próxima tela
	 * Usar o click do botão para mudar o state da animação para a final, caso a variavel de controle final não seja true
	 * se a variavel de controle final for true, retira da animação e volta para o jogo
	 * No método de voltar para o jogo, será feito uma verificação da fase e das drogas aceitas antes de ir para a próxima fase.
	*/
}

