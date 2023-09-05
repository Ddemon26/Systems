using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] PlayerBaseStats playerBaseStats;
    [SerializeField] PlayerStatsUI playerStatsUI;

    private int initialPistolAmmo;
    private int initialShotgunAmmo;
    private int initialRifleAmmo;
    private int initialSniperAmmo;
    public int CurrentPistolAmmo;
    public int CurrentShotgunAmmo;
    public int CurrentRifleAmmo;
    public int CurrentSniperAmmo;

    public void Awake()
    {
        InitializeAmmo();
    }

    private void InitializeAmmo()
    {
        initialPistolAmmo = playerBaseStats.ammoStats.totalPistolAmmo;
        initialShotgunAmmo = playerBaseStats.ammoStats.totalShotgunAmmo;
        initialRifleAmmo = playerBaseStats.ammoStats.totalRifleAmmo;
        initialSniperAmmo = playerBaseStats.ammoStats.totalSniperAmmo;

        CurrentPistolAmmo = initialPistolAmmo;
        CurrentShotgunAmmo = initialShotgunAmmo;
        CurrentRifleAmmo = initialRifleAmmo;
        CurrentSniperAmmo = initialSniperAmmo;
    }
    public void AddAmmo(PlayerStats.AmmoType type, int amount)
    {
        switch (type)
        {
            case PlayerStats.AmmoType.Pistol:
                CurrentPistolAmmo = AddAmount(CurrentPistolAmmo, initialPistolAmmo, amount);
                Debug.Log("Added Pistol Ammo. Total: " + CurrentPistolAmmo);
                break;
            case PlayerStats.AmmoType.Shotgun:
                CurrentShotgunAmmo = AddAmount(CurrentShotgunAmmo, initialShotgunAmmo, amount);
                Debug.Log("Added Shotgun Ammo. Total: " + CurrentShotgunAmmo);
                break;
            case PlayerStats.AmmoType.Rifle:
                CurrentRifleAmmo = AddAmount(CurrentRifleAmmo, initialRifleAmmo, amount);
                Debug.Log("Added Rifle Ammo. Total: " + CurrentRifleAmmo);
                break;
            case PlayerStats.AmmoType.Sniper:
                CurrentSniperAmmo = AddAmount(CurrentSniperAmmo, initialSniperAmmo, amount);
                Debug.Log("Added Sniper Ammo. Total: " + CurrentSniperAmmo);
                break;
        }

        playerStatsUI.UpdateUI(); // Update the UI when ammo is added
    }
    private int AddAmount(int current, int max, int amount)
    {
        return Mathf.Min(current + amount, max);
    }
}
