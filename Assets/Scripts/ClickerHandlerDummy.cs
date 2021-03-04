using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerHandlerDummy : MonoBehaviour
{
    [SerializeField] private int cookie = 0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private int cookiesPerTick = 0;
    [SerializeField] private TextMeshProUGUI points;
    [SerializeField] private TextMeshProUGUI upgradeText;

    //public float speed;
    //public GameObject pointClicker;
    // public int pointCount;
    //public GameObject upgradeAutoClick;
    //public int cost;
    //public bool isUpgraded = false;
    //public int count = 0;
    public Button upgradeClickerButton;
    public Button autoClickerButton;
    public int costToUpgrade = 5;
    //private float autoCookieDelay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
        AutoClick();
        //InvokeRepeating("AutoClick",0, 3);
        StartCoroutine(AutoClick());
        // myButton.interactable = false;
    }
    public void PointAdding()
    {
        cookie += cookiesPerClick;

        UpdateCookieText();


    }

    public void UpgradeUnlocked()
    {
        if (cookie >= costToUpgrade)
        {
            autoClickerButton.interactable = true;

        }
        else
            autoClickerButton.interactable = false;
    }


    IEnumerator AutoClick()
    {
        while (true)
        {
            Debug.Log("autoClick Added");
            yield return new WaitForSeconds(3f);
            cookie += cookiesPerTick;
            UpdateCookieText();
        }
    }

    public void addCookiesPerTick()
    {
        //if()
        autoClickerButton.interactable = true;
        cookiesPerTick++;
    }

    /*public void AutoClick()
    {

       
      
        while (count <= 10)
        {
            count++;
            Debug.Log(count);
            if (count >= 10)
            {
                cookie++;
                UpdateCookieText();
            }
            count++;


        }
        if (count >= 10)
        {
            cookie++;
        }
        else
            count++;
        UpdateCookieText();

    }*/

    public void UpgradeCookiePerClick()
    {
        if (cookie >= costToUpgrade)
        {
            upgradeClickerButton.interactable = true;
            cookie -= costToUpgrade;
            cookiesPerClick++;
            costToUpgrade = costToUpgrade * 2;
            UpdateCookieText();
            UpdateUpgradeText();

        }
        else
            upgradeClickerButton.interactable = false;

    }

    private void UpdateUpgradeText()
    {

        upgradeText.text = "Upgrade " + costToUpgrade;



    }
    private void UpdateCookieText()
    {
        points.text = cookie + "Cookie";
        switch (cookie)
        {
            case 0:
                points.text = "No Cookies";
                break;
            case 1:
                points.text = "One Cookie";
                break;
            default:
                points.text = cookie + " Cookies";
                break;

        }

    }
}
