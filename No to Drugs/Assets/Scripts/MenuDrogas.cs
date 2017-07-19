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

	//separação de descrição, efeitos, danos e outros danos de cada droga
	public GameObject descAlcool;
	public GameObject efeitoAlcool;
	public GameObject danoAlcool;
	public GameObject outrosDanosAlcool;

	public GameObject descCigarro;
	public GameObject efeitoCigarro;
	public GameObject danoCigarro;
	public GameObject outrosDanosCigarro;

	public void MostraAlcool ()
	{
		TipoDroga = 0;
		EscondePaineis ();
		InfoAlcool.SetActive (true);
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
		}
	}

	void EscondePaineis ()
	{
		InfoAlcool.SetActive (false);
		InfoCigarro.SetActive (false);
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
	}

	public void Iniciar ()
	{
		if (isActive) {
			menu.SetActive (false);
			isActive = false;
		} else {
			menu.SetActive (true);
			isActive = true;
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
