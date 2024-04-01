using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ClothesChanger : MonoBehaviour
{
    public SpriteLibraryAsset skin;
    public SpriteResolver torso;
    public SpriteResolver hood;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSkin()
    {

    }

    public void TorsoSkinChanger(string label) 
    {
        torso.SetCategoryAndLabel("Rogue_torso", label);
    }

    public void HoodSkinChanger(string label)
    {
        hood.SetCategoryAndLabel("Rogue_hood", label);
    }
}
