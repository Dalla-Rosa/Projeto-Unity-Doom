using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    private int health;
    public int maxArmor = 50;
    private int armor;
    public int maxAmmo = 100;
    private int ammo;
    void Start()
    {
        health = maxHealth;
        CanvasManager.Instance.updateHealth(health);
        CanvasManager.Instance.updateArmor(armor);
        CanvasManager.Instance.updateAmmo(ammo);

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            damagePlayer(30);
            Debug.Log("Player levou dano");
        }
    }

    public void damagePlayer(int damage)
    {
        if (armor > 0)
        { 
            if(armor >= damage)
            {
                armor -= damage;
            }
            else if(armor < damage)
            {
                int remainingDamage;
                remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }


        }
        else
        {
            health -= damage;
        }

        if(health <=0)
        {
            Debug.Log("Player morreu!");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);


        }

        CanvasManager.Instance.updateHealth(health);
        CanvasManager.Instance.updateArmor(armor);

    }

    public void GiveHealth(int amount, GameObject pickup)
    {

        if(health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }
        

        if(health > maxHealth)
        {
            health = maxHealth;

        }
        CanvasManager.Instance.updateHealth(health);
    }
    public void GiveArmor(int amount, GameObject pickup)
    {

        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;

        }
        CanvasManager.Instance.updateArmor(armor);
    }
}
