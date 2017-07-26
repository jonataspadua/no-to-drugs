using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogManager : MonoBehaviour
{
	public static DialogManager dialogManager;
	public TrocaSprite trocaSprite;

	public GameObject dialogBox;
	public GameObject choiceBox;
	public GameObject luzes;
	[HideInInspector] public bool olhoVermelhoP;
	public GameObject[] npc;

	public Image imgDialog;
	public Sprite janelaPlayer;
	public Sprite janelaNPC;
	public Renderer background;
	public Text titulo;
	public Text texto;
	public int Fase;

	public TextAsset arqDialogo;
	private string[] linhasDialogo;
	[HideInInspector]public int currentLine;
	[HideInInspector]public int endAtLine;
	public bool isActive;
	[HideInInspector] public bool ativaEscolha;

	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;

	[HideInInspector] public bool isSpeakingp;
	[HideInInspector] public bool isSpeakingn;

	void Awake()
	{
		dialogManager = this;
	}

	// Use this for initialization
	void Start ()
	{
//		player = FindObjectOfType<PlayerController> ();

		//Vai carregar o texto conforme a cena informada no campo codCena
		choiceBox.SetActive(false);
		olhoVermelhoP = false;
		RenderSettings.ambientLight = Color.white;
		if (arqDialogo != null) {
			linhasDialogo = (arqDialogo.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = linhasDialogo.Length - 1;
		}

		if (isActive) {
			EnableDialogBox ();
		} else {
			DisableDialogBox ();
		}
	}

	void Update ()
	{
		if (!isActive) {
			return;
		}

		if ((currentLine >= 0) && (currentLine <= endAtLine)) {
			TrocaDialog(linhasDialogo [currentLine]);
		}

		if (currentLine <= 0)
			currentLine = 0;
	}

	private IEnumerator TextScroll(string lineOfText){
		int letter = 0;
		texto.text = "";
		isTyping = true;
		cancelTyping = false;

		if (lineOfText.Contains ("[iniciotitulo]")) {
			titulo.text = linhasDialogo [currentLine+1];
			currentLine += 1;

			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}

		if (lineOfText.Contains ("[som:risos]")) {
			//animColorFade.SetTrigger ("fade");
			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}

		if (lineOfText.Contains ("[som:soluco]")) {
			//animColorFade.SetTrigger ("fade");
			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}

		if (lineOfText.Contains ("[entranpc1]")) {
			npc [0].SetActive (true);
			npc [1].SetActive (true);
			npc [2].SetActive (false);

			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}


		if (lineOfText.Contains ("[entranpc3]")) {
			npc [0].SetActive (false);
			npc [1].SetActive (false);
			npc [2].SetActive (true);

			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}

		if (lineOfText.Contains ("[cena1]")) {
			trocaSprite.index = 1;
			trocaSprite.Trocar();
			RenderSettings.ambientLight = Color.black;
			luzes.SetActive (true);

			isTyping = false;
			cancelTyping = false;

			ProximaLinha();
			yield break;
		}

		while(isTyping && !cancelTyping &&(letter<lineOfText.Length-1)){
			texto.text += lineOfText[letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);//espera pelo tempo setado em typeSpeed
		}
		texto.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableDialogBox(){
		dialogBox.SetActive(true);
		isActive = true;
		ativaEscolha = false;
		TrocaDialog(linhasDialogo [currentLine]);
		StartCoroutine (TextScroll (linhasDialogo [currentLine]));
	}

	public void DisableDialogBox(){
		dialogBox.SetActive(false);
		isActive = false;
	}

	public void ReloadScript(TextAsset novoTexto){
		if (novoTexto != null && currentLine>=endAtLine) {
			arqDialogo = novoTexto; //troca o arquivo carregado
			linhasDialogo = new string[1]; //zera as linhas de dialogo
			linhasDialogo = (novoTexto.text.Split ('\n')); //carrega o novo dialogo
			currentLine = 0; //zera as linhas
			endAtLine = linhasDialogo.Length-1; //troca o novo fim
			EnableDialogBox (); //volta a exibir o dialogo
		}
	}


	void TrocaDialog(string linha){
		if (linha.Contains ("Cleison:")) {
			dialogManager.isSpeakingp = true;
			dialogManager.isSpeakingn = false;
			imgDialog.sprite = janelaPlayer;
		} else if (linha.Contains (":")) {
			dialogManager.isSpeakingp = false;
			dialogManager.isSpeakingn = false;

			dialogManager.isSpeakingn = true;
			imgDialog.sprite = janelaNPC;
		}
	}

	public void ProximaLinha(){
		if (!isTyping) {
			currentLine += 1;
			if (currentLine > endAtLine) {
				ativaEscolha = true;
				choiceBox.SetActive(ativaEscolha); //ativa a caixa de escolha 
				DisableDialogBox ();
			} else {
				StartCoroutine (TextScroll(linhasDialogo[currentLine]));
			}
		} else if (isTyping && !cancelTyping) {
			cancelTyping = true;
		}
	}

	public void LinhaAnterior()
	{
		if (!isTyping) {
			currentLine -= 1;
			if (currentLine < endAtLine && !isActive) {
				EnableDialogBox ();
			} else if (currentLine < endAtLine && isActive) {
				StartCoroutine (TextScroll (linhasDialogo [currentLine]));
			} else {
				DisableDialogBox ();
			}

		} else if (isTyping && !cancelTyping) {
			cancelTyping = true;
		}
	}

}
