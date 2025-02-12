using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Restart()
{
    SceneManager.LoadScene("Game");//change the neme of scene
}

}