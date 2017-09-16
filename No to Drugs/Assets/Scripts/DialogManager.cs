using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
	//variaveis de controle do jogo
	public int Fase;
	public int Estilo;
	public int Alcool=0;
	public int Cigarro=0;
	public int Maconha=0;
	public int Cocaina=0;
	public int Inalantes=0;
	public int Alucinogeno=0;
	public int Ecstasy=0;
	public int Crack=0;

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
		dialogBox.SetActive(true);//Ativa a caixa de dialogo
		isActive = true; //indica que esta ativo o dialogo
		ativaEscolha = false; //Desativa a caixa de escolha
		TrocaDialog(linhasDialogo [currentLine]); //Troca a linha de dialogo atual
		StartCoroutine (TextScroll (linhasDialogo [currentLine])); //começa a escrever na caixa de dialogo
	}

	public void DisableDialogBox(){
		dialogBox.SetActive(false);//desativa a caixa de dialogo
		isActive = false; //informa que está desativada
	}

	public void ReloadScript(TextAsset novoTexto){
		if (novoTexto != null && currentLine>=endAtLine) {//Se não estiver vazio o novo texto e não estiver acima da ultima linha
			arqDialogo = novoTexto; //troca o arquivo carregado
			linhasDialogo = new string[1]; //zera as linhas de dialogo
			linhasDialogo = (novoTexto.text.Split ('\n')); //carrega o novo dialogo
			currentLine = 0; //zera as linhas
			endAtLine = linhasDialogo.Length-1; //troca o novo fim
			EnableDialogBox (); //volta a exibir o dialogo
		}
	}


	void TrocaDialog(string linha){
		if (linha.Contains ("Cleison:")) {//Se for o personagem principal falando, muda a caixa de dialogo para azul e informa que é a vez dele falar
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
		if (!isTyping) {//se não estiver no meio de escrever o texto na tela
			currentLine += 1;//avança uma linha 
			if (currentLine > endAtLine) { //verifica se não era a ultima linha
				ativaEscolha = true;//se for a ultima linha
				choiceBox.SetActive(ativaEscolha); //ativa a caixa de escolha 
				DisableDialogBox ();//Desativa a caixa de dialogo para ficar só a escolha na tela.
			} else {
				StartCoroutine (TextScroll(linhasDialogo[currentLine])); //se não for a ultima linha, continua a escrever na tela
			}
		} else if (isTyping && !cancelTyping) {//se estiver escrevendo e não for definido para cancelar
			cancelTyping = true;//cancela a escrita do texto 
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

	public void Salvar(){
		BinaryFormatter bf = new  BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/playerInfo.dat");

		//Preenche um objeto serializado que é só criar um classe para armazenar os valores e declarar [Serializable] antes dela
		ConfigJogo data = new ConfigJogo();
		data.Fase 			= this.Fase;
		data.Estilo 		= this.Estilo;
		data.Alcool 		= this.Alcool;
		data.Cigarro 		= this.Cigarro;
		data.Maconha 		= this.Maconha;
		data.Cocaina 		= this.Cocaina;
		data.Inalantes 		= this.Inalantes;
		data.Alucinogeno 	= this.Alucinogeno;
		data.Ecstasy 		= this.Ecstasy;
		data.Crack 			= this.Crack;
		//usa o BinaryFormatter para gravar os dados no arquivo
		bf.Serialize(file, data);
		file.Close();
	}

	public void Carregar(){
		if(File.Exists( Application.persistentDataPath+"/playerInfo.dat"))
		{
			BinaryFormatter bf = new  BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath+"/playerInfo.dat" , FileMode.Open );
			//Usa a função bf.Deserialize para pegar os dados de volta e usa um cast antes do bf para o formato do objeto
			ConfigJogo data = (ConfigJogo) bf.Deserialize(file);
			file.Close();

			this.Fase 			= data.Fase;
			this.Estilo 		= data.Estilo;
			this.Alcool 		= data.Alcool;
			this.Cigarro 		= data.Cigarro;
			this.Maconha 		= data.Maconha;
			this.Cocaina 		= data.Cocaina;
			this.Inalantes 		= data.Inalantes;
			this.Alucinogeno 	= data.Alucinogeno;
			this.Ecstasy 		= data.Ecstasy;
			this.Crack 			= data.Crack;
		}
	}
}

[Serializable]
class ConfigJogo
{
	public int Fase; //1 - drogas iniciais: alcool e cigarro / 2 - drogas intermediárias: maconha, cocaina, ecstasy, inalantes e alucinógenos / 3 - Droga final: crack
	public int Estilo; //estilos divididos em: 1 - Funk / 2 - Rock / 3 - Reggae / 4 - Eletronica
	public int Alcool;
	public int Cigarro;
	public int Maconha;
	public int Cocaina;
	public int Inalantes;
	public int Alucinogeno;
	public int Ecstasy;
	public int Crack;
}
