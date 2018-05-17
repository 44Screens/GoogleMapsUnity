using UnityEngine;

[CreateAssetMenu]
public class StaticMap : ScriptableObject
{
    [Header("Static Map Settings")]
    public Enums.MapType _type;
    [Tooltip("You can use either an adress or satellite coordinates, latitude and longitude separated by a comma")]
    public string _address = null;
    public int _zoom = 14;
    [Tooltip("(optional) affects the number of pixels that are returned")]
    public int _scale = 1;
}