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
    [SerializeField] private TextMeshProUGUI autoClickUpgradeText;

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
    public int autoclickCostToUpgrade = 25;
    //private float autoCookieDelay = 10f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAutoClickText();
        UpdateCookieText();
        UpdateUpgradeText();
        AutoClick();
        //InvokeRepeating("AutoClick",0, 3);
        StartCoroutine(AutoClick());
        // myButton.interactable = false;
    }
    public void PointAdding()
    {
        //cookie total updated based on cookies per click;
        cookie += cookiesPerClick;

        UpdateCookieText();


    }




    IEnumerator AutoClick()
    {

        while (true)
        {

            Debug.Log("autoClick Added");

            yield return new WaitForSeconds(3f);
            //add cookies based on cookies per tick variable;
            cookie += cookiesPerTick;
            UpdateCookieText();
            UpdateAutoClickText();
        }
    }

    public void addCookiesPerTick()
    {
        //if cookies is greater than or equal to the auto click cost
        if(cookie >= autoclickCostToUpgrade)
        {
            //minus the cost from cookies
            cookie -= autoclickCostToUpgrade;
            //cookies per tickk +1;
            cookiesPerTick++;
            //cost of autoclick upgrade is doubled;
            autoclickCostToUpgrade = autoclickCostToUpgrade * 2;
            UpdateCookieText();
            UpdateAutoClickText();
        }
        //
        autoClickerButton.interactable = true;
        
    }

    public void UpgradeCookiePerClick()
    {
        //if cookies are >= cost of upgrade
        if (cookie >= costToUpgrade)
        {
            //upgrade button is interactable
            upgradeClickerButton.interactable = true;
            //cookies - cost;
            cookie -= costToUpgrade;
            //cookies per click +1
            cookiesPerClick++;
            //upgrade cost doubled
            costToUpgrade = costToUpgrade * 2;
            UpdateCookieText();
            UpdateUpgradeText();

        }
       // else
            //upgradeClickerButton.interactable = false;

    }

    private void UpdateUpgradeText()
    {
        //update text to display upgrade Cost
        upgradeText.text = "Upgrade " + costToUpgrade;



    }

    private void UpdateAutoClickText()
    {
        //update text to display upgrade Cost
        autoClickUpgradeText.text = "Upgrade " + autoclickCostToUpgrade;
             

    }
    private void UpdateCookieText()
    {
        //cookies display shoes cookies + "Cookies"
        points.text = cookie + "Cookie";
        switch (cookie)
        {
            //if 0 cookies display text "No Cookies"
            case 0:
                points.text = "No Cookies";
                break;
                //if 1 cookie Display text "One Cookie"
            case 1:
                points.text = "One Cookie";
                break;
                //if cookies are greater than 0 or 1 display Text Cookies;
            default:
                points.text = cookie + " Cookies";
                break;

        }

    }
}
