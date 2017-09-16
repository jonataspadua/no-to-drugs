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

	public GameObject controlMaconha;

	public Animator AnimMaconha;
	public AnimationClip animAceitaClipMaconha;
	public AnimationClip animRecusaClipMaconha;

	public Animator AnimConsMaconha;
	public AnimationClip animClipConsMaconha;

	public GameObject controlAlucinogeno;

	public Animator AnimAlucinogeno;
	public AnimationClip animAceitaClipAlucinogeno;
	public AnimationClip animRecusaClipAlucinogeno;

	public Animator AnimConsAlucinogeno;
	public AnimationClip animClipConsAlucinogeno;

	public GameObject controlCocaina;

	public Animator AnimCocaina;
	public AnimationClip animAceitaClipCocaina;
	public AnimationClip animRecusaClipCocaina;

	public Animator AnimConsCocaina;
	public AnimationClip animClipConsCocaina;

	public GameObject controlCrack;

	public Animator AnimCrack;
	public AnimationClip animAceitaClipCrack;
	public AnimationClip animRecusaClipCrack;

	public Animator AnimConsCrack;
	public AnimationClip animClipConsCrack;

	public GameObject controlEcstasy;

	public Animator AnimEcstasy;
	public AnimationClip animAceitaClipEcstasy;
	public AnimationClip animRecusaClipEcstasy;

	public Animator AnimConsEcstasy;
	public AnimationClip animClipConsEcstasy;

	public GameObject controlInalante;

	public Animator AnimInalante;
	public AnimationClip animAceitaClipInalante;
	public AnimationClip animRecusaClipInalante;

	public Animator AnimConsInalante;
	public AnimationClip animClipConsInalante;

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
							Invoke ("CarregaConsAlcool", animClipAceitaAlcool.length);//Prepara a consequencia para aparecer após a animação do alcool
							AnimAlcool.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimAlcool.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaDialogoB", animClipConsAlcool.length + animClipAceitaAlcool.length);//Prepara a função que carrega o dialogo B após as duas animações ocorrem
						} else {
							dialogManager.Alcool = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do alcool e desativa o dialogo
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
							Invoke ("CarregaAnimCigarro", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.Cigarro = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaFase2", animRecusaClipCigarro.length);//Prepara a função que carrega a próxima fase após a animação rodar
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
							Invoke ("CarregaAnimCigarro", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.Cigarro = 0;
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaFase2", animRecusaClipCigarro.length);//Prepara a função que carrega a próxima fase após a animação rodar
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
				case "dialogo_2a"://caso seja a segunda fase e o primeiro dialogo faz as seguintes ações - MACONHA
					{
						if (escolha) {//se aceitou
							dialogManager.olhoVermelhoP = true; //muda os olhos para vermelho 
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaMaconha (true);//habilita o controle da maconha e desativa o dialogo
							Invoke ("CarregaConsMaconha", animAceitaClipMaconha.length);//Prepara a consequencia para aparecer após a animação da maconha
							AnimMaconha.SetBool ("aceita", true);//define que ele aceitou maconha na animação
							AnimMaconha.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaDialogoB", animClipConsMaconha.length + animAceitaClipMaconha.length);//Prepara a função que carrega o dialogo B após as duas animações ocorrem
						} else {
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaMaconha (true);//habilita o controle da maconha e desativa o dialogo
							Invoke ("CarregaDialogoC", animRecusaClipMaconha.length);//Prepara a função que carrega o dialogo C após a animação rodar
							AnimMaconha.SetBool ("aceita", false);//define que ele nao aceitou a maconha na animação
							AnimMaconha.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				case "dialogo_2b"://caso seja a segunda fase e o dialogo seja depois de aceitar a maconha faz as seguintes ações
					{
						switch (dialogManager.Estilo) {//dependendo dos estilos terá acesso a tipos diferentes de drogas
						case 1: //Funk - Inalantes
							{
								if (escolha) {//se ele aceitou inalantes entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaInalante (true);//habilita o controle dos inalantes
									Invoke ("CarregaAnimInalante", animAceitaClipInalante.length);//Prepara a consequencia para aparecer após a animação dos inalantes
									AnimInalante.SetBool ("aceita", true);//define que ele aceitou inalantes na animação
									AnimInalante.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsInalante.length + animAceitaClipInalante.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaInalante (true);//habilita o controle dos inalantes e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipInalante.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimInalante.SetBool ("aceita", false);//define que ele nao aceitou os inalantes na animação
									AnimInalante.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 2: //Rock
							{
								if (escolha) {//se ele aceitou fumar cigarro entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaCocaina (true);//habilita o controle do cigarro
									Invoke ("CarregaAnimCocaina", animAceitaClipCocaina.length);//Prepara a consequencia para aparecer após a animação do cigarro
									AnimCocaina.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimCocaina.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsCocaina.length + animAceitaClipCocaina.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaCocaina (true);//habilita o controle do cigarro e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipCocaina.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimCocaina.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
									AnimCocaina.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 3: //Reggae
							{
								if (escolha) {//se ele aceitou fumar cigarro entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaAlucinogeno (true);//habilita o controle do cigarro
									Invoke ("CarregaAnimAlucinogeno", animAceitaClipAlucinogeno.length);//Prepara a consequencia para aparecer após a animação do cigarro
									AnimAlucinogeno.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsAlucinogeno.length + animAceitaClipAlucinogeno.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaAlucinogeno (true);//habilita o controle do cigarro e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipAlucinogeno.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimAlucinogeno.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
									AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 4: //Eletronica
							{
								if (escolha) {//se ele aceitou fumar cigarro entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaEcstasy (true);//habilita o controle do cigarro
									Invoke ("CarregaAnimEcstasy", animAceitaClipEcstasy.length);//Prepara a consequencia para aparecer após a animação do cigarro
									AnimEcstasy.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsEcstasy.length + animAceitaClipEcstasy.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaEcstasy (true);//habilita o controle do cigarro e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipEcstasy.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimEcstasy.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
									AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						}
						break;
					}
				case "dialogo_2c":
					{
						switch (dialogManager.Estilo) {
						case 1: //Funk
							{
								if (escolha) {//se ele aceitou fumar cigarro entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaInalante (true);//habilita o controle do cigarro
									Invoke ("CarregaAnimInalante", animAceitaClipInalante.length);//Prepara a consequencia para aparecer após a animação do cigarro
									AnimInalante.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimInalante.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsInalante.length + animAceitaClipInalante.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaInalante (true);//habilita o controle do cigarro e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipInalante.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimInalante.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
									AnimInalante.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 2: //Rock
							{
								if (escolha) {//se ele aceitou fumar Cocaina entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaCocaina (true);//habilita o controle do Cocaina
									Invoke ("CarregaAnimCocaina", animAceitaClipCocaina.length);//Prepara a consequencia para aparecer após a animação do Cocaina
									AnimCocaina.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimCocaina.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsCocaina.length + animAceitaClipCocaina.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaCocaina (true);//habilita o controle do Cocaina e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipCocaina.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimCocaina.SetBool ("aceita", false);//define que ele nao aceitou o Cocaina na animação
									AnimCocaina.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 3: //Reggae
							{
								if (escolha) {//se ele aceitou fumar Alucinogeno entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaAlucinogeno (true);//habilita o controle do Alucinogeno
									Invoke ("CarregaAnimAlucinogeno", animAceitaClipAlucinogeno.length);//Prepara a consequencia para aparecer após a animação do Alucinogeno
									AnimAlucinogeno.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsAlucinogeno.length + animAceitaClipAlucinogeno.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaAlucinogeno (true);//habilita o controle do Alucinogeno e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipAlucinogeno.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimAlucinogeno.SetBool ("aceita", false);//define que ele nao aceitou o Alucinogeno na animação
									AnimAlucinogeno.SetBool ("start", true);//define que vai começar a animação
								}
								break;
							}
						case 4: //Eletronica
							{
								if (escolha) {//se ele aceitou fumar Ecstasy entra aqui
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaEcstasy (true);//habilita o controle do Ecstasy
									Invoke ("CarregaAnimEcstasy", animAceitaClipEcstasy.length);//Prepara a consequencia para aparecer após a animação do Ecstasy
									AnimEcstasy.SetBool ("aceita", true);//define que ele aceitou alcool na animação
									AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
									Invoke ("CarregaFase3", animClipConsEcstasy.length + animAceitaClipEcstasy.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
								} else {
									dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
									AceitaEcstasy (true);//habilita o controle do Ecstasy e desativa o dialogo
									Invoke ("CarregaFase3", animRecusaClipEcstasy.length);//Prepara a função que carrega a próxima fase após a animação rodar
									AnimEcstasy.SetBool ("aceita", false);//define que ele nao aceitou o Ecstasy na animação
									AnimEcstasy.SetBool ("start", true);//define que vai começar a animação
								}
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
				/*switch (dialogManager.arqDialogo.name) {
				case "dialogo_3a"://caso seja a primeira fase e o primeiro dialogo faz as seguintes ações - ALCOOL
					{
						if (escolha) {
							dialogManager.olhoVermelhoP = true; //muda os olhos para vermelho
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaAlcool (true);//habilita o controle do alcool e desativa o dialogo
							Invoke ("CarregaConsAlcool", animClipAceitaAlcool.length);//Prepara a consequencia para aparecer após a animação do alcool
							AnimAlcool.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimAlcool.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaDialogoB", animClipConsAlcool.length + animClipAceitaAlcool.length);//Prepara a função que carrega o dialogo B após as duas animações ocorrem
						} else {
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do alcool e desativa o dialogo
							Invoke ("CarregaDialogoC", animClipRecusaAlcool.length);//Prepara a função que carrega o dialogo C após a animação rodar
							AnimAlcool.SetBool ("aceita", false);//define que ele nao aceitou o alcool na animação
							AnimAlcool.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				case "dialogo_3b"://caso seja a primeira fase e o dialogo seja depois de aceitar a bebida faz as seguintes ações - CIGARRO
					{
						if (escolha) {//se ele aceitou fumar cigarro entra aqui
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro
							Invoke ("CarregaAnimCigarro", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaFase2", animRecusaClipCigarro.length);//Prepara a função que carrega a próxima fase após a animação rodar
							AnimCigarro.SetBool ("aceita", false);//define que ele nao aceitou o cigarro na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
						}
						break;
					}
				case "dialogo_3c"://caso seja a primeira fase e o dialogo seja depois de recusar a bebida faz as seguintes ações - CIGARRO
					{
						if (escolha) {//se ele aceitou fumar cigarro entra aqui
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro
							Invoke ("CarregaAnimCigarro", animAceitaClipCigarro.length);//Prepara a consequencia para aparecer após a animação do cigarro
							AnimCigarro.SetBool ("aceita", true);//define que ele aceitou alcool na animação
							AnimCigarro.SetBool ("start", true);//define que vai começar a animação
							Invoke ("CarregaFase2", animClipConsCigarro.length + animAceitaClipCigarro.length);//Prepara a função que carrega a proxima fase após as duas animações ocorrem
						} else {
							dialogManager.choiceBox.SetActive (false);//tira a escolha da tela
							AceitaCigarro (true);//habilita o controle do cigarro e desativa o dialogo
							Invoke ("CarregaFase2", animRecusaClipCigarro.length);//Prepara a função que carrega a próxima fase após a animação rodar
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
				}*/
				break;
			}
		default:
			{
				dialogManager.DisableDialogBox ();
				break;
			}
		}



	}

	void CarregaConsAlcool ()
	{
		AnimConsAlcool.SetBool ("start", true);
		AnimConsAlcool.SetBool ("aceita", true);
	}

	void DescarregaConsAlcool ()
	{
		AnimConsAlcool.SetBool ("start", false);
		AnimConsAlcool.SetBool ("aceita", false);
	}

	void CarregaAnimCigarro ()
	{
		AnimConsCigarro.SetBool ("start", true);
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

	void CarregaFase2 ()
	{
		if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 2;
			CarregaDialogoA ();
		} else if ((dialogManager.Alcool == 1) && (dialogManager.Cigarro == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 2;
			CarregaDialogoA ();
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 2;
			CarregaDialogoA ();
		} else if ((dialogManager.Alcool == 0) && (dialogManager.Cigarro == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 2;
			CarregaDialogoA ();
		}
	}

	void CarregaFase3 ()
	{
		if ((dialogManager.Maconha == 1) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2A
			dialogManager.Fase = 3;
			CarregaDialogoA ();
		} else if ((dialogManager.Maconha == 1) && (dialogManager.Cocaina == 0 || dialogManager.Alucinogeno == 0 || dialogManager.Ecstasy == 0 || dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			CarregaDialogoA ();
		} else if ((dialogManager.Maconha == 0) && (dialogManager.Cocaina == 1 || dialogManager.Alucinogeno == 1 || dialogManager.Ecstasy == 1 || dialogManager.Inalantes == 1)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			CarregaDialogoA ();
		} else if ((dialogManager.Maconha == 0) && (dialogManager.Cocaina == 0 || dialogManager.Alucinogeno == 0 || dialogManager.Ecstasy == 0 || dialogManager.Inalantes == 0)) {//se as duas drogas foram aceitas, carrega a fase 2B
			dialogManager.Fase = 3;
			CarregaDialogoA ();
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
