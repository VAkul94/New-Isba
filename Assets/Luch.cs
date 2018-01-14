using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luch : MonoBehaviour {

    private float dist = 50f,
                dist2 = 3f;


    //GameObject player;
    //public float timer;

    //-------------------------------------
    public float repeat_time; /* Время в секундах */
    private float curr_time;
    //---------------------------------------
    public Camera local_camera;

    // Use this for initialization
    void Start()
    {
        curr_time = repeat_time;/////////////////////////////////
        //player = GameObject.Find("Wall1");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(local_camera.transform.position, local_camera.transform.forward);
        Debug.DrawRay(local_camera.transform.position, local_camera.transform.forward);
        RaycastHit hit;
        /*
        if (Physics.Raycast(ray, out hit, dist))
        {
            //Destroy(hit.collider.gameObject);  //Удаление объекта на расстоянии 3f
            Debug.Log(hit.collider.name + ":" + hit.distance);  //Вывводит на консоль название объекта и дистанцию от него
            //transform.Rotate();
            //transform.rotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }*/
        ///////////////////////////////////
        curr_time -= Time.deltaTime; /* Вычитаем из 10 время кадра (оно в миллисекундах) */

        //if (curr_time <= 0)  /* Время вышло пишем */
        if ((curr_time <= 0) && (Physics.Raycast(ray, out hit, dist)))
        {
            if (string.Compare(hit.collider.name, "Quad") == 0)
            {
                Debug.Log("Это нужный нам объект");
                transform.position = new Vector3(hit.collider.transform.position.x, transform.position.y, hit.collider.transform.position.z);
            }
            /*Debug.Log("Прошло 3 сек!");
            Debug.Log(Time.time.ToString());    //Сколько времени прошло от запуска
            Debug.Log(hit.collider.name + ":" + hit.distance);  //Вывводит на консоль название объекта и дистанцию от него
            */
            curr_time += repeat_time; /* запускает опять таймер на 10,чтобы повторялось бесконечно */
        }
        else
        {
            if ((Physics.Raycast(ray, out hit, dist2)))
            {
                Debug.Log("Прошло 3 сек!");
                Debug.Log(Time.time.ToString());    //Сколько времени прошло от запуска
                Debug.Log(hit.collider.name + ":" + hit.distance);  //Вывводит на консоль название объекта и дистанцию от него
            }
        }
        /////////////////////////////////////

    }

}
