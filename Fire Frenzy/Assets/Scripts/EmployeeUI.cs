using UnityEngine;
using UnityEngine.UI;

public class EmployeeUI : MonoBehaviour {
    public RectTransform productivityBar;
    public RectTransform skillBar;
    public RectTransform moraleBar;
    public Slider productivitySlider;
    public Slider skillSlider;
    public Slider moraleSlider;
    public Image employeeFace;
    public TMPro.TextMeshProUGUI salary;

    public void Create(Employee e){
        SetBarSize(productivityBar, e.productivityMax);
        SetBarSize(skillBar, e.skillMax);
        SetBarSize(moraleBar, e.moraleMax);
        employeeFace.sprite = Company.instance.employeeFaces[e.faceId];
        // productivitySlider.maxValue = productivityMax;
        skillSlider.maxValue = e.skillMax;
        // moraleSlider.maxValue = moraleMax;
        UpdateUI(e);
    }
    public void UpdateUI(Employee e){       
        productivitySlider.value = e.productivity;
        skillSlider.value = e.skill;
        moraleSlider.value = e.morale;
        
        salary.text = "" + e.salaryClaim;
    }
    
    void SetBarSize(RectTransform bar, int maxValue) {
        bar.sizeDelta = new Vector2(bar.sizeDelta.x, maxValue*10);
    }
}
    