using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerWantedLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    [Header("UI Display")]
    [SerializeField] private List<GameObject> parentObjects = new();  
    [SerializeField] private Image[] starImages;
    [SerializeField] private Sprite highlightedStar;
    [SerializeField] private Sprite unhighlightedStar;

    private int stars;
    public int Stars
    {
        get { return stars; }
        private set
        {
            stars = value;
            UpdateStarDisplay();
            UpdateParentObjects();

            if (playerObject)
            {
                playerObject.tag = stars > 0 ? "Aggressive" : "Player";
            }

            OnStarsChanged?.Invoke(stars);
        }
    }
    public int GetCurrentStarCount()
    {
        return Stars;
    }
    [SerializeField] private int maxStars = 5;
    [SerializeField] float timeToDecayStar = 60f;
    private float lastAggressiveActionTime;
    [Header("Events")]
    public UnityEvent<int> OnStarsChanged;
    public UnityEvent OnMaxStarsReached;
    private void Update()
    {
        CheckWantedStatus();
    }
    public void IncreaseWantedLevel(int increment = 1)
    {
        Stars = Mathf.Clamp(Stars + increment, 0, maxStars);
        lastAggressiveActionTime = Time.time;

        if (Stars == maxStars)
        {
            OnMaxStarsReached?.Invoke();
        }
    }
    private void CheckWantedStatus()
    {
        if (Stars > 0 && Time.time - lastAggressiveActionTime > timeToDecayStar)
        {
            DecreaseWantedLevel();
            lastAggressiveActionTime = Time.time;
        }
    }
    private void DecreaseWantedLevel(int decrement = 1)
    {
        Stars = Mathf.Clamp(Stars - decrement, 0, maxStars);
    }
    private void UpdateStarDisplay()
    {
        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < Stars)
            {
                starImages[i].sprite = highlightedStar;
                starImages[i].enabled = true;
            }
            else if (i < maxStars)
            {
                starImages[i].sprite = unhighlightedStar;
                starImages[i].enabled = true;
            }
            else
            {
                starImages[i].enabled = false;
            }
        }
    }
    private void UpdateParentObjects()
    {
        foreach (var parent in parentObjects)
        {
            // If the star count is zero, deactivate the children
            // If the star count is more than zero, activate them
            foreach (Transform child in parent.transform)
            {
                child.gameObject.SetActive(stars > 0);
            }
        }
    }
}
