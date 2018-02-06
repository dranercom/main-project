using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour {

    public Text CubeText;
    public string objType;
    public Animator anim;
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
        anim.Play("fade in");
        objType = message;
    }

    public void displayInfo()
    {
        switch (objType)
        {
            case "Cube": //display info about cube
                break;

        }
    }

}
