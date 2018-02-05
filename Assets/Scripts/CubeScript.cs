using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour {

    public Text CubeText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void increaseScale()
    {
        transform.localScale *= 2f;
    }

    public void displayGUI(string message)
    {
        CubeText.text = message;
    }
}
