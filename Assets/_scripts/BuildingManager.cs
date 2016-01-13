using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager instance;

    public GameObject tent_1_0;

    void Awake()
    {
        instance = this;
    }

    public void BuildTent(int x, int z)
    {
        Instantiate(tent_1_0, new Vector3(x, 0, z), Quaternion.identity);
    }
}
