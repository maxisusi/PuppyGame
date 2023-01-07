using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb2d;

    Vector2 mouseLatesPost = new Vector2(0f, 0f);
    public float speed = 5;

    private bool isMouseUp = false;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.MouseDrag)
        {
            mouseLatesPost += e.delta;
            isMouseUp = false;
        }

        if (e.type == EventType.MouseUp && e.type != EventType.MouseDrag)
        {
            isMouseUp = true;
            Debug.Log(mouseLatesPost);
        }
    }

    void FixedUpdate()
    {
        if (isMouseUp)
        {
            Vector2 newPosition = new Vector2(Mathf.Clamp(-(mouseLatesPost.x), -2, 2), Mathf.Clamp(Mathf.Abs(mouseLatesPost.y), 0, 2));
            rb2d.AddForce(newPosition, ForceMode2D.Impulse);
            mouseLatesPost = new Vector2(0f, 0f);
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
