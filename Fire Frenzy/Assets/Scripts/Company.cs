using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Company : Singleton<Company> {

    List<Employee> employees;

    public GameObject employeePrefab;
    public GameObject[] contentPanels;

    float Rentability(){
        float rez = 0;
        foreach (Employee e in employees){
            rez += e.Rentability() - e.salary;
        }
        return rez;
    } 

    float CompanyMorale(){
        float morale = 0;
        foreach (Employee e in employees){
            morale += e.morale;
        }
        morale = morale / employees.Count;
        return morale;
    }

    public void HireEmployee(Employee e){
        // TODO Add new employee to employees panel
        //     instantiate the employee prefab
        GameObject go = Instantiate(employeePrefab);
        go.transform.SetParent(contentPanels[0].transform);
        //     set the current Employee to the employee prefab
        Employee newE = go.AddComponent<Employee>();
        newE = new Employee(e);
        newE.SetEmployeeUI(); // 
        //     reload Graphics of the employee (bars)
        //TODO: Remove e from candidates
        employees.Add(e);
    }

    public void FireEmployee(Employee e){
        employees.Remove(e);
    }


}