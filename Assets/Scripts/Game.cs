using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Game : MonoBehaviour
{
    public void restart()
    {
        EditorSceneManager.LoadScene("main");
    }
}
