// new stuff
using System.Linq;
using System;
using UnityEditor;

// standard
using UnityEngine;
using System.Collections;

public class TrocaSprite : MonoBehaviour
{

	public static TrocaSprite trocaSprite;
 
	// drop all the "skins" you want to be swappable here, these are the multi-sprite textures in your Assets
	public Texture2D[] skins;
   
	// the skin you want to use, you could add a public accessor so this can be changed at runtime.
	public int index = 0;
 
	// Use this for initialization
	void Awake ()
	{
		trocaSprite = this;
		// default loaded sprites
		SpriteRenderer[] loadedRenderers = GetComponentsInChildren <SpriteRenderer> (true);
 
		// sprites we want
		Sprite[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath ("Assets/Sprites/" + skins [index].name + ".png").OfType<Sprite> ().ToArray ();
 
		for (int i = 0; i < sprites.Length; i++) {
			replaceMatchingSprite (loadedRenderers, sprites [i]);
		}
	}

	public void Trocar ()
	{
		
		SpriteRenderer[] loadedRenderers = GetComponentsInChildren <SpriteRenderer> (true);
		// sprites we want
		Sprite[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath ("Assets/Sprites/" + skins [index].name + ".png").OfType<Sprite> ().ToArray ();
		Debug.Log ("Passou pela troca de slides");
		for (int i = 0; i < sprites.Length; i++) {
			replaceMatchingSprite (loadedRenderers, sprites [i]);
		}
	}

	void replaceMatchingSprite (SpriteRenderer[] loaded, Sprite newSprite)
	{
		for (int i = 0; i < loaded.Length; i++) {
            
			if (loaded [i].sprite.rect.x == newSprite.rect.x && loaded [i].sprite.rect.y == newSprite.rect.y) {
				// we found a match, replaced loaded with new, we can have multiple matches
				loaded [i].sprite = newSprite;
			}
		}
	}
}