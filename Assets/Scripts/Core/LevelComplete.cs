using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject fireboy;
    public GameObject treegirl;

    [SerializeField]
    private GameObject levelCompletePanel;

    [SerializeField]
    private AudioClip levelCompleteSound;
    private bool levelCompleted;
    private void Awake()
    {
        levelCompleted = true;
        levelCompletePanel.SetActive(false);
    }
    private void Update()
    {
        if(fireboy.GetComponent<FireboyMovement>().reachedDoor && treegirl.GetComponent<TreegirlMovement>().reachedDoor && levelCompleted)
        {
            StartCoroutine(Complete());
        }
    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlaySound(levelCompleteSound);
        levelCompletePanel.SetActive(true);
        levelCompleted = false;
    }
}
