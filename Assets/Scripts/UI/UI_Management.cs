using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Management : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_StorePanel;
    //public GameObject m_SettingPanel;
    public void OnStoreEvent()
    {
        m_StorePanel.SetActive(true);
        //m_SettingPanel.SetActive(false);
    }

    /* public void OnOptionEvent()
    {
        m_StorePanel.SetActive(false);
        m_SettingPanel.SetActive(true);
    } */

    /* public void OnExitEvent()
    {
        Application.Quit();
    } */

    public void OnSlideValueUpdateEvent(Slider _slider)
    {
        Debug.Log("Value : " + _slider.value);
    }

    /* public void OnToggleUpdateEvent(Toggle _tog)
    {
        Debug.Log("Value : " + _tog.isOn);
    } */
}
