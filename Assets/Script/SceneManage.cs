using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{
    public Button bt;
    public Button bt2;

    private void Start()
    {
        bt.onClick.AddListener(() => SceneManager.LoadScene("State(Состояние)"));
        bt2.onClick.AddListener(() => SceneManager.LoadScene("Singleton"));
    }
}
