using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectScript : MonoBehaviour 
{

    public Text objectText;
    public string objType;
    public Animator anim;
    public AudioClip clip;
    public AudioScript audio_script;
    public AstronautScript astro_script;
    public GameObject gvrObject;
	// Use this for initialization
	void Start () {
        //Canvas element that displays the object type
        gvrObject = GameObject.Find("GvrObject");
        objectText = gvrObject.GetComponent<Text>();
        anim = gvrObject.GetComponent<Animator>();

        //Movement script for the VR head
        astro_script = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautScript>();
        audio_script = GameObject.Find("Main Camera").GetComponent<AudioScript>();
		objType = gameObject.name;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gvrObject == null)
            Start();
	}

    public void Gazing()
    {
        astro_script.gazing = true;
        objectText.text = objType;
        anim.Play("fade in");
    }

    public void NotGazing()
    {
        astro_script.gazing = false;
        objectText.text = "";
    }

    public void DisplayInfo()
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
