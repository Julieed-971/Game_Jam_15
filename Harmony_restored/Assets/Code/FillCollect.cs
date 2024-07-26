
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class FillCollect : Singleton<FillCollect> {
    Image image;
    public float duration = 2f;

    void Start() {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void StartFill(ResourceType type){
        //Retrieve cursor position and set current position to cursor position
        transform.position = Input.mousePosition;
        image.fillAmount = 0;
        image.enabled = true;
        StartCoroutine(Fill(type));
    }

    IEnumerator Fill(ResourceType type){
        float elapsedTime = 0;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            image.fillAmount = elapsedTime/duration;
            yield return null;
        }
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponentInChildren<Animator>().Play("CollectAnim");
        PlayerManager.instance.AddResource(type);
        image.fillAmount = 0;
    }

    public void CancelFill(){
        StopAllCoroutines();
        image.fillAmount = 0;
        image.enabled = false;
    }
}
