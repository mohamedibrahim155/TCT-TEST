using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  static int nextLevel;
    public bool escapeToggle;
    public GameObject gamePause;
    public GameObject clip;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeToggle = !escapeToggle;
            if (escapeToggle)
            {
                Paused();
            }
            gamePause.SetActive(escapeToggle);
        }
        
    }

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);                                                  
    }
    public void Resume()
    {
        gamePause.SetActive(false);
        Time.timeScale = 1f;
       // GameIsPaused = false;

    }
    void Paused()
    {
        gamePause.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }

}
