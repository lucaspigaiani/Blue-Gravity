using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Custom/Skin")]
public class Skin : ScriptableObject
{
    public string label;
    public Sprite[] sprite;
    public int value;
    public SkinCategory category;
}

public enum SkinCategory
{
    Boot,
    Elbow,
    Face,
    Hood,
    Leg,
    Pelvis,
    Shoulder,
    Torso,
    Wrist,
    Other
}