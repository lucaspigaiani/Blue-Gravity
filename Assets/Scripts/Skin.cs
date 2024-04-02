using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Custom/Skin")]
public class Skin : ScriptableObject
{
    public string label;
    public Sprite[] sprite;
    public int value;
    public Sprite icon;
    public SkinCategory[] category;
}

public enum SkinCategory
{
    Boot_l,
    Boot_r,
    Elbow_l,
    Elbow_r,
    Face,
    Hood,
    Leg_l,
    Leg_r,
    Pelvis,
    Shoulder_l,
    Shoulder_r,
    Torso,
    Wrist_l,
    Wrist_r,
    Other
}