using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int Score;
    bool pausestate;
    [SerializeField]
    UIManager _uimanager;
    void Start()
    {
        //_uimanager = GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<UIManager>();
        Score = 0;
        _uimanager.UpdateScore(Score);
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }
    private void Awake()
    {
        pausestate = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausestate = !pausestate;
            _uimanager.PausePanelControl(pausestate);
            if (pausestate == true)
            {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                resume();
            }
        }
    }
    public void EnemyKilled()
    {
        Score++;
        _uimanager.UpdateScore(Score);
    }
    public void PlayerHealth(int healthLeft)
    {
        if (_uimanager != null)
            _uimanager.UpdateHealth(healthLeft);
        else Debug.Log("UIerror");
        if(healthLeft<=0)
        {
            pausestate = true;
            _uimanager.Gameisover();
        }
    }
    public bool ispaused()
    {
        return pausestate;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void resume()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        pausestate = false;
        _uimanager.PausePanelControl(pausestate);
    }
}
