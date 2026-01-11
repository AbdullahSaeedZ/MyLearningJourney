using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// see pdf 


// Generalization vs Specialization (Summary)

// Specialization (Top-Down):
// - Start with a general entity and break it into more specific sub-entities.
// - Example: Employee → Developer, Teacher, Secretary.
// - You already know the general concept and refine it into details.
// - Direction: General → Specific.

// Generalization (Bottom-Up):
// - Start with multiple specific entities and merge them into a common super-entity.
// - Example: Car + Truck + Motorcycle → Vehicle (general, cant tell what type of vehicle it is)
// - You notice shared attributes and abstract them upward.
// - Direction: Specific → General

// Final Note:
// - Both processes result in inheritance if we can call it this way.
// - The difference is purely in the design approach and how you reach the hierarchy.




namespace _25___Specialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
