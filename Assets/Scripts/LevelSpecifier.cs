using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpecifier : MonoBehaviour {

    public string m_SceneName;

    public void GotoScene()
    {
        SceneManager.LoadScene(m_SceneName);
    }
}
