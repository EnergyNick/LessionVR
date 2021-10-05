using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float zombieSpeed = 1.0f;
    public float accuracy = 1f;
    public Transform goal;
    private Transform _thisTransform;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _thisTransform = transform;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculating direction
        var worldPosition = goal.position;
        var thisPosition = _thisTransform.position;

        _thisTransform.LookAt(worldPosition);
        //find direction
        var direction = worldPosition - thisPosition;

        Debug.DrawRay(thisPosition, direction, Color.blue);

        const string isMovingName = "IsMoving";
        if(direction.magnitude > accuracy)
        {
            //move the object
            _animator.SetBool(isMovingName, true);
            _thisTransform.Translate(direction.normalized * zombieSpeed * Time.deltaTime, Space.World);
        }
        else
            _animator.SetBool(isMovingName, false);
    }
}
