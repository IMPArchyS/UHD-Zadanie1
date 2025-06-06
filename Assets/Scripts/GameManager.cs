using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject brick;

    [SerializeField]
    private Vector2 screenBounds;

    [SerializeField]
    private OptionsMenu winScreen;

    [SerializeField]
    private static uint points = 0;

    [SerializeField]
    private AudioSource win;
    private bool playOnce = false;
    private void Start()
    {
        winScreen.gameObject.SetActive(false);
        points = 0;
        Time.timeScale = 1;
        Brick.setBrickCounter(0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        float brickWidth = brick.transform.localScale.x;
        float brickHeight = brick.transform.localScale.y;
        Debug.Log(screenBounds);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0;; j++)
            {
                Vector3 position = new Vector3(-screenBounds.x+brickWidth + 2*j*(brickWidth/1.75f),screenBounds.y-i-brickHeight*2.5f, 0f);
                if(brickWidth/1.5f+position.x > screenBounds.x)
                    break;
                Brick b = Instantiate(brick, position, Quaternion.identity).GetComponent<Brick>();
                b.setColor(i);
            }
        }
    }
    private void Update()
    {
        if(Brick.getBrickAmmount() == 0)
        {
            if(!playOnce)
            {
                win.Play();
                playOnce = true;
            }
            
            Time.timeScale = 0;
            winScreen.setScreenText("YOU WON!");
            winScreen.getPoints();
            winScreen.gameObject.SetActive(true);
            winScreen.getBG().sizeDelta = new Vector2(Screen.width*2,Screen.height*2);
        }
    }
    public static void setPoints(uint p)
    {
        points += p;
    }
    public static uint getPoints()
    {
        return points;
    }
}
