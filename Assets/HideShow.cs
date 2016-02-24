using UnityEngine;
using System.Collections;

public class HideShow : MonoBehaviour {

	// Use this for initialization
	public void Hide () {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = false;
	}
	
	// Update is called once per frame
	public void Show () {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    }
}
