using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractBuildingView : MonoBehaviour, IPointerDownHandler {

    protected BuildingDetailPanel detailsPanel;
    public void Start(){
        detailsPanel = BuildingDetailPanel.instance;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        SelectBuilding();
    }
    public abstract void SelectBuilding();
}
