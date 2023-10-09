using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float health;
    public float velocity;
    public float damage;
    public Sprite sprite;
}