using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private float startPanSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    public float minScrollY = 20f;
    public float maxScrollY = 60f;
    
    // Update is called once per frame
    void Update()
    {
        float panSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            panSpeed = startPanSpeed * 3;
        }
        else
        {
            panSpeed = startPanSpeed;
        }
        
        Vector3 tempPosition = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            tempPosition.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            tempPosition.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            tempPosition.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            tempPosition.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        tempPosition.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        
        tempPosition.x = Mathf.Clamp(tempPosition.x, -panLimit.x, panLimit.x);
        tempPosition.y = Mathf.Clamp(tempPosition.y, minScrollY, maxScrollY);
        tempPosition.z = Mathf.Clamp(tempPosition.z, -panLimit.y, panLimit.y);

        transform.position = tempPosition;
    }
}
