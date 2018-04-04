using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupUIController : MonoBehaviour
{
    public Canvas popupUI;
    private float frac = 0.3f;
    private bool UIActive = false;
	private GameObject otherObject;
    private AstronautScript astroscript;

	// Use this for initialization
	void Start ()
    {

        astroscript = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautScript>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
		if (!Input.GetButtonDown("Fire1"))
		{
			return;
		}
        Vector3 originPos = this.transform.position;
        RaycastHit hitInfo;
        Physics.Raycast(originPos, this.transform.forward, out hitInfo);
        if(astroscript.moving)
        {
            popupUI.gameObject.SetActive(false);
            return;
        }
        
        if (hitInfo.collider == null || hitInfo.collider.gameObject.name.Equals("Terrain"))
        {
			if (popupUI.gameObject.activeInHierarchy)
				popupUI.gameObject.SetActive (false);
            return;
        }
        
        /*if (Input.GetButtonDown("Fire1") && (hitInfo.collider == null || hitInfo.collider.gameObject.name.Equals("Terrain")))
        {
            popupUI.gameObject.SetActive(false);
            return;
        }*/

        //Debug.Log(hitInfo.collider.gameObject == button);
        /*if (Input.GetButtonDown("Fire1") && !hitInfo.transform.gameObject.compo)
        {
            popupUI.gameObject.SetActive(false);
            return;
        }*/

        popupUI.gameObject.SetActive(true);
        /*if(Input.GetButtonDown("Fire1"))
        {

            popupUI.gameObject.SetActive(false);
        }*/
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
        //if(!UIActive && hitInfo.collider.gameObject.name=="Cube")
        //{
            Vector3 menuPos = this.transform.position + (this.transform.forward * hitInfo.distance * frac) + (this.transform.right * hitInfo.distance * frac * 0.5f);
            Quaternion menuDir = Quaternion.LookRotation(menuPos - this.transform.position , this.transform.up);
            popupUI.transform.position = menuPos;
            popupUI.transform.rotation = menuDir;
            popupUI.transform.localScale = new Vector3(hitInfo.distance*frac*0.5f, hitInfo.distance * frac*0.5f, 0.01f);
            //Instantiate(popupUI, menuPos, menuDir);
        //}
	}
}
