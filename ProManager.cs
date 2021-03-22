using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProManager : MonoBehaviour
{
    public GameObject CameraAR;
    public GameObject marker;
    public GameObject Character;
    public GameObject Smoke;
    public GameObject Table;
    public GameObject accept;
    public GameObject cancel;
    //public GameObject mask;
    //public GameObject hat;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager scriptManager;
    private bool checkDown;

    
    void Start()
    {
        scriptManager = FindObjectOfType<ARRaycastManager>();
        marker.SetActive(false);
        Character.SetActive(false);
        accept.SetActive(false);
        cancel.SetActive(false);
        Table.SetActive(false);
        StartCoroutine(StandChar());
    }

    
    void Update()
    {


    }

    public void RefreshChar()
    {
        hits = new List<ARRaycastHit>();
        StartCoroutine(StandChar());
    }

    public void ShowMarker()
    {
        
        if (hits.Count > 0)
        {
            marker.transform.position = hits[0].pose.position;
            marker.SetActive(true);
        }
    }

    public IEnumerator StandChar()
    {
        while(hits.Count == 0)
        {
            scriptManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                Clone();
                Character.transform.position = hits[0].pose.position;
                Character.SetActive(true);
            }
            yield return hits.Count;
        }

    }

    public void Clone()
    {
        //объявляешь какой это клон и создаешь его в Контенте допустим
        GameObject cln = Instantiate(Smoke);
        //дальше уже можешь менять параметры этого клона координаты цвет свет вкус
        cln.transform.position = hits[0].pose.position;
        
    }

    public void StartDown()
    {
        checkDown = false;
        Table.SetActive(true);
        accept.SetActive(true);
        cancel.SetActive(true);
        StartCoroutine(Down_obj());
    }

    public IEnumerator Down_obj()
    {
        while (checkDown == false)
        {
            scriptManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
            if (hits.Count > 0)
            {
                Table.transform.position = hits[0].pose.position;
                Table.transform.position = Table.transform.position + new Vector3(0f, 0.129f, 0f);
                Table.transform.rotation = Quaternion.LookRotation(transform.position - CameraAR.transform.position, Vector3.up);
                Table.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 180, 0);
            }
            yield return hits.Count;
        }
    }

    public void BreakDown(bool mute)
    {
        checkDown = true;
        accept.SetActive(false);
        cancel.SetActive(false);
        if (mute == true) Table.SetActive(false);
    }

    public void ActiveThink(GameObject Object)
    {
        Object.SetActive(!Object.activeSelf);
    }
}
