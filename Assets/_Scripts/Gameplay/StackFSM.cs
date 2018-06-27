using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;

public class StackFSM {

    public ArrayList stack = new ArrayList();

    public void update() {
            State currentStateFunction = getCurrentState();

            if (currentStateFunction != null)
            {
                Debug.Log("update");
                currentStateFunction.Update();
            }
        
    }

    public State popState(){
        State toReturn = stack[stack.Count-1] as State;
        stack.RemoveAt(stack.Count-1);
        Debug.Log("popState");
        return toReturn;
        //Must implement return.
    }

    public void pushState(State state) {
        if (getCurrentState() != state) {
            Debug.Log("pushState");
            stack.Add(state);
        }
    }
 
    public State getCurrentState() {
        return (stack.Count > 0 ? stack[stack.Count - 1] : null) as State;
    }
	
}

public class State {
    public void OnEnter()
    {

    }
    public void Update()
    {

    }
    public void OnExit()
    {

    }
}