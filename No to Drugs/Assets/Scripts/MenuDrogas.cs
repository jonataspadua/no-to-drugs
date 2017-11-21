using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		TipoDroga = 0;
		EscondePaineis ();
		InfoAlcool.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCigarro ()
	{
		TipoDroga = 1;
		EscondePaineis ();
		InfoCigarro.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraMaconha ()
	{
		TipoDroga = 2;
		EscondePaineis ();
		InfoMaconha.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCocaina ()
	{
		TipoDroga = 3;
		EscondePaineis ();
		InfoCocaina.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraInalante ()
	{
		TipoDroga = 4;
		EscondePaineis ();
		InfoInalante.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraEcstasy ()
	{
		TipoDroga = 5;
		EscondePaineis ();
		InfoEcstasy.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraAlucinogeno ()
	{
		TipoDroga = 6;
		EscondePaineis ();
		InfoAlucinogeno.SetActive (true);
		MostraDescricao ();			
	}

	public void MostraCrack ()
	{
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
				EscondeInfos ();
				descAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				EscondeInfos ();
				descCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				EscondeInfos ();
				descMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				EscondeInfos ();
				descCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				EscondeInfos ();
				descInalante.SetActive (true);
				break;
			}
		case 5:
			{
				EscondeInfos ();
				descEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				EscondeInfos ();
				descAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
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
				EscondeInfos ();
				efeitoAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				EscondeInfos ();
				efeitoCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				EscondeInfos ();
				efeitoMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				EscondeInfos ();
				efeitoCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				EscondeInfos ();
				efeitoInalante.SetActive (true);
				break;
			}
		case 5:
			{
				EscondeInfos ();
				efeitoEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				EscondeInfos ();
				efeitoAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
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
				EscondeInfos ();
				danoAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				EscondeInfos ();
				danoCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				EscondeInfos ();
				danoMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				EscondeInfos ();
				danoCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				EscondeInfos ();
				danoInalante.SetActive (true);
				break;
			}
		case 5:
			{
				EscondeInfos ();
				danoEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				EscondeInfos ();
				danoAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
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
				EscondeInfos ();
				outrosDanosAlcool.SetActive (true);
				break;
			}
		case 1:
			{
				EscondeInfos ();
				outrosDanosCigarro.SetActive (true);
				break;
			}
		case 2:
			{
				EscondeInfos ();
				outrosDanosMaconha.SetActive (true);
				break;
			}
		case 3:
			{
				EscondeInfos ();
				outrosDanosCocaina.SetActive (true);
				break;
			}
		case 4:
			{
				EscondeInfos ();
				outrosDanosInalante.SetActive (true);
				break;
			}
		case 5:
			{
				EscondeInfos ();
				outrosDanosEcstasy.SetActive (true);
				break;
			}
		case 6:
			{
				EscondeInfos ();
				outrosDanosAlucinogeno.SetActive (true);
				break;
			}
		case 7:
			{
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
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menu.SetActive (false);
		}
	}
}
