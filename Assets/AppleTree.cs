using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;

    public float speed = 10f;

    public float leftAndRightEdge = 20f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        //Сбрасываем яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    void Update()
    {
        //Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Изменение направления
        if(pos.x < -leftAndRightEdge)
            {
                speed = Mathf.Abs(speed);   //Начать движение вправо
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);      //Начать движение влево
        }
    }

    void FixedUpdate()
    {
        if (Random.value<chanceToChangeDirections)
        {
            speed *= -1;        //Сменить направление
        }
        
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
