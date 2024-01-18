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
        // マウスの水平方向の移動量を取得
        float mouseX = Input.GetAxis("Mouse X");

        // 反転フラグがtrueの場合、方向を反転させる
        if (reverse)
        {
            mouseX *= -1;
        }

        // y軸回転を計算して適用
        Vector3 rotation = new Vector3(0, mouseX * rotationSpeed.y, 0);
        transform.Rotate(rotation);
    }

}


