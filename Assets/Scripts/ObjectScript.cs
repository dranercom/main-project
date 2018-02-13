using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour {

    public Text objectText;
    public string objType;
    public Animator anim;
    public AudioClip clip;
    public AudioScript audio_script;
    public AstronautScript astro_script;
    public GameObject gvrObject;
	// Use this for initialization
	void Start () {
        gvrObject = GameObject.Find("GvrObject");
        astro_script = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautScript>();
        objectText = gvrObject.GetComponent<Text>();
        anim = gvrObject.GetComponent<Animator>();
        audio_script = GameObject.Find("Main Camera").GetComponent<AudioScript>();
            //astronaut.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
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
        if(message!="")
            astro_script.gazing = true;
        else
            astro_script.gazing = false;
        objectText.text = message;
        anim.Play("fade in");
        objType = message;
    }

    public void displayInfo()
    {
        switch (objType)
        {
            case "Cube": //display info about cube
                break;
            case "Earth":   audio_script.PlayClip(clip);
                break;

        }
    }

}
