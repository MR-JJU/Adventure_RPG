using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallengerController : MonoBehaviour, Interactable 
{    
    //initialize dialog f�r challenger and shows it 
        [SerializeField] Dialog dialog;

        public void Interact()
        {
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
}
