using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    public GameObject labCamera;
    public GameObject microscopeCamera;
    public bool startGenerate;
    public Pathmaker Pathmaker;
    public GameObject Pathmakersphere;
    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick()
    {
        startGenerate = true;
        labCamera.SetActive(false);
        microscopeCamera.SetActive(true);
    }
}
