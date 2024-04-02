using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ClothesChanger : MonoBehaviour
{
    public UnityEngine.U2D.Animation.SpriteResolver boot_l;
    public UnityEngine.U2D.Animation.SpriteResolver boot_r;
    public UnityEngine.U2D.Animation.SpriteResolver elbow_l;
    public UnityEngine.U2D.Animation.SpriteResolver elbow_r;
    public UnityEngine.U2D.Animation.SpriteResolver face;
    public UnityEngine.U2D.Animation.SpriteResolver hood;
    public UnityEngine.U2D.Animation.SpriteResolver leg_l;
    public UnityEngine.U2D.Animation.SpriteResolver leg_r;
    public UnityEngine.U2D.Animation.SpriteResolver pelvis;
    public UnityEngine.U2D.Animation.SpriteResolver shoulder_l;
    public UnityEngine.U2D.Animation.SpriteResolver shoulder_r;
    public UnityEngine.U2D.Animation.SpriteResolver torso;
    public UnityEngine.U2D.Animation.SpriteResolver wrist_l;
    public UnityEngine.U2D.Animation.SpriteResolver wrist_r;

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
