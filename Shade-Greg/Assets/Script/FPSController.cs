using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        ParseInput();
	}

    void ParseInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime);
        }      
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-moveSpeed/2 * Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-turnSpeed * Time.deltaTime * Vector3.up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up);
        }
    }
}
