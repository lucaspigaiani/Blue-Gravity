using UnityEngine;

// This attribute allows creating instances of Skin scriptable objects from the Unity editor
[CreateAssetMenu(fileName = "New Skin", menuName = "Custom/Skin")]
public class Skin : ScriptableObject
{
    public string label; // Name or label of the skin
    public Sprite[] sprite; // Array of sprites representing the skin's appearance
    public int value; // Value or price of the skin
    public Sprite icon; // Icon representing the skin
    public SkinCategory[] category; // Array of skin categories
}

// Enum defining different categories of skins
public enum SkinCategory
{
    Boot_l,     // Left boot
    Boot_r,     // Right boot
    Elbow_l,    // Left elbow
    Elbow_r,    // Right elbow
    Face,       // Face
    Hood,       // Hood
    Leg_l,      // Left leg
    Leg_r,      // Right leg
    Pelvis,     // Pelvis
    Shoulder_l, // Left shoulder
    Shoulder_r, // Right shoulder
    Torso,      // Torso
    Wrist_l,    // Left wrist
    Wrist_r,    // Right wrist
    Other       // Other category
}