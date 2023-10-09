using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TorretStats")]
public class TorretStats : ScriptableObject
{
    public float range;
    public float fireRate;
    public float damage;
}