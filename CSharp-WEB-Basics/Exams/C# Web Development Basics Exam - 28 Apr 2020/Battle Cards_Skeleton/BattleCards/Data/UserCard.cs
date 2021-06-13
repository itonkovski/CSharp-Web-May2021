﻿using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class UserCard
    {
        //Has UserId – a string
        //Has User – a User object
        //Has CardId – an int
        //Has Card – a Card object

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }
    }
}