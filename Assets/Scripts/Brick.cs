using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Brick : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer s;
    
    [SerializeField]
    private static uint brickAmmount = 0;

    [SerializeField]
    private GameObject powerUP;
    private void Awake()
    {
        s = GetComponent<SpriteRenderer>();
        brickAmmount++;
    }
    public void setColor(int index)
    {
        switch (index)
        {
            case 4: s.color = Color.yellow; break;
            case 3: s.color = Color.green; break;
            case 2: s.color = new Color(1.0f, 0.5f, 0f, 1f); break;
            case 1: s.color = Color.red; break;
            case 0: s.color = new Color(0.5f, 0.0f, 0f, 1f);; break;
            default:
                s.color = new Color(0.5f, 0.0f, 0f, 1f);
            break;
        }
    }
    private void OnDestroy()
    {
        brickAmmount--;
        GameManager.setPoints(100);
    }
    public static void setBrickCounter(uint ammount)
    {
        brickAmmount = ammount;
    }
    public static uint getBrickAmmount()
    {
        return brickAmmount;
    }
    public void spawnPowerUP()
    {
        Instantiate(powerUP, transform.position, Quaternion.identity);
    }
}
