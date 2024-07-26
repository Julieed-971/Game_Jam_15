using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingView : AbstractBuildingView {

    public override void SelectBuilding(){
        Debug.Log("Selected craft building " + GetComponent<BaseBuilding>().type);
        detailsPanel.Show(GetComponent<BaseBuilding>());
    }
}