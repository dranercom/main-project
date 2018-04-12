using UnityEngine;

using System.Collections;

public class spin : MonoBehaviour
{

    public float speed;
    public GameObject Sun;
    public float speed2;


    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        if (Sun == null)
            return;
        transform.RotateAround(Sun.transform.position, Sun.transform.up, speed2 * Time.deltaTime);
    }
}
