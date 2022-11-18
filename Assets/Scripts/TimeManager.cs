using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private Text timeText; 

    [SerializeField] public GameObject winPanel,losePanel;

    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        if(gameFinished == false && gameOver == false)
        {
            UpdateTimer();
        }

        

        if(Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false)
        {
            
            gameFinished = true;
            losePanel.gameObject.SetActive(false);
            winPanel.gameObject.SetActive(true);
            
            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");

            foreach (GameObject allobjects in GameObject.FindGameObjectsWithTag("Objects"))
            {
                Destroy(allobjects);
            }
            
            
        }
        if(gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);

            UpdateObjectList("Objects");
            UpdateObjectList("Enemy");


            foreach (GameObject allobjects in GameObject.FindGameObjectsWithTag("Objects"))
            {
                Destroy(allobjects);
            }
        }
    }

    void UpdateObjectList(string tag)
    {

        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));

    }

    private void UpdateTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }
}
