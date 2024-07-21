
using UnityEngine;

public class BuildingDetailPanel : Singleton<BuildingDetailPanel> {

    TMPro.TextMeshProUGUI buildingName;
    public GameObject thePanel;
    void Start(){
        buildingName = thePanel.transform.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        thePanel.SetActive(true);
        Hide();
    }
    public void Show(string name){
        buildingName.text = name;
        thePanel.SetActive(true);
    }
    public void Show(CraftBuilding craftBuilding){
        buildingName.text = craftBuilding.type.ToString();
        //TODO Continue here
        thePanel.SetActive(true);
    }
    public void Show(BaseBuilding baseBuilding){
        buildingName.text = baseBuilding.type.ToString();
        //TODO Continue this too
        thePanel.SetActive(true);
    }
    public void Hide(){
        thePanel.SetActive(false);
    }
}