using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public float previousXPosition = 0.0f;
    public float previousYPosition = 0.0f;
    public float previousZPosition = 0.0f;
    public float nextXPosition = 0.0f;
    public float nextYPosition = 0.0f;
    public float nextZPosition = 0.0f;
    public float realX = 0.0f;
    public float realY = 0.0f;
    public float realZ = 0.0f;
    [SerializeField]
    private GameObject player;
    private float currentXposition;
    private float currentYposition;
    private float currentZposition;
    public float nextXAngle = 0.0f;
    public float nextYAngle = 0.0f;
    public float nextZAngle = 0.0f;
    private float currentXAngle;
    private float currentYAngle;
    private float currentZAngle;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {     

        previousXPosition = transform.position.x;
        previousYPosition = transform.position.y;
        previousZPosition = transform.position.z;
        currentXposition = Mathf.Lerp(previousXPosition, nextXPosition + player.transform.position.x, 0.1f);
        currentYposition = Mathf.Lerp(previousYPosition, nextYPosition + player.transform.position.y, 0.1f);
        currentZposition = Mathf.Lerp(previousZPosition, nextZPosition + player.transform.position.z, 0.1f);

        transform.position = new Vector3(currentXposition, currentYposition, currentZposition);

        currentXAngle = Mathf.Lerp(transform.eulerAngles.x, nextXAngle, 0.1f);
        currentYAngle = Mathf.Lerp(transform.eulerAngles.y, nextYAngle, 0.1f);
        currentZAngle = Mathf.Lerp(transform.eulerAngles.z, nextZAngle, 0.1f);

        transform.eulerAngles = new Vector3(currentXAngle, currentYAngle, currentZAngle);

    }
}
