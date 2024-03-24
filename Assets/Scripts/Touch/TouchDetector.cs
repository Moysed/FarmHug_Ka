using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour {

    public TouchIdentifier p_touchIdentifier;
    protected Dictionary<int, TouchIdentifier> _touchPool;
    protected int _lastIndex = 0;

    public Camera _Camera;
    public float swipeSpeed = 0.1f;

    public GameObject[] settingPanel;

    private Vector2 lastTouchPosition;

    public BoxCollider2D box;

    // Use this for initialization
    protected virtual void Start()
    {
        //_Camera = this.GetComponent<Camera>();
        _touchPool = new Dictionary<int, TouchIdentifier>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            switch (t.phase)
            {
                case TouchPhase.Began:
                    OnTouchBegan(t);
                    break;
                case TouchPhase.Ended:
                    OnTouchEnded(t);
                    break;
                case TouchPhase.Moved:
                    OnTouchMoved(t);
                    break;
               // case TouchPhase.Stationary:
                   // OnTouchStay(t);
                    //break;
                case TouchPhase.Canceled:
                    OnTouchCancel(t);
                    break;
            }
        }

        if (settingPanel[0].activeSelf)
        {
           
            for(int i = 1; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[1].activeSelf)
        {
           for(int i = 0; i < 1 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 2; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[2].activeSelf)
        {
            for(int i = 0; i < 2 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 3; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[3].activeSelf)
        {
            for(int i = 0; i < 3 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 4; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
            
        }

        if (settingPanel[4].activeSelf)
        {
            for(int i = 0; i < 4 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 5; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[5].activeSelf)
        {
           for(int i = 0; i < 5 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 6; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[6].activeSelf)
        {
            for(int i = 0; i < 6 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 7; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[7].activeSelf)
        {
           for(int i = 0; i < 7 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 8; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[8].activeSelf)
        {
           for(int i = 0; i < 8 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 9; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
             
        }

        if (settingPanel[9].activeSelf)
        {
           for(int i = 0; i < 9 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 10; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[10].activeSelf)
        {
           for(int i = 0; i < 10 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 11; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[11].activeSelf)
        {
            for(int i = 0; i < 11 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 12; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[12].activeSelf)
        {
            for(int i = 0; i < 12 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 13; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[13].activeSelf)
        {
            for(int i = 0; i < 13 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 14; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[14].activeSelf)
        {
           for(int i = 0; i < 14 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 15; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[15].activeSelf)
        {
            for(int i = 0; i < 15 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 16; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[16].activeSelf)
        {
           for(int i = 0; i < 16 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 17; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[17].activeSelf)
        {
            for(int i = 0; i < 17 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 18; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[18].activeSelf)
        {
            for(int i = 0; i < 18 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 19; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[19].activeSelf)
        {
           for(int i = 0; i < 19 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 20; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[20].activeSelf)
        {
            for(int i = 0; i < 20 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 21; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[21].activeSelf)
        {
            for(int i = 0; i < 20 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 22; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[22].activeSelf)
        {
            for(int i = 0; i < 22 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 23; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[23].activeSelf)
        {
            for(int i = 0; i < 23 ; i++){
                settingPanel[i].active = false;
             }
            for(int i = 24; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
        }

        if (settingPanel[24].activeSelf)
        {
            for(int i = 0; i < 24 ; i++){
                settingPanel[i].active = false;
             }
             for(int i = 25; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
            
        }

        if (settingPanel[25].activeSelf)
        {
            for(int i = 0; i < 25 ; i++){
                settingPanel[i].active = false;
             }
             for(int i = 26; i < settingPanel.Length ; i++){
                settingPanel[i].active = false;
             }
            
        }
    }

    void CameraMove(Touch touch)
    {
        if (Input.touchCount == 1)
        {
            Vector2 currentTouchPosition = touch.position;

            // Define the limits of camera movement
            float minX = -2;
            float maxX = 1.8f;
            float minY = -3.9f;
            float maxY = 3.9f;

             //for(int i = 0; i < 5 ; i++)
        //{
               if (!settingPanel[0].activeSelf && 
                    !settingPanel[1].activeSelf && 
                    !settingPanel[2].activeSelf && 
                    !settingPanel[3].activeSelf && 
                    !settingPanel[4].activeSelf && 
                    !settingPanel[5].activeSelf && 
                    !settingPanel[6].activeSelf && 
                    !settingPanel[7].activeSelf && 
                    !settingPanel[8].activeSelf &&
                    !settingPanel[9].activeSelf &&
                    !settingPanel[10].activeSelf &&
                    !settingPanel[11].activeSelf &&
                    !settingPanel[12].activeSelf &&
                    !settingPanel[13].activeSelf &&
                    !settingPanel[14].activeSelf &&
                    !settingPanel[15].activeSelf &&
                    !settingPanel[16].activeSelf &&
                    !settingPanel[17].activeSelf &&
                    !settingPanel[18].activeSelf &&
                    !settingPanel[19].activeSelf &&
                    !settingPanel[20].activeSelf &&
                    !settingPanel[21].activeSelf &&
                    !settingPanel[22].activeSelf &&
                    !settingPanel[23].activeSelf &&
                    !settingPanel[24].activeSelf &&
                    !settingPanel[25].activeSelf )
                {
                    if (lastTouchPosition != Vector2.zero)
                    {
                        Vector2 deltaPosition = currentTouchPosition - lastTouchPosition;

                        // Calculate the new camera position
                        Vector3 newPos = _Camera.transform.position;
                        newPos.x = Mathf.Clamp(newPos.x - deltaPosition.x * swipeSpeed * Time.deltaTime, minX, maxX);
                        newPos.y = Mathf.Clamp(newPos.y - deltaPosition.y * swipeSpeed * Time.deltaTime, minY, maxY);

                        // Update the camera position
                        _Camera.transform.position = newPos;
                    }

                lastTouchPosition = currentTouchPosition;
                //}
                }
        }
    }
    
    public virtual void OnTouchBegan(Touch touch)
    {  
            
        for(int  i = 0 ; i < 26 ; i++)
        if (settingPanel[i].activeSelf)
            {
                {
                    TouchRest(touch);
                }
            }

            GetTouchIdentifierWithTouch(touch);

        lastTouchPosition = touch.position;
        
    }
    public virtual void OnTouchEnded(Touch touch)
    {
      
            RemoveTouchIdentifierWithTouch(touch);
    }
    public virtual void OnTouchMoved(Touch touch) {
        
            UpdateTouchIdentifier (_touchPool [touch.fingerId], touch);
        TouchRest(touch);
        //Input.GetTouch(0);
        CameraMove(touch);
    }
    public virtual void OnTouchStay(Touch touch) {
       
            UpdateTouchIdentifier (_touchPool [touch.fingerId], touch);
    }
    public virtual void OnTouchCancel(Touch touch)
    {
      
            RemoveTouchIdentifierWithTouch(touch);
    }

    public Vector3 convertScreenToWorld(Vector3 pos)
    {
        if (_Camera.orthographic == false)
            print("Camera is not orthographic");

        pos = _Camera.ScreenToWorldPoint(pos);
        pos.z = 0;
        return pos;
    }

   

    public TouchIdentifier GetTouchIdentifierWithTouch(Touch touch)
    {
        //If Finded with fingerID
        if (_touchPool.ContainsKey(touch.fingerId))
        {
            UpdateTouchIdentifier(_touchPool[touch.fingerId], touch);
            return _touchPool[touch.fingerId];
        }

        //Get a new Touch.
        TouchIdentifier t = Instantiate(p_touchIdentifier);
        t.fingerId = touch.fingerId;
        t.timeCreated = Time.time;
        t.startPosition = touch.position;
        //t.parent = transform;
        t.name = "Touch " + _lastIndex;

        UpdateTouchIdentifier(t, touch);


        _lastIndex++;
        _touchPool.Add(touch.fingerId, t);

        return t;
    }

    void UpdateTouchIdentifier(TouchIdentifier touchid, Touch touch)
    {
        touchid.transform.position = convertScreenToWorld(touch.position);
        touchid.deltaPosition = touch.deltaPosition;
    }

    public void RemoveTouchIdentifierWithTouch(Touch touch)
    {
        RemoveTouchIdentifierWithTouch(touch, _touchPool);
    }

    public bool RemoveTouchIdentifierWithTouch(Touch touch, Dictionary<int, TouchIdentifier> listTouch)
    {
        if (_touchPool.ContainsKey(touch.fingerId))
        {
            DeactiveTouch(touch);
            return listTouch.Remove(touch.fingerId);
        }
        return false;
    }

    void DeactiveTouch(Touch touch)
    {
        TouchIdentifier touchId = GetTouchIdentifierWithTouch(touch);

        if (!touchId) return;

        touchId.gameObject.SetActive(false);
        touchId.fingerId = -1;
        Destroy(touchId.gameObject);
    }

    void TouchRest(Touch touch)
    {

        TouchIdentifier touchId = GetTouchIdentifierWithTouch(touch);

        touchId.gameObject.SetActive(false) ;
    }
}
