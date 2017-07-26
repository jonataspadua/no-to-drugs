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
	public GameObject controlAlcool;

	public Animator AnimAlcool;
	public AnimationClip animClipAceitaAlcool;
	public AnimationClip animClipRecusaAlcool;

	public Animator AnimConsAlcool;
	public AnimationClip animClipConsAlcool;

	public GameObject controlCigarro;

	public Animator AnimCigarro;
	public AnimationClip animAceitaClipCigarro;
	public AnimationClip animRecusaClipCigarro;

	public Animator AnimConsCigarro;
	public AnimationClip animClipConsCigarro;

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
			if (dialogManager.arqDialogo.name == "dialogo_" + dialogManager.Fase + "a") { //Se o dialogo atual for o primeiro da fase
				AceitaAlcool(true);
				Invoke ("CarregaAnimAlcool", animClipAceitaAlcool.length);
				AnimAlcool.SetBool ("aceita",true);
				AnimAlcool.SetBool ("start",true);
				Invoke ("CarregaDialogoB", animClipConsAlcool.length + animClipAceitaAlcool.length);
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
				dialogo.SetActive(false);
				controlAlcool.SetActive (true);
				Invoke ("CarregaDialogoC", animClipAceitaAlcool.length);
				AnimAlcool.SetBool ("start",true);
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
		AnimConsAlcool.SetBool ("aceita",true);
	}

	void DescarregaAnimAlcool(){
		AnimConsAlcool.SetBool ("start",false);
		AnimConsAlcool.SetBool ("aceita",false);
	}

	void CarregaAnimCigarro(){
		AnimConsCigarro.SetBool ("start",true);
	}

	void CarregaDialogoB(){
		AceitaAlcool (false);
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "b")); //recarrega o script com o dialogo de aceitar
		CarregaBotao ("b"); //carrega os botões desse dialogo 
		dialogManager.olhoVermelhoP = true;
		dialogManager.choiceBox.SetActive (false);
	}

	void RecusaCigarro(bool recusa){
		if (recusa) {
			dialogo.SetActive (false);
			controlCigarro.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlCigarro.SetActive (false);
		}
	}

	void RecusaAlcool(bool recusa){
		if (recusa) {
			dialogo.SetActive (false);
			controlAlcool.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlAlcool.SetActive (false);
		}
	}

	void CarregaDialogoC(){
		AceitaCigarro(false);
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "c"));
		CarregaBotao ("c");
		dialogManager.choiceBox.SetActive (false);
	}

	void AceitaAlcool(bool aceita){
		if (aceita) {
			dialogo.SetActive (false);
			controlAlcool.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlAlcool.SetActive (false);
		}
	}

	void AceitaCigarro(bool aceita){
		if (aceita) {
			dialogo.SetActive (false);
			controlCigarro.SetActive (true);
		} else {
			dialogo.SetActive(true);
			controlCigarro.SetActive (false);
		}
	}
}
