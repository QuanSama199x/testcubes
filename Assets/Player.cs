using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }

    public GameObject Collider;
    public GameObject Graphic;
    public Vector3 DirectionRotate, DirMove;
    public bool isMove;

    public float SpeedX,SpeedZ,TMove;

    public List<GameObject> gameObjects;
    public RaycastHit[] hits;

    void Start()
    {
        GameController.Instance.CountWin += 1;
        //Speed = 1;
        InputScript.Move += Move;
    }

    public void Move(string move)
    {
        if(isMove)
        {
            return;
        }
        SpeedX = SpeedZ = 0;
        switch(move)
        {
            case "Up":
                {
                    SpeedX = 1;
                    //DirectionRotate = new Vector3(Speed, 0, 0);
                    break;
                }
            case "Down":
                {
                    SpeedX = -1;
                    //DirectionRotate = new Vector3(-Speed, 0, 0);
                    break;
                }
            case "Left":
                {
                    SpeedZ = -1;
                    //DirectionRotate = new Vector3(0, 0, -Speed);
                    break;
                }
            case "Right":
                {
                    SpeedZ = 1;
                   // DirectionRotate = new Vector3(0, 0, Speed);
                    break;
                }
        }
        DirectionRotate = new Vector3(SpeedX, 0, SpeedZ);
        DirMove = new Vector3(DirectionRotate.z, DirectionRotate.y, DirectionRotate.x);

        
        TestRayCast();
    }
    public void TestRayCast()
    {
        Vector3 pointRay = Collider.transform.position;
        Ray ray = new Ray(pointRay, DirMove/2);
        
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1);
        while (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.tag == "Blocker")
            {
                isMove = false;
                return;
            }
            pointRay += DirMove/2;
            ray = new Ray(pointRay, DirMove/2);
            Physics.Raycast(ray, out hit, 1);
        }
        isMove = true;
        transform.DOMove(transform.position + new Vector3(DirectionRotate.z, 0, DirectionRotate.x), TMove).OnComplete(() => CompleteMove()) ;
        transform.DORotate(new Vector3(DirectionRotate.x, 0, -DirectionRotate.z)*90, TMove).OnComplete(()=> SetRotate());   
    }
    public void SetRotate()
    {
        Vector3 local = Graphic.transform.eulerAngles;
        transform.localEulerAngles = Vector3.zero;
        Graphic.transform.eulerAngles = local;
    }
    public void CompleteMove()
    {
        CheckPointWin();
        reset();
    }
    public void CheckPointWin()
    {
        Vector3 pointRay = Collider.transform.position;
        Ray ray = new Ray(pointRay, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.tag == "PointWin")
            {
                GameController.Instance.CheckWin();
            }
        }
    }

    public void reset()
    {
        isMove = false;
        DirectionRotate = DirMove = Vector3.zero;
    }



}
