using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupUIController : MonoBehaviour
{
    public Canvas popupUI;
    private float frac = 0.3f;
    private bool UIActive = false;
	private GameObject otherObject;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 originPos = this.transform.position;
        RaycastHit hitInfo;
        Physics.Raycast(originPos, this.transform.forward, out hitInfo);
		if (hitInfo.collider == null)
			return;
		if (!Input.GetButtonDown ("Fire1"))
			return;
        Vector3 endPos = hitInfo.transform.position;
        Rigidbody selectedBody = hitInfo.rigidbody;
        // Make ui text
        Button[] buttons = popupUI.GetComponentsInChildren<Button>();
        buttons[0].GetComponentInChildren<Text>().text = "DummyButton0";
        //buttons[0].guiText=
        //Debug.Log(hitInfo.collider.gameObject.name);
		ObjectScript os = hitInfo.collider.gameObject.GetComponent<ObjectScript>();
		if(os!=null)
        {
            os.DisplayInfo();
        }
			


        //Canvas menu = popupUI;
        if(!UIActive && hitInfo.collider.gameObject.name=="Cube")
        {
            Vector3 menuPos = this.transform.position + (this.transform.forward * hitInfo.distance * frac) + (this.transform.right * hitInfo.distance * frac * 0.5f);
            Quaternion menuDir = Quaternion.LookRotation(menuPos - this.transform.position , this.transform.up);
            popupUI.transform.position = menuPos;
            popupUI.transform.rotation = menuDir;
            popupUI.transform.localScale = new Vector3(hitInfo.distance*frac*0.5f, hitInfo.distance * frac*0.5f, 0.01f);
            //Instantiate(popupUI, menuPos, menuDir);
        }
	}
}
