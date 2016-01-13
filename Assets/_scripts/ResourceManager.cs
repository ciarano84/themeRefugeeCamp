using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;
    public Text materialCounter;

    public static int materials = 10;

    void Awake()
    {
        instance = this;
    }

    public void AdjustMaterials(int amount)
    {
        materials += amount;
        materialCounter.text = "Materials " + materials;
    }
}
