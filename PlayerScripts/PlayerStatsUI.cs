using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class PlayerStatsUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] AttributeManager attributeManager;
    [SerializeField] AmmoManager ammoManager;
    [Serializable]
    public class AttributeUIReferences
    {
        public TextMeshProUGUI healthText;
        public Slider healthSlider;
        public Slider staminaSlider;
        public TextMeshProUGUI armourText;
        public TextMeshProUGUI hungerText;
        public Slider hungerSlider;
        public TextMeshProUGUI hydrationText;
        public Slider hydrationSlider;
        public TextMeshProUGUI cashText;
    }
    [Serializable]
    public class AmmoUIReferences
    {
        public TextMeshProUGUI pistolAmmoText;
        public TextMeshProUGUI shotgunAmmoText;
        public TextMeshProUGUI rifleAmmoText;
        public TextMeshProUGUI sniperAmmoText;
    }
    public AttributeUIReferences attributeUIReferences;
    public AmmoUIReferences ammoUIReferences;
    void Update()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        int currentHealth = attributeManager.CurrentHealth;
        attributeUIReferences.healthText.text = currentHealth + ":";
        attributeUIReferences.healthSlider.value = currentHealth;
        int currentHydration = attributeManager.CurrentHydration;
        attributeUIReferences.hydrationText.text = currentHydration + ":";
        attributeUIReferences.hydrationSlider.value = currentHydration;
        int currentHunger = attributeManager.CurrentHunger;
        attributeUIReferences.hungerText.text = currentHunger + ":";
        attributeUIReferences.hungerSlider.value = currentHunger;
        float currentStamina = attributeManager.CurrentStamina;
        attributeUIReferences.staminaSlider.value = currentStamina;
        attributeUIReferences.armourText.text = attributeManager.CurrentArmour + ":";
        attributeUIReferences.cashText.text = attributeManager.CurrentCash + ":";

        ammoUIReferences.pistolAmmoText.text = ammoManager.CurrentPistolAmmo + ":";
        ammoUIReferences.shotgunAmmoText.text = ammoManager.CurrentShotgunAmmo + ":";
        ammoUIReferences.rifleAmmoText.text = ammoManager.CurrentRifleAmmo + ":";
        ammoUIReferences.sniperAmmoText.text = ammoManager.CurrentSniperAmmo + ":";
    }
}
