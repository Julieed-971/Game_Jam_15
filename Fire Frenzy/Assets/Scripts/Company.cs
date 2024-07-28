using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Company : Singleton<Company> {

    List<Employee> employees;
    public Sprite[] employeeFaces;
    public GameObject employeePrefab;
    public GameObject[] contentPanels;
    public Slider rentabilitySlider;
    public Slider moraleSlider;
    float weekDuration;
    float weekTimer;
    public int capital;
    public TMPro.TextMeshProUGUI capitalTxt;
    public TMPro.TextMeshProUGUI gainPerSecTxt;

    void Start(){
        weekTimer = 0;
        weekDuration = 1;
        employees = new List<Employee>();
        rentabilitySlider.maxValue = 50;
        rentabilitySlider.minValue = -50;
        moraleSlider.value = 0;
        rentabilitySlider.value = 0;
    }

    float Rentability(){
        float rez = 0;
        foreach (Employee e in employees){
            rez += (e.Rentability()*e.EmployeeValue()/26) - e.salary/52;
        }
        return rez;
    } 

    float CompanyMorale(){
        float morale = 0;
        foreach (Employee e in employees){
            morale += e.morale;
        }
        morale /= (float)employees.Count;
        return morale;
    }

    public bool HireEmployee(Employee e){
        GameObject goParentPanel;
        if (contentPanels[0].transform.childCount == 4 && contentPanels[1].transform.childCount == 4){
            return false;
        } else if (contentPanels[0].transform.childCount < 4){
            goParentPanel = contentPanels[0];
        } else {
            goParentPanel = contentPanels[1];
        }
        if (capital < e.salaryClaim){
            return false;
        } else {
            capital -= e.salaryClaim;
        }
        GameObject go = Instantiate(employeePrefab);
        go.transform.SetParent(goParentPanel.transform, false);
        Employee employeeCopy = go.GetComponent<Employee>();
        employeeCopy.CopyEmployee(e);
        employees.Add(employeeCopy);
        employeeCopy.employeeUI = go.GetComponent<EmployeeUI>();
        employeeCopy.FinishHire();
        return true;
    }

    public void FireEmployee(Employee e){
        employees.Remove(e);
    }

    void FixedUpdate() {
        if (weekTimer >= weekDuration){
            float rentability = Rentability();
            rentabilitySlider.value = rentability;
            capital += Mathf.RoundToInt(rentability);
            capitalTxt.text = "" + capital;
            float morale = CompanyMorale();
            Debug.Log("Morale " + morale);
            if (morale != float.NaN){
                moraleSlider.value = morale;
            }
            weekTimer = 0;
            gainPerSecTxt.text = (rentability>0) ? "+" + Mathf.RoundToInt(rentability) + "/s": "" + Mathf.RoundToInt(rentability) + "/s";
        } else {
            weekTimer += Time.fixedDeltaTime;
        }        
    }
}