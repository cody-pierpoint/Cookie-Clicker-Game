using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerHandlerDummy : MonoBehaviour
{
    public TextMeshProUGUI points;
    public float speed;
    public GameObject pointClicker;
    public int pointCount;
    public GameObject upgradeAutoClick;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void PointAdding()
    {
        pointCount++;

        points.text = "total Points : " + pointCount;
    }

    public void AutoClick()
    {
       // if()

    }
}
