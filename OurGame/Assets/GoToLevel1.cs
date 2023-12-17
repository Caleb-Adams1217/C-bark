using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToLevel1 : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("level 1");
    }
    
}
