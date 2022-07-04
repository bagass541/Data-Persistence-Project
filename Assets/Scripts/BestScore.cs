using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static BestScore BSInstance;
    public string bestScoreText;
    public string namePlayer;
    public int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
       //bestScoreText = "Best Score : Name : 0";
        if ( BSInstance != null)
        {
            Destroy(gameObject);
        }

        BSInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
