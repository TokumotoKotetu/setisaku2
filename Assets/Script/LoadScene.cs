using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
