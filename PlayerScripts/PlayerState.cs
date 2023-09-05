using UnityEngine;

[System.Serializable]
public class PlayerState
{
    public string CurrentScene;
    public float[] position = new float[2];
    public int health;
    public float stamina;
    public int armour;
    public int hunger;
    public int hydration;
    public int cash;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int rifleAmmo;
    public int sniperAmmo;

    public static float[] ConvertVector2ToArray(Vector2 vector)
    {
        return new float[] { vector.x, vector.y };
    }
    public static Vector2 ConvertArrayToVector2(float[] array)
    {
        return new Vector2(array[0], array[1]);
    }
    public Vector2 GetPositionVector()
    {
        return ConvertArrayToVector2(position);
    }
    public void SetPositionVector(Vector2 pos)
    {
        position = ConvertVector2ToArray(pos);
    }
}
