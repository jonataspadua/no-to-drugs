// new stuff
using System.Linq;
using System;

// standard
using UnityEngine;
using System.Collections;

public class TrocaSprite : MonoBehaviour
{
 
	// drop all the "skins" you want to be swappable here, these are the multi-sprite textures in your Assets
	public Texture2D[] skins;
   
	// the skin you want to use, you could add a public accessor so this can be changed at runtime.
	public int index = 0;
	public Light luz;
 
	// Use this for initialization
	void Awake ()
	{
		// default loaded sprites
		SpriteRenderer[] loadedRenderers = GetComponentsInChildren <SpriteRenderer> (true);
 
		// sprites we want
		Sprite sprites = Resources.Load<Sprite>(skins [index].name);
 
		replaceMatchingSprite (loadedRenderers, sprites);
	}

	public void Trocar ()
	{
		
		SpriteRenderer[] loadedRenderers = GetComponentsInChildren <SpriteRenderer> (true);
		// sprites we want
		Sprite sprites = Resources.Load<Sprite>(skins[index].name);

		replaceMatchingSprite (loadedRenderers, sprites);
	}

	void replaceMatchingSprite (SpriteRenderer[] loaded, Sprite newSprite)
	{
		for (int i = 0; i < loaded.Length; i++) {
            
			//if (loaded [i].sprite.rect.x == newSprite.rect.x && loaded [i].sprite.rect.y == newSprite.rect.y) {
				// we found a match, replaced loaded with new, we can have multiple matches
			loaded [i].sprite = newSprite;
			switch(index)
			{
			case 0:
				luz.gameObject.SetActive (false);
				loaded [i].transform.position = new Vector3 ((float) -4.4,(float) 6.1, 21);
				loaded [i].transform.localScale = new Vector3 ((float) 0.7,(float) 0.7,(float) 1);
				break;
			case 1:
				luz.gameObject.SetActive (false);
				loaded [i].transform.position = new Vector3 (-1, 4, 21);
				loaded [i].transform.localScale = new Vector3 ((float) 0.5,(float) 0.5,(float) 1);
				break;
			case 2:
				luz.gameObject.SetActive (true);
				loaded [i].transform.position = new Vector3 ((float)1.4, (float)7.6, (float)21);
				loaded [i].transform.localScale = new Vector3 ((float)2.6, (float)3.9, (float)1);
				break;
			}
			//}
		}
	}
}