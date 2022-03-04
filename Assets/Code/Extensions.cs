using UnityEngine;

public static class Extensions
{
    public static Vector3Data AsVector3Data(this Vector3 vector3) =>
        new Vector3Data(vector3.x, vector3.y, vector3.z);

    public static Vector3 AsVector3(this Vector3Data vector3Data) =>
        new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);

    public static Vector3 AddY(this Vector3 vector, float y)
    {
        vector.y += y;
        return vector;
    }

    public static T ToDeserialized<T>(this string json) =>
        JsonUtility.FromJson<T>(json);

    public static string ToJson(this object obj) =>
        JsonUtility.ToJson(obj);
}