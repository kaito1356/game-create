using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
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
        // �}�E�X�̐��������̈ړ��ʂ��擾
        float mouseX = Input.GetAxis("Mouse X");

        // ���]�t���O��true�̏ꍇ�A�����𔽓]������
        if (reverse)
        {
            mouseX *= -1;
        }

        // y����]���v�Z���ēK�p
        Vector3 rotation = new Vector3(0, mouseX * rotationSpeed.y, 0);
        transform.Rotate(rotation);
    }

}


