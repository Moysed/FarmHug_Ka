using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScarecrowBar : MonoBehaviour
{
    ScarecrowObject scarecrow;
    [SerializeField] private Image uiFill;

    public float Duration;

    private float remainingDuration;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(float Second)
    {
        remainingDuration = Second;
        scarecrow.gameObject.SetActive(true);
    }

    private async void Update()
    {
            if (remainingDuration >= 0)
            {
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration -= Time.deltaTime;
            }

            if (remainingDuration < 0)
            {
                    OnEnd(); 
            }
    }

    private void OnEnd()
    {
        remainingDuration = Duration;
        print("End");
    }
}
