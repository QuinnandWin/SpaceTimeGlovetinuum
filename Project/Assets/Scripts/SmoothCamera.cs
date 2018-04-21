using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

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
    public bool followX = false;
    public bool followY = false;
    public bool followZ = false;
    public bool playerPositionGrabbed = false;
    private float previousPlayerX;
    private float previousPlayerY;
    private float previousPlayerZ;
    public bool forceXValue = false;
    public float forcedXValue = 0;
    public bool forceYValue = false;
    public float forcedYValue = 0;
    public bool forceZValue = false;
    public float forcedZValue = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {     
        if(followX ==false || followY == false || followZ == false)
        {
            if (playerPositionGrabbed == false)
                GetCurrentPlayerPosition();
        }
        if (followX)
            currentXposition = Mathf.Lerp(transform.position.x, nextXPosition + player.transform.position.x, 0.1f);
        else if (forceXValue == true)
            currentXposition = Mathf.Lerp(transform.position.x, nextXPosition + forcedXValue, 0.1f);
        else if (forceXValue == false)
            currentXposition = Mathf.Lerp(transform.position.x, nextXPosition + previousPlayerX, 0.1f);

        if (followY)
            currentYposition = Mathf.Lerp(transform.position.y, nextYPosition + player.transform.position.y, 0.1f);
        else if (forceYValue == true)
            currentYposition = Mathf.Lerp(transform.position.y, nextYPosition + forcedYValue, 0.1f);
        else if (forceYValue == false)
            currentYposition = Mathf.Lerp(transform.position.y, nextYPosition + previousPlayerY, 0.1f);

        if (followZ)
            currentZposition = Mathf.Lerp(transform.position.z, nextZPosition + player.transform.position.z, 0.1f);
        else if (forceZValue == true)
            currentZposition = Mathf.Lerp(transform.position.z, nextZPosition + forcedZValue, 0.1f);
        else if (forceZValue == false)
            currentZposition = Mathf.Lerp(transform.position.z, nextZPosition + previousPlayerZ, 0.1f);

        transform.position = new Vector3(currentXposition, currentYposition, currentZposition);

        currentXAngle = Mathf.Lerp(transform.eulerAngles.x, nextXAngle, 0.1f);
        currentYAngle = Mathf.Lerp(transform.eulerAngles.y, nextYAngle, 0.1f);
        currentZAngle = Mathf.Lerp(transform.eulerAngles.z, nextZAngle, 0.1f);

        transform.eulerAngles = new Vector3(currentXAngle, currentYAngle, currentZAngle);

    }

    void GetCurrentPlayerPosition()
    {
        previousPlayerX = player.transform.position.x;
        previousPlayerY = player.transform.position.y;
        previousPlayerZ = player.transform.position.z;
        playerPositionGrabbed = true;
    }
}
