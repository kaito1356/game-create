using UnityEngine;
using UnityEngine.UI;

public class Buttononclick: MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        //コンポーネントを取得するコード
        Button button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        //ボタンクリックのコード
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // クリックしたら成功と出力する
    void OnClick()
    {
        audioSource.Play();
        Debug.Log("成功");
    }
}
