using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power { PLATFORMGROWTH,BIGBALL,BALLSPEED,PLAYERSPEED }
public class PowerUP : MonoBehaviour
{
    [SerializeField]
    private Power p;
    private void Awake()
    {
        int randomInt = Random.Range(0, 4);
        switch (randomInt)
        {
            case 0:
                p = Power.PLATFORMGROWTH;
                break;
            case 1:
                p = Power.BIGBALL;
                break;
            case 2:
                p = Power.BALLSPEED;
                break;
            case 3:
                p = Power.PLAYERSPEED;
                break;
            default:
                break;
        }
    }

    public void applyPowerUP(BallBehaviour b)
    {
        Player platform = FindObjectOfType<Player>();
        switch (p)
        {
            case Power.PLATFORMGROWTH:
                Debug.Log("PLATFORMGROWTH");
                platform.enlarge(0.4f);
                break;

            case Power.BIGBALL:
                b.addRadius(0.2f);
                b.enlarge(0.3f);
                Debug.Log("BIGGER BALL");
                break;

            case Power.BALLSPEED:
                b.addSpeed(0.8f);
                Debug.Log("ADDED BALLSPEED");
                break;

            case Power.PLAYERSPEED:
                platform.addSpeed(0.7f);
                Debug.Log("ADDED BALLSPEED");
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
