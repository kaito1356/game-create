using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drone : MonoBehaviour
{
    // 移動速度
    private float _speed = 5.0f;

    // 上昇・下降速度
    private float _verticalSpeed = 5.0f;

    // x軸方向の入力を保存
    private float _input_x;

    // z軸方向の入力を保存
    private float _input_z;

    // 上昇・下降の入力を保存
    private float _input_vertical;

    // 右・左・前進・後退の入力を保存
    private float _input_horizontal;

    // 右上に表示するUIテキスト
    public Text coordinatesText;

    void Start()
    {
        // UIテキストが設定されていない場合、警告を表示
        if (coordinatesText == null)
        {
            Debug.LogWarning("Coordinates Text is not set. Please assign a UI Text component to the script.");
        }
    }

    void Update()
    {
        // x軸方向、z軸方向、上昇・下降、右・左・前進・後退の入力を取得
        _input_x = Input.GetAxis("Horizontal");
        _input_z = Input.GetAxis("Vertical");
        _input_vertical = 0.0f;
        _input_horizontal = 0.0f;

        // スペースキーで上昇
        if (Input.GetKey(KeyCode.Space))
        {
            _input_vertical = 1.0f;
        }
        // シフトキーで下降
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _input_vertical = -1.0f;
        }

        // Dキーで右を向く
        if (Input.GetKey(KeyCode.D))
        {
            _input_horizontal = 1.0f;
        }
        // Aキーで左を向く
        else if (Input.GetKey(KeyCode.A))
        {
            _input_horizontal = -1.0f;
        }

        // 移動の向きなど座標関連はVector3で扱う
        Vector3 velocity = new Vector3(_input_horizontal, _input_vertical, _input_z);

        // ベクトルの向きを取得
        Vector3 direction = velocity.normalized;

        // 移動距離を計算
        float distance = _speed * Time.deltaTime;

        // 移動先を計算
        Vector3 destination = transform.position + direction * distance;

        // 移動先に向けて回転
        transform.LookAt(destination);

        // 移動先の座標を設定
        transform.position = destination;

        // 右上に座標を表示
        if (coordinatesText != null)
        {
            coordinatesText.text = $"X: {transform.position.x:F2}\nY: {transform.position.y:F2}\nZ: {transform.position.z:F2}";
        }
    }
}

