using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;

public class StackFSMActions
{

    public ArrayList stack = new ArrayList();

    public void update()
    {
        UnityAction currentStateFunction = getCurrentState();

        if (currentStateFunction != null)
        {
            currentStateFunction();
        }

    }

    public UnityAction popState()
    {
        UnityAction toReturn = stack[stack.Count - 1] as UnityAction;
        stack.RemoveAt(stack.Count - 1);
        return toReturn;
        //Must implement return.
    }

    public void pushState(UnityAction state)
    {
        if (getCurrentState() != state)
        {
            stack.Add(state);
        }
    }

    public UnityAction getCurrentState()
    {
        return (stack.Count > 0 ? stack[stack.Count - 1] : null) as UnityAction;
    }

}
