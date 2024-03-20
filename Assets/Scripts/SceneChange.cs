using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LevelSelector()
    {
        SceneManager.LoadScene(1);
    }

    public void Info()
    {
        SceneManager.LoadScene(2);
    }

    public void IntroScene()
    {
        SceneManager.LoadScene(3);
    }

    public void Level1()
    {
        SceneManager.LoadScene(4);
    }

    public void Level2()
    {
        SceneManager.LoadScene(5);
    }
    
    public void Credits()
    {
        SceneManager.LoadScene(6);
    }

    public void Level3()
    {
        SceneManager.LoadScene(8);
    }

    public void BeatLevel1()
    {
        SceneManager.LoadScene(9);
    }

    public void BeatLevel2()
    {
        SceneManager.LoadScene(10);
    }

    public void BeatLevel3()
    {
        SceneManager.LoadScene(11);
    }



    public void QuitGame()
    {
        Application.Quit();
    }







}
