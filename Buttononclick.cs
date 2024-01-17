using UnityEngine;
using UnityEngine.UI;

public class Buttononclick: MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        //�R���|�[�l���g���擾����R�[�h
        Button button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        //�{�^���N���b�N�̃R�[�h
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // �N���b�N�����琬���Əo�͂���
    void OnClick()
    {
        audioSource.Play();
        Debug.Log("����");
    }
}
