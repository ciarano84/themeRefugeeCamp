using UnityEngine;
using System.Collections;

public class ClickableTile : MonoBehaviour {

    public int tileX;
    public int tileZ;
    public TileMap map;

    void OnMouseUp() {
        if (ResourceManager.materials > 0)
        {
            ResourceManager.instance.AdjustMaterials(-1);
            BuildingManager.instance.BuildTent(tileX, tileZ);
        }
        //map.MoveSelectedUnitTo(tileX, tileZ);
    }
}
