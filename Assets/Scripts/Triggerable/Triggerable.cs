using UnityEngine;

public class Triggerable : MonoBehaviour
{
    public delegate void TriggerAction();
    public event TriggerAction OnTrigger;

    public delegate void TriggerActionWithObj(GameObject gameObject);
    public event TriggerActionWithObj OnTriggerWithObject;


    public void trigger()
    {
        if(OnTrigger != null)
        {
            OnTrigger();
        }
    }

    public void trigger(GameObject gameObject)
    {
        if (OnTriggerWithObject != null && gameObject != null)
        {
            OnTriggerWithObject(gameObject);
        }
    }
}
