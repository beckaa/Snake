using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("main");
    }
}
