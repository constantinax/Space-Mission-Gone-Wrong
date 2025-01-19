using UnityEngine;

public class CameraController : MonoBehaviour
{
   //room camera
   [SerializeField] private float speed;
   private float currentPosx;
   private Vector3 velocity = Vector3.zero;

   //follow the player
   [SerializeField] Transform player;
   [SerializeField] private float aheadDistance;
   [SerializeField] private float cameraSpeed;
   private float lookAhead;


   private void Update()
   {
      //follow player
      transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z); 
      lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
   }
public void MoveToNewRoom(Transform _newRoom)
   {
      currentPosx = _newRoom.position.y;
   }

}
