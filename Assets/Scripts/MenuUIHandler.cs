using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public MenuManager menuManager;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        if (menuManager.nameText != "" && !started)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Имя не введено");
        }
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
