using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public EnemyFactory factory;
    public EnemyFactory.EnemyType typeToSpawn;
    public Vector3[] spawnPositions;
    public float interval = 3f;
    private float _timer;
    
    void Start()
    {
        _timer = interval;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Vector3 pos = spawnPositions[Random.Range(0, spawnPositions.Length)];
            var enemy = factory.CreateEnemy(typeToSpawn, pos);

            var bc = enemy.GetComponent<BossController>();
            if (bc != null)
            {
                GameObject introPoint = GameObject.Find("BossIntroPoint");
                bc.introTargetPoint = introPoint.transform;
            }
            _timer = interval;
        }
    }
}
