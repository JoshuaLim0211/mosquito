using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectManager : MonoBehaviour
{
    public string saveSceneNumber;

    public bool isStory = false;

    public static ProjectManager _instance;

    public static ProjectManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ProjectManager)) as ProjectManager;
                
                if(_instance == null)
                {
                    Debug.Log("no Singleton obj");
                }
            }
            return _instance;
        }
    }
    
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
