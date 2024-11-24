using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();
    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }
    
    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }


}
