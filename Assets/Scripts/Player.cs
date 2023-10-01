using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    PhotonView view;
    private Animator anim;

    public Text textName;

    private float moveInput;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        textName.text = view.Owner.NickName;
        if (view.Owner.IsLocal)
            Camera.main.GetComponent<FollowCamera>().player=gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            if (moveInput == Vector2.zero)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }   
        }

    }

}
