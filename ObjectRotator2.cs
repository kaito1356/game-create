using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator2 : MonoBehaviour
{
    public GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    public float zoomSpeed = 1;
    private Camera mainCamera;
    private Vector2 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                
                var y = (lastMousePosition.x - Input.mousePosition.x);
                var newAngle = Vector3.zero;
                
                newAngle.y = y * rotationSpeed.y;
                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                
                var y = (Input.mousePosition.x - lastMousePosition.x);
                var newAngle = Vector3.zero;
                
                newAngle.y = y * rotationSpeed.y;
                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
