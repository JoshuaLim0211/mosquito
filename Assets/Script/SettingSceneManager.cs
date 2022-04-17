using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneManager : MonoBehaviour
{
    
    public void BackButton()
    {
        SceneManager.LoadScene(ProjectManager.Instance.saveSceneNumber);
    }
}
