using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Simulation
    {

        static Random r = new Random();

        public void Simulate()
        {
            var customerSimSize = 5;
            var customers = GenerateRandomCustomers(customerSimSize);

            var attractionsSimSize = 2;
            var attractions = GenerateRandomAttractions(attractionsSimSize);
            var attractionQueues = new Queue<Guid>[attractions.Length]; // parallel to attractions
            for (var i = 0; i < attractions.Length; i++)
            {
                attractionQueues[i] = new Queue<Guid>();
            }

            var attractionIDToOffset = GetOffsetDictionary(attractions);
            

            var customerToTargetAttractioIndex = new Dictionary<Guid, int>();


            // a customer picks a random attraction to ride. 
            for (var i = 0; i < customers.Length; i++)
            {
                var randomAttraction = attractions[r.Next(attractions.Length)];
                customerToTargetAttractioIndex.Add(customers[i].ID, attractionIDToOffset[randomAttraction.ID]);

                attractionQueues[attractionIDToOffset[randomAttraction.ID]].Enqueue(customers[i].ID);
            }


            // customers enque themselves in that attraction.


            // the attraction dequeues them at the attraction's given bandwidth per hour

            // customers repeat the process. 

        }

        public Customer[] GenerateRandomCustomers(int count)
        {
            var customers = new Customer[count];
            for (var i = 0; i < count; i++)
            {
                customers[i] = GenerateRandomCustomer();
            }
            return customers;
        }

        public Customer GenerateRandomCustomer()
        {
            return new Customer()
            {
                ID = Guid.NewGuid()
            };
        }

        public Attraction[] GenerateRandomAttractions(int count)
        {
            var attractions = new Attraction[count];
            for (var i = 0; i < count; i++)
            {
                attractions[i] = GenerateRandomAttraction();
            }
            return attractions;
        }

        public Attraction GenerateRandomAttraction()
        {
            return new Attraction()
            {
                BandwidthPerHour = 3,
                ID = Guid.NewGuid()
            };
        }
        

        public Dictionary<Guid, int> GetOffsetDictionary<T>(T[] set)
            where T : IHasID
        {
            var output = new Dictionary<Guid, int>();
            for (var i = 0; i < set.Length; i++)
            {
                output.Add(set[i].ID, i);
            }
            return output;
        }

    }
}
