using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCommands : MonoBehaviour
{
    public GameObject mPlayer;
    private Invoker mInvoker;

    void Start()
    {
        mInvoker = new Invoker();
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            dir.z = 1.0f;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            dir.z = -1.0f;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            dir.x = -1.0f;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            dir.x = 1.0f;

        if (dir != Vector3.zero)
        {
            //----------------------------------------------------//
            //Using normal implementation.
            //mPlayer.transform.position += dir;
            //----------------------------------------------------//


            //----------------------------------------------------//
            //Using command pattern implementation.
            ICommand move = new CommandMove(mPlayer, dir);
            mInvoker.Execute(move);
            //----------------------------------------------------//
        }

        var clickPoint = GetClickPosition();

        //----------------------------------------------------//
        //Using normal implementation for right click moveto.
        //if (clickPoint != null)
        //{
        //    IEnumerator moveto = MoveToInSeconds(mPlayer, clickPoint.Value, 0.5f);
        //    StartCoroutine(moveto);
        //}
        //----------------------------------------------------//

        //----------------------------------------------------//
        //Using command pattern right click moveto.
        if (clickPoint != null)
        {
            CommandMoveTo moveto = new CommandMoveTo(this, mPlayer.transform.position, clickPoint.Value);
            mInvoker.Execute(moveto);
        }
        //----------------------------------------------------//


        //----------------------------------------------------//
        // Undo 
        if (Input.GetKeyDown(KeyCode.U))
        {
            mInvoker.Undo();
        }
        //----------------------------------------------------//
    }

    public void MoveTo(Vector3 pt)
    {
        IEnumerator moveto = MoveToInSeconds(mPlayer, pt, 0.5f);
        StartCoroutine(moveto);
    }

    public Vector3? GetClickPosition()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log("Tag = " + hitInfo.collider.gameObject.tag);
                return hitInfo.point;
            }
        }
        return null;
    }

    public IEnumerator MoveToInSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        end.y = startingPos.y;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        objectToMove.transform.position = end;
    }
}


