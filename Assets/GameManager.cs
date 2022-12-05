using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instanse;
    public static GameManager Instanse
    {
        get
        {
            if(_instanse == null)
            {
                _instanse = FindObjectOfType<GameManager>();
            }
            return _instanse;
        }
    }
    
    private int score;

    [SerializeField]
    private GameObject poop;
    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private GameObject panel;

    void Start()
    {
        
    }

    public void GameStart()
    {
        stopTrigger = true;
        StartCoroutine(CreatepoopRoutine());
        panel.SetActive(false);
    }

    private bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;      
        StopCoroutine(CreatepoopRoutine());

        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SestInt("BestScore", score);

        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void Score()
    {
        score++;
        scoreTxt.text = "Score : " + score;
    }

    IEnumerator CreatepoopRoutine()
    {
        while(true)
        {
            CreatePoop();
            yield return new WaitForSeconds(1);
        }
    }
    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f),1.1f, 0));
        pos.z = 0.0f;
        Instantiate(poop,pos,Quaternion.identity);
    }
}
