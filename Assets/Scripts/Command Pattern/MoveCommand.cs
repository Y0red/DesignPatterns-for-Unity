using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Command_Pattern
{
    public class MoveCommand : ICommand
    {
        PlayerMover playerMover;
        Vector3 movement;

        public MoveCommand(PlayerMover player, Vector3 moveVector)
        {
            this.playerMover = player;
            this.movement = moveVector;
        }
        public void Execute()
        {
            playerMover.Move(movement);
        }

        public void Undo()
        {
            playerMover.Move(-movement);
        }
    }

    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private LayerMask obstacleLayer;
        private const float boardSpacing = 1f;
        public void Move(Vector3 movement)
        {
            transform.position = transform.position + movement;
        }
        public bool IsValidMove(Vector3 movement)
        {
            return !Physics.Raycast(transform.position, movement, boardSpacing, obstacleLayer);
        }
    }
}