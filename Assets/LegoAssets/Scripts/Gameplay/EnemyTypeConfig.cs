using UnityEngine;

[CreateAssetMenu(menuName = "Config/EnemyType")]
public class EnemyTypeConfig : ScriptableObject
{
    public EnemyFactory.EnemyType type;
    public GameObject prefab;
    public float speed = 3.5f;
}
