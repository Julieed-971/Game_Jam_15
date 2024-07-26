
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour {
    /// <summary>
    /// Paie toutes les secondes, 1 seconde représente 1 semaine
    /// </summary>
    public RectTransform productivityBar;
    public RectTransform skillBar;
    public RectTransform moraleBar;
    public int productivityMax;
    public float productivity;
    public float pendingProductivity;
    public float productivityDecreaseRate;
    public float trainingDuration;
    public float holidaysDuration;
    float absentTimer = 0;
    public Slider productivitySlider;
    public int skillMax;
    public int skill;
    public Slider skillSlider;
    public int moraleMax;
    public float morale;
    public Slider moraleSlider;
    public int salary;
    public int salaryClaim;
    public Image employeeFace;
    public TMPro.TextMeshProUGUI wageClaim;
    public Sprite[] employeeFaces;
    
    public void Start(){
        GenerateStats(); // Stats du candidat
    }

    // Generate random value for max productivity, skill and morale
    void GenerateStats(){
        employeeFace.sprite = employeeFaces[Random.Range(0, employeeFaces.Length)];
        productivityMax = Random.Range(5, 12);
        skillMax = Random.Range(4, 8);
        skill = Random.Range(1, Random.Range(1, Random.Range(1, Random.Range(3, 4))));
        moraleMax = Random.Range(4, 12);
        salaryClaim = productivityMax * skillMax * moraleMax * skill;
        salaryClaim = (int)((float)salaryClaim * Random.Range(0.8f, 1.2f));
        productivity = 1;
        morale = 1;
        SetEmployeeUI();
    }

    // Copy constructor
    public Employee(Employee other) {
        this.productivityBar = other.productivityBar;
        this.skillBar = other.skillBar;
        this.moraleBar = other.moraleBar;
        this.productivityMax = other.productivityMax;
        this.productivity = other.productivity;
        this.pendingProductivity = other.pendingProductivity;
        this.productivityDecreaseRate = other.productivityDecreaseRate;
        this.trainingDuration = other.trainingDuration;
        this.holidaysDuration = other.holidaysDuration;
        this.absentTimer = other.absentTimer;
        this.productivitySlider = other.productivitySlider;
        this.skillMax = other.skillMax;
        this.skill = other.skill;
        this.skillSlider = other.skillSlider;
        this.moraleMax = other.moraleMax;
        this.morale = other.morale;
        this.moraleSlider = other.moraleSlider;
        this.salary = other.salary;
        this.salaryClaim = other.salaryClaim;
        this.employeeFace = other.employeeFace;
        this.employeeFaces = other.employeeFaces;
    }

    public void SetEmployeeUI(){
        SetBarSize(productivityBar, productivityMax);
        SetBarSize(skillBar, skillMax);
        SetBarSize(moraleBar, moraleMax);

        // productivitySlider.maxValue = productivityMax;
        skillSlider.maxValue = skillMax;
        // moraleSlider.maxValue = moraleMax;

        productivitySlider.value = productivity;
        skillSlider.value = skill;
        moraleSlider.value = morale;
        
        wageClaim.text = "" + salaryClaim;
    }
    
    void SetBarSize(RectTransform bar, int maxValue) {
        bar.sizeDelta = new Vector2(bar.sizeDelta.x, maxValue*10);
    }

    public void Hire(){
        Company.instance.HireEmployee(this);        
        productivity = 1;
        morale = 1;
        salary = salaryClaim;
    }

    public void Raise(){
        salary = salary + salary * 10 / 100;
        productivity = 1;
    }

    public void Training(){
        skill++;
        pendingProductivity = productivity;
        productivity = 0;
        absentTimer = trainingDuration;
    }

    public float Rentability(){
        return productivity * skill;
    } 

    public void Holidays(){
        morale = 1;
        pendingProductivity = productivity;
        productivity = 0;
        absentTimer = holidaysDuration;

    }

    void FixedUpdate() {

        productivity -= Time.fixedDeltaTime*productivityDecreaseRate;
        pendingProductivity -= Time.fixedDeltaTime*productivityDecreaseRate;

        if (absentTimer >0){
            absentTimer -= Time.fixedDeltaTime;
            if (absentTimer < 0){
                productivity = pendingProductivity;
            }
        }
    }

    public void Fire(){
        Company.instance.FireEmployee(this);
        Destroy(gameObject);
    }

}

