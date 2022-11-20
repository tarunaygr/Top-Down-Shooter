using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
  //  Text Score_text,health_text;
    [SerializeField]
    GameObject PausePanel,GameOverPanel;
    [SerializeField]
    SimpleHealthBar healthBar;
    [SerializeField]
    TMP_Text Score_text;
    void Start()
    {
        //  Score_text = transform.GetComponentsInChildren<Text>()[0];

    }
    // Update is called once per frame
    public void UpdateScore(int score)
    {
        Score_text.text = "Score: " + score;
    }
    public void UpdateHealth(int health)
    {
        healthBar.UpdateBar(health,3);
    }
    public void PausePanelControl(bool pausestate)
    {
        PausePanel.SetActive(pausestate);
    }
    public void Gameisover()
    {
        GameOverPanel.SetActive(true);
    }
}
