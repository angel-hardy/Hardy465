using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    
    //public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string SceneName)
    {
        UnitySceneManager.LoadScene(SceneName);
    }

    public string SceneName()
    {
        Scene scene = UnitySceneManager.GetActiveScene();
        return scene.name;
    }
}
