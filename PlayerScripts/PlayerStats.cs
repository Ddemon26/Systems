using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum AmmoType
    {
        Pistol,
        Shotgun,
        Rifle,
        Sniper
    }
    public enum PlayerAttribute
    {
        Cash,
        Health,
        Armour,
        Hunger,
        Hydration
    }
    [Header("Managers")]
    [SerializeField] private AttributeManager attributeManager;
    [SerializeField] private AmmoManager ammoManager;
    [SerializeField] Transform playerPosition;

    private void Start()
    {
        attributeManager.Awake(); // or directly call attributeManager.InitializeAttributes();
        ammoManager.Awake(); // or directly call ammoManager.InitializeAmmo();

    }
    public void UseStamina(float staminaAmount)
    {
        attributeManager.UseStamina(staminaAmount);
    }
    public void RestoreStamina(float staminaAmount)
    {
        attributeManager.RestoreStamina(staminaAmount);
    }
    public void TakeDamage(int damageAmount)
    {
        attributeManager.TakeDamage(damageAmount);
    }
    public void AddAmountToAttribute(PlayerAttribute attribute, int amount)
    {
        attributeManager.AddAmountToAttribute(attribute, amount);
    }
    public void AddAmmo(AmmoType type, int amount)
    {
        ammoManager.AddAmmo(type, amount);
    }
    public PlayerState CreatePlayerState()
    {
        PlayerState state = new PlayerState();
        state.SetPositionVector(playerPosition.position);
        state.health = attributeManager.CurrentHealth;
        state.stamina = attributeManager.CurrentStamina;
        state.armour = attributeManager.CurrentArmour;
        state.hunger = attributeManager.CurrentHunger;
        state.hydration = attributeManager.CurrentHydration;
        state.cash = attributeManager.CurrentCash;
        state.pistolAmmo = ammoManager.CurrentPistolAmmo;
        state.shotgunAmmo = ammoManager.CurrentShotgunAmmo;
        state.rifleAmmo = ammoManager.CurrentRifleAmmo;
        state.sniperAmmo = ammoManager.CurrentSniperAmmo;
        return state;
    }
    public void ApplyPlayerState(PlayerState state)
    {
        playerPosition.position = state.GetPositionVector();
        attributeManager.CurrentHealth = state.health;
        attributeManager.CurrentStamina = state.stamina;
        attributeManager.CurrentArmour = state.armour;
        attributeManager.CurrentHunger = state.hunger;
        attributeManager.CurrentHydration = state.hydration;
        attributeManager.CurrentCash = state.cash;
        ammoManager.CurrentPistolAmmo = state.pistolAmmo;
        ammoManager.CurrentShotgunAmmo = state.shotgunAmmo;
        ammoManager.CurrentRifleAmmo = state.rifleAmmo;
        ammoManager.CurrentSniperAmmo = state.sniperAmmo;
    }
}
