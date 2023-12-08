using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drone : MonoBehaviour
{
    // �ړ����x
    private float _speed = 5.0f;

    // �㏸�E���~���x
    private float _verticalSpeed = 5.0f;

    // x�������̓��͂�ۑ�
    private float _input_x;

    // z�������̓��͂�ۑ�
    private float _input_z;

    // �㏸�E���~�̓��͂�ۑ�
    private float _input_vertical;

    // �E�E���E�O�i�E��ނ̓��͂�ۑ�
    private float _input_horizontal;

    // �E��ɕ\������UI�e�L�X�g
    public Text coordinatesText;

    void Start()
    {
        // UI�e�L�X�g���ݒ肳��Ă��Ȃ��ꍇ�A�x����\��
        if (coordinatesText == null)
        {
            Debug.LogWarning("Coordinates Text is not set. Please assign a UI Text component to the script.");
        }
    }

    void Update()
    {
        // x�������Az�������A�㏸�E���~�A�E�E���E�O�i�E��ނ̓��͂��擾
        _input_x = Input.GetAxis("Horizontal");
        _input_z = Input.GetAxis("Vertical");
        _input_vertical = 0.0f;
        _input_horizontal = 0.0f;

        // �X�y�[�X�L�[�ŏ㏸
        if (Input.GetKey(KeyCode.Space))
        {
            _input_vertical = 1.0f;
        }
        // �V�t�g�L�[�ŉ��~
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _input_vertical = -1.0f;
        }

        // D�L�[�ŉE������
        if (Input.GetKey(KeyCode.D))
        {
            _input_horizontal = 1.0f;
        }
        // A�L�[�ō�������
        else if (Input.GetKey(KeyCode.A))
        {
            _input_horizontal = -1.0f;
        }

        // �ړ��̌����ȂǍ��W�֘A��Vector3�ň���
        Vector3 velocity = new Vector3(_input_horizontal, _input_vertical, _input_z);

        // �x�N�g���̌������擾
        Vector3 direction = velocity.normalized;

        // �ړ��������v�Z
        float distance = _speed * Time.deltaTime;

        // �ړ�����v�Z
        Vector3 destination = transform.position + direction * distance;

        // �ړ���Ɍ����ĉ�]
        transform.LookAt(destination);

        // �ړ���̍��W��ݒ�
        transform.position = destination;

        // �E��ɍ��W��\��
        if (coordinatesText != null)
        {
            coordinatesText.text = $"X: {transform.position.x:F2}\nY: {transform.position.y:F2}\nZ: {transform.position.z:F2}";
        }
    }
}

