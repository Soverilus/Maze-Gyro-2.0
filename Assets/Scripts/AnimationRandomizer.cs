using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationRandomizer : MonoBehaviour {
    Animator thisAnim;

    //random animator starting time for default clip
    void Start() {
        thisAnim = GetComponent<Animator>();
        thisAnim.Play("DataCube", gameObject.layer, Random.Range(0f, 30f));
    }
}
