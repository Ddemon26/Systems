using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    [SerializeField] PlayerBaseStats playerBaseStats;
    [SerializeField] PlayerStatsUI playerStatsUI;
    private readonly int initialCash = 0;
    private int initialHealth;
    private float initialStamina;
    private readonly int initialArmour = 0;
    private int initialHunger;
    private int initialHydration;
    public int CurrentCash;
    public int CurrentHealth;
    public float CurrentStamina;
    public int CurrentArmour;
    public int CurrentHunger;
    public int CurrentHydration;
    public void Awake()
    {
        InitializeAttributes();
    }
    private void InitializeAttributes()
    {
        initialHealth = playerBaseStats.attributeStats.totalHealth;
        initialHunger = playerBaseStats.attributeStats.totalHunger;
        initialHydration = playerBaseStats.attributeStats.totalHydration;
        initialStamina = playerBaseStats.attributeStats.totalStamina;
        CurrentCash = initialCash;
        CurrentHealth = initialHealth;
        CurrentStamina = initialStamina;
        CurrentArmour = initialArmour;
        CurrentHunger = initialHunger;
        CurrentHydration = initialHydration;
    }
    public void AddAmountToAttribute(PlayerStats.PlayerAttribute attribute, int amount)
    {
        switch (attribute)
        {
            case PlayerStats.PlayerAttribute.Cash:
                CurrentCash += amount;
                Debug.Log("Player's cash updated: " + CurrentCash);
                break;
            case PlayerStats.PlayerAttribute.Health:
                CurrentHealth = AddAmount(CurrentHealth, initialHealth, amount);
                Debug.Log("Player's health restored. Current health: " + CurrentHealth);
                break;
            case PlayerStats.PlayerAttribute.Armour:
                CurrentArmour = AddAmount(CurrentArmour, initialArmour, amount);
                Debug.Log("Added armour. Current armour: " + CurrentArmour);
                break;
            case PlayerStats.PlayerAttribute.Hunger:
                CurrentHunger = AddAmount(CurrentHunger, initialHunger, amount);
                Debug.Log("Satisfied hunger. Current hunger: " + CurrentHunger);
                break;
            case PlayerStats.PlayerAttribute.Hydration:
                CurrentHydration = AddAmount(CurrentHydration, initialHydration, amount);
                Debug.Log("Added hydration. Current hydration: " + CurrentHydration);
                break;
        }
                playerStatsUI.UpdateUI(); // Update the UI when attributes are modified
    }
    public void UseStamina(float staminaAmount)
    {
        CurrentStamina = Mathf.Max(0, CurrentStamina - staminaAmount);
        Debug.Log(CurrentStamina <= 0 ? "Out of stamina" : "Using stamina");
        playerStatsUI.UpdateUI(); // Update the UI when stamina is used
    }
    public void RestoreStamina(float staminaAmount)
    {
        CurrentStamina = Mathf.Min(initialStamina, CurrentStamina + staminaAmount);
        Debug.Log("Restoring stamina");
        playerStatsUI.UpdateUI(); // Update the UI when stamina is restored
    }
    public void TakeDamage(int damageAmount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damageAmount);
        Debug.Log(CurrentHealth <= 0 ? "Player has died." : "Taking damage");
        playerStatsUI.UpdateUI(); // Update the UI when damage is taken
    }
    private int AddAmount(int current, int max, int amount)
    {
        return Mathf.Min(current + amount, max);
    }
}
