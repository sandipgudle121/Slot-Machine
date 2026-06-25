using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour
{
    [SerializeField] private GameObject upLever;
    [SerializeField] private GameObject downLever;

    private void Start()
    {
        upLever.SetActive(true);
        downLever.SetActive(false);
    }

    public IEnumerator PullLever()
    {
        upLever.SetActive(false);
        downLever.SetActive(true);

        yield return new WaitForSeconds(0.15f);

        upLever.SetActive(true);
        downLever.SetActive(false);
    }
}
