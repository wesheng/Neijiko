using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour {

    [SerializeField] private NejikoController m_nejikoController;
    [SerializeField] private GameController m_gameController;

    public static NejikoController NejikoController;
    public static GameController GameController;

	// Use this for initialization
	void Start () {
        NejikoController = m_nejikoController;
        GameController = m_gameController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
