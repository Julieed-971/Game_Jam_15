using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBuildingView : AbstractBuildingView {

    public override void SelectBuilding(){
        Debug.Log("Selected craft building " + GetComponent<CraftBuilding>().type);
        detailsPanel.Show(GetComponent<CraftBuilding>());
    }
}
