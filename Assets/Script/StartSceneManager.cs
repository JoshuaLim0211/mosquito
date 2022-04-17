using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    
    public void StartButton()
    {
        //Debug.Log("ddasdasasdasdasd");
        SceneManager.LoadScene("Main");
    }
    public void SettingButton()
    {
        //Debug.Log("ddasdasasdasdasd");
        SceneManager.LoadScene("Setting");
        ProjectManager.Instance.saveSceneNumber = SceneManager.GetActiveScene().name;
        Debug.Log(ProjectManager.Instance.saveSceneNumber);
    }
    
}
