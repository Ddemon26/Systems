using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystemPlayer : MonoBehaviour
{
    private string savePath;
    public PlayerStats playerStats;
    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "playerSave.dat");
    }
    public void SavePlayer()
    {
        PlayerState state = playerStats.CreatePlayerState();
        state.CurrentScene = SceneManager.GetActiveScene().name;  // Save current scene name
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(savePath, FileMode.Create);

        try
        {
            formatter.Serialize(stream, state);
        }
        finally
        {
            stream.Close();
        }

        Debug.Log("Player saved to " + savePath + " on scene " + state.CurrentScene);
    }
    public void LoadPlayer()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            PlayerState state = null;

            try
            {
                state = (PlayerState)formatter.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }

            if (state != null)
            {
                playerStats.ApplyPlayerState(state);
                SceneManager.LoadScene(state.CurrentScene);  // Load saved scene
                Debug.Log("Player loaded from " + savePath + " on scene " + state.CurrentScene);
            }
            else
            {
                Debug.LogError("Failed to load player state");
            }
        }
        else
        {
            Debug.LogError("No save file found at " + savePath);
        }
    }
}
