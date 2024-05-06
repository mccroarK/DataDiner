using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Equation
{
    #region Properties
    // Variables
    [SerializeField] string _question;
    [SerializeField] string _answer;

    // Properties
    public string Question { get { return _question; } }
    public string Answer { get { return _answer; } }
    #endregion
}
