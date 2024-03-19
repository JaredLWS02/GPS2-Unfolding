using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class switchTOCutScene : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject cutSceneCam;
    [SerializeField] private GameObject cutScene;
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;
    [SerializeField] private GameObject frog;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private UiTween ui;

    // Start is called before the first frame update
    void Start()
    {
        cutScene.SetActive(false);
        cutSceneCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            frog.GetComponent<NavMeshAgent>().enabled = false;
            frog.transform.position = respawnPoint.position;
            StartCoroutine(transition());
        }
    }

    IEnumerator transition()
    {
        NavMeshHit hit;

        mainCam.SetActive(false);
        ui.BlackenScreenTransition();
        yield return new WaitForSecondsRealtime(0.5f);
        ui.UnBlackenScreenTransition(0.3f);
        cutSceneCam.SetActive(true);
        cutScene.SetActive(true);
        anim1.enabled = true;
        anim2.enabled = true; 
        anim3.enabled = true;
        while (!NavMesh.SamplePosition(respawnPoint.position, out hit, 0.3f, NavMesh.AllAreas))
        {
            frog.GetComponent<NavMeshAgent>().Warp(hit.position);
        }
        frog.GetComponent<NavMeshAgent>().enabled = true;
        this.gameObject.SetActive(false);

    }
}
