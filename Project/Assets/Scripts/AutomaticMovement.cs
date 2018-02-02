using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour {
    [SerializeField]
    protected float xMovementSpeed = 0.0f;
    [SerializeField]
    protected float zMovementSpeed = 0.0f;

    int i = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        var x = Time.deltaTime * xMovementSpeed;
        var z = Time.deltaTime * zMovementSpeed;

        transform.Rotate(0, 0, 0);
        transform.Translate(x, 0, z);

        if (i > 60)
        {
            xMovementSpeed *= -1.0f;
            i = 0;
        }
        i++;
    }

}
