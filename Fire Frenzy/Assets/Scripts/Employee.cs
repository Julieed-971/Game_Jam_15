
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour {
    /// <summary>
    /// Paie toutes les secondes, 1 seconde représente 1 semaine
    /// </summary>  
    public int productivityMax;
    public float productivity;
    public float pendingProductivity;
    public float productivityDecreaseRate;
    public float moraleDecreaseRate;
    public float trainingDuration;
    public float holidaysDuration;
    float absentTimer = 0;
    public int skillMax;
    public int skill;
    public int moraleMax;
    public float morale;
    public int salary;
    public int salaryClaim;
    public CandidateUI candidateUI;
    public int faceId;
    public EmployeeUI employeeUI;
    public void Start(){
        candidateUI = GetComponent<CandidateUI>();
        if (candidateUI != null) {
            GenerateStats(); // Stats du candidat
        }
    }

    // Generate random value for max productivity, skill and morale
    void GenerateStats(){
        // employeeFace.sprite = employeeFaces[Random.Range(0, employeeFaces.Length)];
        productivityMax = Random.Range(5, 12);
        productivityDecreaseRate = 0.1f/productivityMax;
        skillMax = Random.Range(4, 8);
        skill = Random.Range(1, Random.Range(1, Random.Range(1, Random.Range(2, 4))));
        moraleMax = Random.Range(4, 12);
        moraleDecreaseRate = 0.1f/moraleMax;
        salaryClaim = productivityMax * skillMax * moraleMax * skill;
        salaryClaim = (int)((float)salaryClaim * Random.Range(0.8f, 1.2f));
        productivity = 1;
        morale = 1;
        faceId = Random.Range(0, Company.instance.employeeFaces.Length);
        // update moi la gueule
        candidateUI.UpdateUI(this);
    }

    // Copy constructor
    public void CopyEmployee(Employee other) {
        this.productivityMax = other.productivityMax;
        this.productivity = other.productivity;
        this.pendingProductivity = other.pendingProductivity;
        this.productivityDecreaseRate = other.productivityDecreaseRate;
        this.trainingDuration = other.trainingDuration;
        this.holidaysDuration = other.holidaysDuration;
        this.absentTimer = other.absentTimer;
        this.skillMax = other.skillMax;
        this.skill = other.skill;
        this.moraleMax = other.moraleMax;
        this.morale = other.morale;
        this.moraleDecreaseRate = other.moraleDecreaseRate;
        this.salary = other.salary;
        this.salaryClaim = other.salaryClaim;
        this.faceId = other.faceId;
    }

    public void Hire(){
        // TODO fill reference to employeeUI
        Company.instance.HireEmployee(this);
        CandidateGenerator.instance.candidates.Remove(this);
        Destroy(gameObject);
    }
    
    public void FinishHire(){
        productivity = 1;
        morale = 1;
        salary = salaryClaim;
        employeeUI.Create(this);
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
        } else {
            morale -= Time.fixedDeltaTime*moraleDecreaseRate;
        }
        if (employeeUI != null){
            employeeUI.UpdateUI(this);
        }
    }

    public void Fire(){
        Company.instance.FireEmployee(this);
        Destroy(gameObject);
    }

}

