using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    public static MenuManager Instance;  
    private MenuUIHandler menuUiScript;
    public TMP_InputField name;  
    public string nameText;
    public TextMeshProUGUI BestScore;
    public int highestPointInSession = 0;
    public int highestPoints = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        menuUiScript = GameObject.Find("Canvas").GetComponent<MenuUIHandler>();
        
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    private void Update()
    {
        if (!menuUiScript.started)
        {
            Instance.nameText = name.text;
        }      
    }

    class SaveData
    {
        public string HighestScore;
    }

    public void SaveScore(string bestScoretextInSession, int highestPointsInSession)
    {
        SaveData data = new SaveData();
        // Смотрит побили ли за сессию общий рекорд
        if (highestPoints < highestPointsInSession)
        {
            data.HighestScore = bestScoretextInSession;
            highestPoints = highestPointsInSession;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
      
    }


    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore.text = data.HighestScore;
        }
    }   
}
