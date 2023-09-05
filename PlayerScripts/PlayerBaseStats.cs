using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseStats", menuName = "Player/BaseStats/New")]
public class PlayerBaseStats : ScriptableObject
{
    [Serializable]
    public class AttributeStats
    {
        public int totalHealth = 100;
        public float totalStamina = 100f;
        public int totalHunger = 100;
        public int totalHydration = 100;
    }
    [Serializable]
    public class AmmoStats
    {
        public int totalPistolAmmo = 50;
        public int totalShotgunAmmo = 40;
        public int totalRifleAmmo = 80;
        public int totalSniperAmmo = 30;
    }
    [Header("Player Base Stats")]
    public AttributeStats attributeStats;
    [Header("Player Base Ammo")]
    public AmmoStats ammoStats;
}
