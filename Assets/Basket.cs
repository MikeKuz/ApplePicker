using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        //Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        // Установить начальное число очков равным 
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        //Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        //Преобразовать точкуна двумерной плоскости экрана в трехмерный координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переместить корзину вдоль оси Х в координату Х указателя мыши 
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;


    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
        //Преобразовать текст в ScoreGT  в целое число
        int score = int.Parse(scoreGT.text);
        //Добавить очки за пойманое яблоко
        score += 100;
        //Преобразовать число очков обратно в строку и ывести на экран
        scoreGT.text = score.ToString();

        //Запомнить высшее достижение
        if(score>HighScore.score)
        { 
            HighScore.score = score;
        }
        
    }


}
