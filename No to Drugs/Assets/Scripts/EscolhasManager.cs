using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhasManager : MonoBehaviour
{

	DialogManager dialogManager;
	public Text txtAceita;
	public Text txtRecusa;

	public GameObject dialogo;

	public GameObject controlAceitaAlcool;
	public Animator AnimAceitaAlcool;
	public AnimationClip animClipAceitaAlcool;
	public Animator AnimConsAlcool;
	public AnimationClip animClipConsAlcool;

	public GameObject controlAceitaCigarro;
	public Animator AnimAceitaCigarro;
	public AnimationClip animAceitaClipCigarro;
	public Animator AnimConsCigarro;
	public AnimationClip animClipConsCigarro;

	public GameObject controlRecusaAlcool;
	public Animator AnimRecusaAlcool;
	public AnimationClip animClipRecusaAlcool;

	public GameObject controlRecusaCigarro;
	public Animator AnimRecusaCigarro;
	public AnimationClip animRecusaClipCigarro;
	// Use this for initialization
	void Start ()
	{
		dialogManager = DialogManager.dialogManager;
		CarregaBotao ("a");
	}

	private void CarregaBotao (string letra)
	{
		TextAsset aceita = (TextAsset)Resources.Load ("txtAceita_" + dialogManager.Fase + letra);
		TextAsset recusa = (TextAsset)Resources.Load ("txtRecusa_" + dialogManager.Fase + letra);
		txtAceita.text = aceita.text;
		txtRecusa.text = recusa.text;
	}

	public void TrocaDialogo (bool escolha)
	{
		if (escolha) {
			/*
			switch(dialogManager.arqDialogo.name){
			case "dialogo_" + dialogManager.Fase + "a":
				{
					dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "b")); //recarrega o script com o dialogo de aceitar
					CarregaBotao ("b"); //carrega os botões desse dialogo 
					dialogManager.choiceBox.SetActive (dialogManager.ativaEscolha); //ativa a caixa de escolha 
					break;
				}
			case "dialogo_" + dialogManager.Fase + "b":
				{
					dialogManager.Fase += 1;
					Debug.Log ("ab");
					//dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "a")); //Aqui já carregamos o dialogo da próxima fase
					SceneManager.LoadScene (dialogManager.Fase);
					break;
				}
			}

			*/

			if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "a") { //Se o dialogo atual for o primeiro da fase
				//AceitaAlcool(true);
				//Invoke ("CarregaAnimAlcool", animClipAceitaAlcool.length);
				//AnimAceitaAlcool.SetBool ("start",true);
				//Invoke ("CarregaDialogoB", animClipConsAlcool.length + animClipAceitaAlcool.length);
				CarregaDialogoB ();
			} else if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "b") { //se o dialogo atual for o de aceitar, vamos procurar o texto e a cena correspondentes ao próximo
				//AceitaCigarro(true);
				//Invoke ("CarregaAnimCigarro", animClipAceitaAlcool.length);
				//AnimAceitaCigarro.SetBool ("start",true);
			} else if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "c") {
				//AceitaCigarro(true);
				//Invoke ("CarregaAnimCigarro", animClipAceitaAlcool.length);
				//AnimAceitaCigarro.SetBool ("start",true);
			} else {
				dialogManager.DisableDialogBox ();
			}
		} else {
			if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "a") {
				/*dialogo.SetActive(false);
				controlRecusaAlcool.SetActive (true);
				Invoke ("CarregaDialogoC", animClipAceitaAlcool.length);
				AnimAceitaAlcool.SetBool ("start",true);*/
				CarregaDialogoC ();
			} else if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "b") {
				//RecusaCigarro(true);
				//Invoke ("CarregaAnimCigarro", animClipAceitaAlcool.length);
				//AnimAceitaCigarro.SetBool ("start",true);
			} else if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "c") {
				//dialogManager.Fase += 2;
				//Debug.Log ("rc");
				//dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "a"));
				//SceneManager.LoadScene (dialogManager.Fase);
			} else {
				dialogManager.DisableDialogBox ();
			}

		}
	}

	void CarregaAnimAlcool(){
		AnimConsAlcool.SetBool ("start",true);
	}

	void CarregaAnimCigarro(){
		AnimConsCigarro.SetBool ("start",true);
	}

	void CarregaDialogoB(){
		//AceitaAlcool (false);
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "b")); //recarrega o script com o dialogo de aceitar
		CarregaBotao ("b"); //carrega os botões desse dialogo 
		dialogManager.olhoVermelhoP = true;
		dialogManager.choiceBox.SetActive (false);
	}

	void RecusaCigarro(bool recusa){
		if (recusa) {
			dialogo.SetActive (false);
			controlRecusaCigarro.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlRecusaCigarro.SetActive (false);
		}
	}

	void RecusaAlcool(bool recusa){
		if (recusa) {
			dialogo.SetActive (false);
			controlRecusaAlcool.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlRecusaAlcool.SetActive (false);
		}
	}

	void CarregaDialogoC(){
		//AceitaCigarro(false);
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "c"));
		CarregaBotao ("c");
		dialogManager.choiceBox.SetActive (false);
	}

	void AceitaAlcool(bool aceita){
		if (aceita) {
			dialogo.SetActive (false);
			controlAceitaAlcool.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlAceitaAlcool.SetActive (false);
		}
	}

	void AceitaCigarro(bool aceita){
		if (aceita) {
			dialogo.SetActive (false);
			controlAceitaCigarro.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlAceitaCigarro.SetActive (false);
		}
	}
}
