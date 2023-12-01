using System.Collections;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    public Player player;
    public bool isRoll = false;
    int playerLayer,enemyLayer;
    private void Start()
    {
         playerLayer = LayerMask.NameToLayer("Player");
         enemyLayer = LayerMask.NameToLayer("Enemy");
    }


     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.LeftShift) && !isRoll && !player.ani.GetBool("Hit") && !player.ani.GetBool("isJump"))
             roll();
     }

     void roll() // �ڷ�ƾ ...
     {
         Physics2D.IgnoreLayerCollision(playerLayer,enemyLayer,true);

         isRoll = true; player.canTakeDamage = false;
         float lookingDir = transform.localScale.x;
         player.ani.SetTrigger("Roll");
        SoundManager.soundManager.GetPlayerAudioClip("SPlayerRoll");
         player.rigid.velocity = new Vector2(lookingDir, 0) * player.moveSpeed;

     }

     void SetIsRollFalse()
     {
         isRoll = false;
         player.canTakeDamage = true;
         Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
     }

    /*private void Update()
    {
        Roll();
    }
    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && ( !ani.GetBool("Hit") && !ani.GetBool("isJump")))
            StartCoroutine(roll());

    }
    IEnumerator roll() // �ڷ�ƾ���� ���� , �ִϸ��̼��̺�Ʈ�ִ°� ������ , �ڷ�ƾvs�ִϸ��̼��̺�Ʈ?
    {
        isRoll = true;
        float lookingDir = transform.localScale.x;
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        ani.SetTrigger("Roll");
        rigid.velocity = new Vector2(lookingDir, 0) * rollSpeed;
        yield return new WaitForSeconds(1f);
 
        isRoll = false;



    }*/
}
