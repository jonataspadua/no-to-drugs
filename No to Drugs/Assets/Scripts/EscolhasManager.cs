﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhasManager : MonoBehaviour
{
	public static EscolhasManager escolhasManager;

	DialogManager dialogManager;
	public Text txtAceita;
	public Text txtRecusa;

	public GameObject dialogo;
	public GameObject controlAlcool;

	public Animator AnimAlcool;
	public AnimationClip animClipAceitaAlcool;
	public AnimationClip animClipRecusaAlcool;

	public ControleConsAlcool al;

	public GameObject controlCigarro;

	public Animator AnimCigarro;
	public AnimationClip animAceitaClipCigarro;
	public AnimationClip animRecusaClipCigarro;

	public GameObject controlMaconha;

	public Animator AnimMaconha;
	public AnimationClip animAceitaClipMaconha;
	public AnimationClip animRecusaClipMaconha;
	public ControleConsMaconha mac;

	public GameObject controlAlucinogeno;

	public Animator AnimAlucinogeno;
	public AnimationClip animAceitaClipAlucinogeno;
	public AnimationClip animRecusaClipAlucinogeno;

	public GameObject controlCocaina;

	public Animator AnimCocaina;
	public AnimationClip animAceitaClipCocaina;
	public AnimationClip animRecusaClipCocaina;

	public GameObject controlCrack;

	public Animator AnimCrack;
	public AnimationClip animAceitaClipCrack;
	public AnimationClip animRecusaClipCrack;
	public ControleConsCrack crack;

	public GameObject controlEcstasy;

	public Animator AnimEcstasy;
	public AnimationClip animAceitaClipEcstasy;
	public AnimationClip animRecusaClipEcstasy;

	public GameObject controlInalante;

	public Animator AnimInalante;
	public AnimationClip animAceitaClipInalante;
	public AnimationClip animRecusaClipInalante;

	void Awake()
	{
		escolhasManager = this;
	}

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

	private void AtivaMaconha(bool escolha, string tipoDialogo){
		if (escolha) {//se aceitou
			dialogManager.Maconha = 1;
			dialogManager.olhoVermelhoP = true; //muda os olhos para vermelho 
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaMaconha (true);//habilita o controle da maconha e desativa o dialogo
			//Invoke ("CarregaConsMaconha", animAceitaClipMaconha.length);//Prepara a consequencia para aparecer após a animação da maconha
			AnimMaconha.SetBool ("aceita", true);//define que ele aceitou maconha na animação
			AnimMaconha.SetBool ("start", true);//define que vai começar a animação
			switch (tipoDialogo)
			{
			case "A":
				{
					StartCoroutine (CarregaDialogo2('A',2, animAceitaClipMaconha.length));
					break;
				}
			case "B":
				{
					StartCoroutine (CarregaDialogo2('B',2,animAceitaClipMaconha.length));
					break;
				}
			case "C":
				{
					StartCoroutine (CarregaDialogo2('C',2,animAceitaClipMaconha.length));
					break;
				}
			case "D":
				{
					StartCoroutine (CarregaDialogo2('D',2,animAceitaClipMaconha.length));
					break;
				}
			}
		} else {
			dialogManager.Maconha = 0;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaMaconha (true);//habilita o controle da maconha e desativa o dialogo
			AnimMaconha.SetBool ("aceita", false);//define que ele não aceitou maconha na animação
			AnimMaconha.SetBool ("start", true);//define que vai começar a animação
			switch (tipoDialogo)
			{
			case "A":
				{
					StartCoroutine (CarregaDialogo2('A',3,animRecusaClipMaconha.length));
					break;
				}
			case "B":
				{
					StartCoroutine (CarregaDialogo2('B',3,animRecusaClipMaconha.length));
					break;
				}
			case "C":
				{
					StartCoroutine (CarregaDialogo2('C',3,animRecusaClipMaconha.length));
					break;
				}
			case "D":
				{
					StartCoroutine (CarregaDialogo2('D',3,animRecusaClipMaconha.length));
					break;
				}
			}
		}
	}

	private void AtivaInalantes(bool escolha){
		if (escolha) {//se ele aceitou inalantes entra aqui
			dialogManager.Inalantes = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaInalante (true);//habilita o controle dos inalantes
			Invoke ("CarregaConsMaconha", animAceitaClipInalante.length);//Prepara a consequencia para aparecer após a animação dos inalantes
			AnimInalante.SetBool ("aceita", true);//define que ele aceitou inalantes na animação
			AnimInalante.SetBool ("start", true);//define que vai começar a animação
			//Invoke ("CarregaFase3", animClipConsInalante.length + animAceitaClipInalante.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
		} else {
			dialogManager.Inalantes = 0;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaInalante (true);//habilita o controle dos inalantes e desativa o dialogo
			Invoke ("CarregaConsMaconha", animRecusaClipInalante.length);//Prepara a consequencia para aparecer após a animação dos inalantes
			AnimInalante.SetBool ("aceita", false);//define que ele nao aceitou os inalantes na animação
			AnimInalante.SetBool ("start", true);//define que vai começar a animação
		}
	}

	private void AtivaCocaina(bool escolha){
		if (escolha) {//se ele aceitou fumar cigarro entra aqui
			dialogManager.Cocaina = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaCocaina (true);//habilita o controle do cigarro
			Invoke ("CarregaConsMaconha", animAceitaClipCocaina.length);//Prepara a consequencia para aparecer após a animação do cigarro
			AnimCocaina.SetBool ("aceita", true);//define que ele aceitou alcool na animação
			AnimCocaina.SetBool ("start", true);//define que vai começar a animação
			//Invoke ("CarregaFase3", animClipConsCocaina.length + animAceitaClipCocaina.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
		} else {
			dialogManager.Cocaina = 0;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaCocaina (true);//habilita o controle do cigarro e desativa o dialogo
			Invoke ("CarregaConsMaconha", animRecusaClipCocaina.length);//Prepara a função que carrega a próxima fase após a animação rodar
			AnimCocaina.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
			AnimCocaina.SetBool ("start", true);//define que vai começar a animação
		}
	}

	private void AtivaAlucinogeno(bool escolha){
		if (escolha) {//se ele aceitou fumar cigarro entra aqui
			dialogManager.Alucinogeno = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaAlucinogeno (true);//habilita o controle do cigarro
			Invoke ("CarregaConsMaconha", animAceitaClipAlucinogeno.length);//Prepara a consequencia para aparecer após a animação do cigarro
			AnimAlucinogeno.SetBool ("aceita", true);//define que ele aceitou alcool na animação
			AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
			//Invoke ("CarregaFase3", animClipConsAlucinogeno.length + animAceitaClipAlucinogeno.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
		} else {
			dialogManager.Alucinogeno = 0;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaAlucinogeno (true);//habilita o controle do cigarro e desativa o dialogo
			Invoke ("CarregaConsMaconha", animRecusaClipAlucinogeno.length);//Prepara a função que carrega a próxima fase após a animação rodar
			AnimAlucinogeno.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
			AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
		}
	}

	private void AtivaEcstasy(bool escolha){
		if (escolha) {//se ele aceitou fumar cigarro entra aqui
			dialogManager.Ecstasy = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaEcstasy (true);//habilita o controle do cigarro
			Invoke ("CarregaConsMaconha", animAceitaClipEcstasy.length);//Prepara a consequencia para aparecer após a animação do cigarro
			AnimEcstasy.SetBool ("aceita", true);//define que ele aceitou alcool na animação
			AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
			//Invoke ("CarregaFase3", animClipConsEcstasy.length + animAceitaClipEcstasy.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
		} else {
			dialogManager.Ecstasy = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaEcstasy (true);//habilita o controle do cigarro e desativa o dialogo
			Invoke ("CarregaConsMaconha", animRecusaClipEcstasy.length);//Prepara a função que carrega a próxima fase após a animação rodar
			AnimEcstasy.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
			AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
		}
	}

	private void AtivaCrack(bool escolha){
		if (escolha) {//se ele aceitou fumar cigarro entra aqui
			dialogManager.Crack = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaCrack (true);//habilita o controle do cigarro
			Invoke ("CarregaConsCrack", animAceitaClipCrack.length);//Prepara a consequencia para aparecer após a animação do cigarro
			AnimCrack.SetBool ("aceita", true);//define que ele aceitou alcool na animação
			AnimCrack.SetBool ("start", true);//define que vai começar a animação
			//Invoke ("CarregaFase3", animClipConsCrack.length + animAceitaClipCrack.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
		} else {
			dialogManager.Crack = 1;
			dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
			AceitaCrack (true);//habilita o controle do cigarro e desativa o dialogo
			Invoke ("CarregaConsCrack", animRecusaClipCrack.length);//Prepara a função que carrega a próxima fase após a animação rodar
			AnimCrack.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
			AnimCrack.SetBool ("start", true);//define que vai começar a animação
		}
	}


	public void TrocaDialogo (bool escolha)
	{
		switch (dialogManager.Fase) {
		case 1:
			{
				switch (dialogManager.arqDialogo.name) {
				case "dialogo_1a"://caso seja a primeira fase e o primeiro dialogo faz as seguintes ações - ALCOOL
					{
						if (escolha) {
							dialogManager.Alcool = 1;
							dialogManager.olhoVermelhoP = true; //muda os olhos para vermelho
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaAlcool (true);//habilita o controle do alcool e desativa o dialogo
							AnimAlcool.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimAlcool.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaDialogoB", animClipAceitaAlcool.length);//Prepara a função que carrega o dialogo B após as duas animações ocorrem
						} else {
							dialogManager.Alcool = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaAlcool (true);//habilita o controle do alcool e desativa o dialogo
							Invoke ("CarregaDialogoC", animClipRecusaAlcool.length);//Prepara a função que carrega o dialogo C após a animação rodar
							AnimAlcool.SetBool ("aceita", false);//define que ele nao aceitou o alcool na animação
							AnimAlcool.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				case "dialogo_1b"://caso seja a primeira fase e o dialogo seja depois de aceitar a bebida faz as seguintes ações - CIGARRO
					{
						if (escolha) {//se ele aceitou fumar cigarro entra aqui
							dialogManager.Cigarro = 1;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro
							Invoke ("CarregaConsAlcool", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							//Invoke ("CarregaConsCigarro", animClipConsAlcool.length + animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação da consequencia do alcool
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							//Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.Cigarro = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaConsAlcool", animRecusaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				case "dialogo_1c"://caso seja a primeira fase e o dialogo seja depois de recusar a bebida faz as seguintes ações - CIGARRO
					{
						if (escolha) {//se ele aceitou fumar cigarro entra aqui
							dialogManager.Cigarro = 1;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro
							Invoke ("CarregaConsAlcool", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							//Invoke ("CarregaConsCigarro", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							//Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.Cigarro = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaConsAlcool", animRecusaClipCigarro.length);//Prepara a função que carrega a próxima fase após a animação rodar
							AnimCigarro.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				default:
					{
						dialogManager.DisableDialogBox ();
						break;
					}
				}
				break;
			}
		case 2:
			{
				switch (dialogManager.arqDialogo.name) {
				case "dialogo_2A1"://caso seja a segunda fase e o primeiro dialogo faz as seguintes ações - MACONHA
					{
						AtivaMaconha(escolha,"A");
						break;
					}
				case "dialogo_2B1"://caso seja a segunda fase e o primeiro dialogo faz as seguintes ações - MACONHA
					{
						AtivaMaconha(escolha,"B");
						break;
					}
				case "dialogo_2C1"://caso seja a segunda fase e o primeiro dialogo faz as seguintes ações - MACONHA
					{
						AtivaMaconha(escolha,"C");						
						break;
					}
				case "dialogo_2D1"://caso seja a segunda fase e o primeiro dialogo faz as seguintes ações - MACONHA
					{
						AtivaMaconha(escolha,"D");						
						break;
					}
				case "dialogo_2A2"://caso seja a segunda fase e o dialogo seja depois de aceitar a maconha faz as seguintes ações
					{
						switch (dialogManager.Estilo) {//dependendo dos estilos terá acesso a tipos diferentes de drogas
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2B2"://caso seja a segunda fase e o dialogo seja depois de aceitar a maconha faz as seguintes ações
					{
						switch (dialogManager.Estilo) {//dependendo dos estilos terá acesso a tipos diferentes de drogas
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2C2"://caso seja a segunda fase e o dialogo seja depois de aceitar a maconha faz as seguintes ações
					{
						switch (dialogManager.Estilo) {//dependendo dos estilos terá acesso a tipos diferentes de drogas
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2D2"://caso seja a segunda fase e o dialogo seja depois de aceitar a maconha faz as seguintes ações
					{
						switch (dialogManager.Estilo) {//dependendo dos estilos terá acesso a tipos diferentes de drogas
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2A3":
					{
						switch (dialogManager.Estilo) {
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2B3":
					{
						switch (dialogManager.Estilo) {
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2C3":
					{
						switch (dialogManager.Estilo) {
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
						break;
					}
				case "dialogo_2D3":
					{
						switch (dialogManager.Estilo) {
						case 1: //Funk - Inalantes
							{
								AtivaInalantes (escolha);
								break;
							}
						case 2: //Rock
							{
								AtivaCocaina (escolha);
								break;
							}
						case 3: //Reggae
							{
								AtivaAlucinogeno (escolha);
								break;
							}
						case 4: //Eletronica
							{
								AtivaEcstasy (escolha);
								break;
							}
						}
								
						break;
					}
				default:
					{
						dialogManager.DisableDialogBox ();
						break;
					}
				}

				break;
			}
		case 3:
			{
				AtivaCrack(escolha);
				break;
			}
		default:
			{
				dialogManager.DisableDialogBox ();
				break;
			}
		}
		dialogManager.Salvar ();
	}

	void CarregaConsAlcool ()
	{
		al.IniciaAnimacao ();
	}

	void CarregaConsMaconha ()
	{
		mac.IniciaAnimacao ();
	}

	void CarregaConsCrack ()
	{
		crack.IniciaAnimacao ();
	}

	void CarregaDialogoB ()
	{
		DesabilitaControlAnimacoes ();

		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "b")); //recarrega o script com o dialogo de aceitar
		CarregaBotao ("b"); //carrega os botões desse dialogo 
	}

	void CarregaDialogoA ()
	{
		DesabilitaControlAnimacoes ();
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "a")); //recarrega o script com o dialogo de aceitar
		CarregaBotao ("a"); //carrega os botões desse dialogo 
	}

	IEnumerator CarregaDialogo3 (char letra, int parte, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);//aguarda o tempo da animação anterior para começar essa
		DesabilitaControlAnimacoes (); 
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_3"+letra + parte)); //recarrega o script com o dialogo de aceitar
		CarregaBotao (letra.ToString()+parte.ToString()); //carrega os botões desse dialogo 
	}

	IEnumerator CarregaDialogo2 (char letra, int parte, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);//aguarda o tempo da animação anterior para começar essa
		DesabilitaControlAnimacoes (); 
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_2"+letra + parte)); //recarrega o script com o dialogo de aceitar
		CarregaBotao (letra.ToString()+parte.ToString()); //carrega os botões desse dialogo 
	}

	public void CarregaFase2 ()
	{
		Debug.Log ("CarregaFase2");
		if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 2;
			StartCoroutine(CarregaDialogo2 ('A',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0)) {//Se a primeira foi aceita e a segunda recusada, carrega 2B
			dialogManager.Fase = 2;
			StartCoroutine (CarregaDialogo2 ('B',1, 1f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1)) {//Se a primeira foi recusada e a segunda aceita, carrega 2C
			dialogManager.Fase = 2;
			StartCoroutine (CarregaDialogo2 ('C',1,1f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0)) {//se nenhuma foi aceita, carrega a fase 2D
			dialogManager.Fase = 2;
			StartCoroutine (CarregaDialogo2 ('D',1,1f));
		}
	}

	public void CarregaFase3 ()
	{
		if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1) &&  (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('A',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('B',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('C',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('D',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0) &&  (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('E',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('F',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('G',1,0f));
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('H',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1) &&  (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('I',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('J',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('K',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('L',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0) &&  (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('M',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 1) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('N',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('O',1,0f));
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0) && (dialogManager.Maconha == 0) && (dialogManager.Cocaina == 0 && dialogManager.Alucinogeno == 0 && dialogManager.Ecstasy == 0 && dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			StartCoroutine (CarregaDialogo3 ('P',1,0f));
		}
	}

	void CarregaDialogoC ()
	{
		DesabilitaControlAnimacoes ();
		dialogManager.ReloadScript ((TextAsset)Resources.Load ("dialogo_" + dialogManager.Fase + "c"));
		CarregaBotao ("c");
		dialogManager.choiceBox.SetActive (false);
	}

	void AceitaAlcool (bool aceita)
	{
		
		if (aceita) {
			dialogo.SetActive (false);
			controlAlcool.SetActive (true);

		} else {
			dialogo.SetActive (true);
			controlAlcool.SetActive (false);
		}
	}

	void AceitaCigarro (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlCigarro.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlCigarro.SetActive (false);
		}
	}

	void AceitaCocaina (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlCocaina.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlCocaina.SetActive (false);
		}
	}

	void AceitaCrack (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlCrack.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlCrack.SetActive (false);
		}
	}

	void AceitaAlucinogeno (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlAlucinogeno.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlAlucinogeno.SetActive (false);
		}
	}

	void AceitaEcstasy (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlEcstasy.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlEcstasy.SetActive (false);
		}
	}

	void AceitaInalante (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlInalante.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlInalante.SetActive (false);
		}
	}

	void AceitaMaconha (bool aceita)
	{
		if (aceita) {
			dialogo.SetActive (false);
			controlMaconha.SetActive (true);
		} else {
			dialogo.SetActive (true);
			controlMaconha.SetActive (false);
		}
	}

	void DesabilitaControlAnimacoes ()
	{
		AceitaAlcool (false);
		AceitaAlucinogeno (false);
		AceitaCigarro (false);
		AceitaCocaina (false);
		AceitaCrack (false);
		AceitaEcstasy (false);
		AceitaInalante (false);
		AceitaMaconha (false);
	}
}



/* Modificar essa classe para apenas rodar a animação do efeito imediato
 * Todas as consequências deverão ser controladas por classes próprias
 * Aqui apenas chamaremos o método IniciaAnimação das respectivas classes
 * 
 * 
 * 
 * 
 * 
*/