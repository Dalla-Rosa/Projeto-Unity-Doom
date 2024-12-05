using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1; // vida cheia
    public Sprite health2;
    public Sprite health3;
    public Sprite health4; // morto

    private static CanvasManager _instance;
    public static CanvasManager Instance
    { 
        get { return _instance; } 
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this; 
        }
    }

    public void updateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);


    }
    public void updateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    

    }
    public void updateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();

    }

    public void UpdateHealthIndicator(int healthValue)
    {

        if (healthValue >= 66)
        {
            healthIndicator.sprite = health1;
        }
        if (healthValue < 66 && healthValue >= 33)
        {
            healthIndicator.sprite = health2;
        }
        if (healthValue < 33 && healthValue > 0)
        {
            healthIndicator.sprite = health3;
        }
        if (healthValue <= 0 )
        { 
            healthIndicator.sprite = health4;
        }

    }




}
