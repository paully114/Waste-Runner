using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTexture : MonoBehaviour
{
    public Texture[] textures;
    public int currentTexture;

	// Use this for initialization
	void Start ()
    {
       GetComponent<Renderer>().material.mainTexture = textures[ShowNextChar.indexChar];        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
