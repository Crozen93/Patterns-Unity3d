using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonStorage : MonoBehaviour
{
    public static SingletonStorage instance { get; private set; }

    public FileManager FileManager { get; private set; }
    public AchievementsManager AchievementsManager { get; private set; }

    private void Awake()
    {
        CheckInstance();
      //  InitManagers();
      
    }

    private void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitManagers()
    {
       FileManager = gameObject?.GetComponent<FileManager>();
       AchievementsManager = gameObject?.GetComponent<AchievementsManager>();
    }

}
