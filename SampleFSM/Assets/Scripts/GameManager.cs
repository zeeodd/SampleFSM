using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    private FiniteStateMachine<GameManager> _GameManagerStateMachine;

    public GameObject stateACanvasObject;
    public GameObject stateBCanvasObject;
    public GameObject stateCCanvasObject;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeFSM();
    }

    private void Update()
    {
        _GameManagerStateMachine.Update();
    }
    #endregion

    #region Class Functions
    private void InitializeFSM()
    {
        _GameManagerStateMachine = new FiniteStateMachine<GameManager>(this);
        // You must transition to a state after initializing the FSM
        _GameManagerStateMachine.TransitionTo<StateA>(); 
    }

    private void CheckInput()
    {

        if (Input.GetKeyDown(KeyCode.A) && _GameManagerStateMachine.CurrentState.GetType() != typeof(StateA))
        {
            _GameManagerStateMachine.TransitionTo<StateA>();
        }

        if (Input.GetKeyDown(KeyCode.B) && _GameManagerStateMachine.CurrentState.GetType() != typeof(StateB))
        {
            _GameManagerStateMachine.TransitionTo<StateB>();
        }

        if (Input.GetKeyDown(KeyCode.C) && _GameManagerStateMachine.CurrentState.GetType() != typeof(StateC))
        {
            _GameManagerStateMachine.TransitionTo<StateC>();
        }
    }
    #endregion

    #region States
    /*
     *  This is the template state for the FSM.
     *  I pretty much just use these three sub-functions for everything.
     *  Anything you put into these functions will happen for those same functions
     *  in EVERY state you create.
     */
    private class GameState : FiniteStateMachine<GameManager>.State
    {
        public override void OnEnter() { }
        public override void Update() { }
        public override void OnExit() { }
    }

    private class StateA : GameState
    {
        public override void OnEnter()
        {
            Debug.Log("Entering State A...");
            Context.stateACanvasObject.SetActive(true);
        }

        public override void Update()
        {
            Context.CheckInput();
        }

        public override void OnExit()
        {
            Debug.Log("Exiting State A...");
            Context.stateACanvasObject.SetActive(false);
        }
    }

    private class StateB : GameState
    {
        public override void OnEnter()
        {
            Debug.Log("Entering State B...");
            Context.stateBCanvasObject.SetActive(true);
        }

        public override void Update()
        {
            Context.CheckInput();
        }

        public override void OnExit()
        {
            Debug.Log("Exiting State B...");
            Context.stateBCanvasObject.SetActive(false);
        }
    }

    private class StateC : GameState
    {
        public override void OnEnter()
        {
            Debug.Log("Entering State C...");
            Context.stateCCanvasObject.SetActive(true);
        }

        public override void Update()
        {
            Context.CheckInput();
        }

        public override void OnExit()
        {
            Debug.Log("Exiting State C...");
            Context.stateCCanvasObject.SetActive(false);
        }
    }
    #endregion
}
