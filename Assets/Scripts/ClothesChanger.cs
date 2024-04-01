using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ClothesChanger : MonoBehaviour
{
    public SpriteResolver boot_l;
    public SpriteResolver boot_r;
    public SpriteResolver elbow_l;
    public SpriteResolver elbow_r;
    public SpriteResolver face;
    public SpriteResolver hood;
    public SpriteResolver leg_l;
    public SpriteResolver leg_r;
    public SpriteResolver pelvis;
    public SpriteResolver shoulder_l;
    public SpriteResolver shoulder_r;
    public SpriteResolver torso;
    public SpriteResolver wrist_l;
    public SpriteResolver wrist_r;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SkinChanger(Skin skin)
    {
        Debug.Log("Skin Changer");
        foreach (SkinCategory category in skin.category)
        {
            switch (category)
            {
                case SkinCategory.Boot_l:
                    boot_l.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Boot_r:
                    boot_r.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Elbow_l:
                    elbow_l.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Elbow_r:
                    elbow_r.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Face:
                    face.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Hood:
                    hood.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Leg_l:
                    leg_l.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Leg_r:
                    leg_r.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Pelvis:
                    pelvis.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Shoulder_l:
                    shoulder_l.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Shoulder_r:
                    shoulder_r.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Torso:
                    torso.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Wrist_l:
                    wrist_l.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Wrist_r:
                    wrist_r.SetCategoryAndLabel(category.ToString(), skin.label);
                    break;
                case SkinCategory.Other:
                    break;
                default:
                    break;
            }
        }

        

    }
}
