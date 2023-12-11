using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public int Scene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(Scene);
    }
}
