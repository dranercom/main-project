using UnityEngine;

using System.Collections;


public class mspin : MonoBehaviour
{
    public GameObject earth;
    public float speed;
    public float speed1;
    

    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

        //transform.position = new Vector3(earth.transform.position.x + (Mathf.Sin(50 * Mathf.PI/ 180)), earth.transform.position.y, earth.transform.position.z + (Mathf.Cos(50 * Mathf.PI / 180)));
        transform.RotateAround(earth.transform.position ,earth.transform.up, speed1 * Time.deltaTime);
    }
}

