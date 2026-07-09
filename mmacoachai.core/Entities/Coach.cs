using System;
using System.Collections.Generic;
using System.Text;

namespace mmacoachai.core.Entities
{
    //Class Desctription: This class represents a coach in the MMA Coach AI application.
    //It contains properties and methods related to the coach's attributes and functionalities.
    //A coach can have multiple athletes under their guidance, and this class provides a way to manage those relationships.
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property for the related athletes
        public ICollection<Athlete> Athletes { get; set; } = new List<Athlete>();
    }
}
