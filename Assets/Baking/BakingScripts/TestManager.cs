using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class TestManager : MonoBehaviour
{
    int index = 0;

    //Event
    public UpgradeEvent upgradeEvent;

    UpgradeManager upgradeManager = new UpgradeManager().GetComponent<UpgradeManager>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            upgradeEvent.Invoke(index);
            index += 1;
        }
    }
}
