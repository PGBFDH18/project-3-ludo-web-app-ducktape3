using System.Collections.Generic;

namespace WebApp.Models
{
    public class Team
    {
        public IEnumerable<Player> Players { get; set; }
        public string gameId { get; set; }
    }


    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerColor PlayerColor { get; set; }
        public Piece[] Pieces { get; set; }
        public int Offset
        {
            get
            {
                return (int)PlayerColor * 13;
            }
        }
    }
    public enum PlayerColor
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3

    }
    public class Piece
    {
        public int PieceId { get; set; }
        public PieceGameState State { get; set; }
        public int Position { get; set; }
    }
    public enum PieceGameState
    {
        HomeArea,
        InGame,
        GoalPath,
        Goal
    }
}
