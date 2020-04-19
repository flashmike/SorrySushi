using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    int vertextCount = 0;
    bool mouseDown = false;
    LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //detect running platform if android... :mike

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    line.SetVertexCount(vertextCount + 1);
#pragma warning restore CS0618 // Type or member is obsolete
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    line.SetPosition(vertextCount, mousePos);
                    vertextCount++;

                    BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                    box.transform.position = line.transform.position;
                    box.size = new Vector2(0.1f, 0.1f);
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    vertextCount = 0;
#pragma warning disable CS0618 // Type or member is obsolete
                    line.SetVertexCount(0);
#pragma warning restore CS0618 // Type or member is obsolete

                    BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

                    foreach (BoxCollider2D box in colliders)
                        Destroy(box);
                }
            }
        }
        //else if (Application.platform == RuntimePlatform.WindowsPlayer)
        else
        {


            //mike: ...otherwise run this PC version control

            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
            }

            if (mouseDown)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                line.SetVertexCount(vertextCount + 1);
#pragma warning restore CS0618 // Type or member is obsolete
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(vertextCount, mousePos);
                vertextCount++;

                BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                box.transform.position = line.transform.position;
                box.size = new Vector2(0.1f, 0.1f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                vertextCount = 0;
#pragma warning disable CS0618 // Type or member is obsolete
                line.SetVertexCount(0);
#pragma warning restore CS0618 // Type or member is obsolete

                BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

                foreach (BoxCollider2D box in colliders)
                    Destroy(box);
            }
        }
    }
}
