using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandidateGenerator : Singleton<CandidateGenerator> {
    public List<Employee> candidates;
    public GameObject candidatePrefab;
    public GameObject panelOfCandidates;
    float popDuration = 3;
    float popTimer = 0.001f;
    void Start(){
        candidates = new List<Employee>();
    }
    void FixedUpdate(){
        if (popTimer > 0){
            popTimer -= Time.fixedDeltaTime;
            if (popTimer < 0){
                if (candidates.Count == 6) {
                    Employee e = candidates[0];
                    candidates.Remove(e);
                    Destroy(e.gameObject);
                }
                GameObject go = Instantiate(candidatePrefab);
                go.transform.SetParent(panelOfCandidates.transform, false);
                popTimer = popDuration;
                candidates.Add(go.GetComponent<Employee>());
            }
        }
    }
}