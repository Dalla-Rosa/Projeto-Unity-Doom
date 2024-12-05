using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        if (!enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Add(enemy);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Remove(enemy);
        }
    }

    public void CleanupDestroyedEnemies()
    {
        enemiesInTrigger.RemoveAll(enemy => enemy == null);
    }
}
