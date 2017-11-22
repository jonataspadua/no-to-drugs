using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MenuDrogas : MonoBehaviour
{
	public static MenuDrogas menuDrogas;
	private bool isActive;
	//variavel para controlar o tipo de droga
	[HideInInspector] public int TipoDroga;

	public GameObject menu;

	//seção para colocar os objetos de cada droga
	public GameObject InfoAlcool;
	public GameObject InfoCigarro;
	public GameObject InfoMaconha;
	public GameObject InfoCocaina;
	public GameObject InfoInalante;
	public GameObject InfoEcstasy;
	public GameObject InfoAlucinogeno;
	public GameObject InfoCrack;

	//separação de descrição, efeitos, danos e outros danos de cada droga
	public GameObject descAlcool;
	public GameObject efeitoAlcool;
	public GameObject danoAlcool;
	public GameObject outrosDanosAlcool;

	public GameObject descCigarro;
	public GameObject efeitoCigarro;
	public GameObject danoCigarro;
	public GameObject outrosDanosCigarro;

	public GameObject descMaconha;
	public GameObject efeitoMaconha;
	public GameObject danoMaconha;
	public GameObject outrosDanosMaconha;

	public GameObject descCocaina;
	public GameObject efeitoCocaina;
	public GameObject danoCocaina;
	public GameObject outrosDanosCocaina;

	public GameObject descInalante;
	public GameObject efeitoInalante;
	public GameObject danoInalante;
	public GameObject outrosDanosInalante;

	public GameObject descEcstasy;
	public GameObject efeitoEcstasy;
	public GameObject danoEcstasy;
	public GameObject outrosDanosEcstasy;

	public GameObject descAlucinogeno;
	public GameObject efeitoAlucinogeno;
	public GameObject danoAlucinogeno;
	public GameObject outrosDanosAlucinogeno;

	public GameObject descCrack;
	public GameObject efeitoCrack;
	public GameObject danoCrack;
	public GameObject outrosDanosCrack;

	public void MostraAlcool ()
	{
		Analytics.CustomEvent ("VisualizouAlcool");
		TipoDroga = 0;
		EscondePaineis ();
		InfoAlcool.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCigarro ()
	{
		Analytics.CustomEvent ("VisualizouCigarro");
		TipoDroga = 1;
		EscondePaineis ();
		InfoCigarro.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraMaconha ()
	{
		Analytics.CustomEvent ("VisualizouMaconha");
		TipoDroga = 2;
		EscondePaineis ();
		InfoMaconha.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCocaina ()
	{
		Analytics.CustomEvent ("VisualizouCocaina");
		TipoDroga = 3;
		EscondePaineis ();
		InfoCocaina.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraInalante ()
	{
		Analytics.CustomEvent ("VisualizouInalante");
		TipoDroga = 4;
		EscondePaineis ();
		InfoInalante.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraEcstasy ()
	{
		Analytics.CustomEvent ("VisualizouEcstasy");
		TipoDroga = 5;
		EscondePaineis ();
		InfoEcstasy.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraAlucinogeno ()
	{
		Analytics.CustomEvent ("VisualizouAlucinogeno");
		TipoDroga = 6;
		EscondePaineis ();
		InfoAlucinogeno.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCrack ()
	{
		Analytics.CustomEvent ("VisualizouCrack");
		TipoDroga = 7;
		EscondePaineis ();
		InfoCrack.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraDescricao ()
	{
		switch (TipoDroga) {
		case 0:
			{
				Analytics.CustomEvent ("MostraDescricao_Alcool");
				EscondeInfos ();
				descAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				Analytics.CustomEvent ("MostraDescricao_Cigarro");
				EscondeInfos ();
				descCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				Analytics.CustomEvent ("MostraDescricao_Maconha");
				EscondeInfos ();
				descMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				Analytics.CustomEvent ("MostraDescricao_Cocaina");
				EscondeInfos ();
				descCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				Analytics.CustomEvent ("MostraDescricao_Inalante");
				EscondeInfos ();
				descInalante.SetActive (true);
				break;
			}
		case 5:
			{
				Analytics.CustomEvent ("MostraDescricao_Ecstasy");
				EscondeInfos ();
				descEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				Analytics.CustomEvent ("MostraDescricao_Alucinogeno");
				EscondeInfos ();
				descAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
				Analytics.CustomEvent ("MostraDescricao_Crack");
				EscondeInfos ();
				descCrack.SetActive (true);
				break;
			}
		default:
			break;
		}

	}

	public void MostraEfeitos ()
	{
		switch (TipoDroga) {
		case 0:
			{
				Analytics.CustomEvent ("MostraEfeitos_Alcool");
				EscondeInfos ();
				efeitoAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				Analytics.CustomEvent ("MostraEfeitos_Cigarro");
				EscondeInfos ();
				efeitoCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				Analytics.CustomEvent ("MostraEfeitos_Maconha");
				EscondeInfos ();
				efeitoMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				Analytics.CustomEvent ("MostraEfeitos_Cocaina");
				EscondeInfos ();
				efeitoCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				Analytics.CustomEvent ("MostraEfeitos_Inalante");
				EscondeInfos ();
				efeitoInalante.SetActive (true);
				break;
			}
		case 5:
			{
				Analytics.CustomEvent ("MostraEfeitos_Ecstasy");
				EscondeInfos ();
				efeitoEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				Analytics.CustomEvent ("MostraEfeitos_Alucinogeno");
				EscondeInfos ();
				efeitoAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
				Analytics.CustomEvent ("MostraEfeitos_Crack");
				EscondeInfos ();
				efeitoCrack.SetActive (true);
				break;
			}
		default:
			break;
		}
	}

	public void MostraDanos ()
	{
		switch (TipoDroga) {
		case 0:
			{
				Analytics.CustomEvent ("MostraDanos_Alcool");
				EscondeInfos ();
				danoAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				Analytics.CustomEvent ("MostraDanos_Cigarro");
				EscondeInfos ();
				danoCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				Analytics.CustomEvent ("MostraDanos_Maconha");
				EscondeInfos ();
				danoMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				Analytics.CustomEvent ("MostraDanos_Cocaina");
				EscondeInfos ();
				danoCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				Analytics.CustomEvent ("MostraDanos_Inalante");
				EscondeInfos ();
				danoInalante.SetActive (true);
				break;
			}
		case 5:
			{
				Analytics.CustomEvent ("MostraDanos_Ecstasy");
				EscondeInfos ();
				danoEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				Analytics.CustomEvent ("MostraDanos_Alucinogeno");
				EscondeInfos ();
				danoAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
				Analytics.CustomEvent ("MostraDanos_Crack");
				EscondeInfos ();
				danoCrack.SetActive (true);
				break;
			}
		default:
			break;
		}
	}

	public void MostraOutrosDanos ()
	{
		switch (TipoDroga) {
		case 0:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Alcool");
				EscondeInfos ();
				outrosDanosAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Cigarro");
				EscondeInfos ();
				outrosDanosCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Maconha");
				EscondeInfos ();
				outrosDanosMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Cocaina");
				EscondeInfos ();
				outrosDanosCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Inalante");
				EscondeInfos ();
				outrosDanosInalante.SetActive (true);
				break;
			}
		case 5:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Ecstasy");
				EscondeInfos ();
				outrosDanosEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Alucinogeno");
				EscondeInfos ();
				outrosDanosAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
				Analytics.CustomEvent ("MostraOutrosDanos_Crack");
				EscondeInfos ();
				outrosDanosCrack.SetActive (true);
				break;
			}
		default:
			break;
		}
	}

	void EscondePaineis ()
	{
		InfoAlcool.SetActive (false);
		InfoCigarro.SetActive (false);
		InfoMaconha.SetActive (false);
		InfoCocaina.SetActive (false);
		InfoInalante.SetActive (false);
		InfoEcstasy.SetActive (false);
		InfoAlucinogeno.SetActive (false);
		InfoCrack.SetActive (false);
	}

	void EscondeInfos ()
	{
		descAlcool.SetActive (false);
		efeitoAlcool.SetActive (false);
		danoAlcool.SetActive (false);
		outrosDanosAlcool.SetActive (false);

		descCigarro.SetActive (false);
		efeitoCigarro.SetActive (false);
		danoCigarro.SetActive (false);
		outrosDanosCigarro.SetActive (false);

		descMaconha.SetActive (false);
		efeitoMaconha.SetActive (false);
		danoMaconha.SetActive (false);
		outrosDanosMaconha.SetActive (false);

		descCocaina.SetActive (false);
		efeitoCocaina.SetActive (false);
		danoCocaina.SetActive (false);
		outrosDanosCocaina.SetActive (false);

		descInalante.SetActive (false);
		efeitoInalante.SetActive (false);
		danoInalante.SetActive (false);
		outrosDanosInalante.SetActive (false);

		descEcstasy.SetActive (false);
		efeitoEcstasy.SetActive (false);
		danoEcstasy.SetActive (false);
		outrosDanosEcstasy.SetActive (false);

		descAlucinogeno.SetActive (false);
		efeitoAlucinogeno.SetActive (false);
		danoAlucinogeno.SetActive (false);
		outrosDanosAlucinogeno.SetActive (false);

		descCrack.SetActive (false);
		efeitoCrack.SetActive (false);
		danoCrack.SetActive (false);
		outrosDanosCrack.SetActive (false);
	}

	public void Iniciar ()
	{
		if (isActive) {
			Time.timeScale = 1;
			isActive = false;
			menu.SetActive (false);
		} else {
			Analytics.CustomEvent ("VisualizouMenuDrogas");
			isActive = true;
			Time.timeScale = 0;
			menu.SetActive (true);
		}
	}

	// Use this for initialization
	void Start ()
	{
		menuDrogas = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Cancel")) {
			menu.SetActive (false);
		}
	}
}
