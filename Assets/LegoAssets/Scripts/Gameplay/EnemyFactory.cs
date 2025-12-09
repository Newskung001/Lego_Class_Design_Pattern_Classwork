using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFactory : MonoBehaviour
{
    public enum EnemyType
    {
        Lazy, Runner, Boss
    }
    
    public List<EnemyTypeConfig> enemyConfigs;

    private Dictionary<EnemyType, EnemyTypeConfig> configLookup;

    void Awake()
    {
        configLookup = new Dictionary<EnemyType, EnemyTypeConfig>();
        foreach (var cfg in enemyConfigs)
        {
            //e.g. key = EnemyType.Boss, value = BossEnemyConfig()
            configLookup[cfg.type] = cfg;
        }
    }

    public GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        if (!configLookup.TryGetValue(type, out var cfg))
        {
            Debug.LogError($"No config for type {type}");
            return null;
        }
        GameObject enemy = Instantiate(cfg.prefab, position, Quaternion.identity);
        enemy.name = $"{cfg.prefab.name}_{type}";
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = cfg.speed;
        }
        return enemy;
    }
}
