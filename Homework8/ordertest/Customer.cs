using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    /// <summary>
    /// Customer the man who orders goods.
    /// </summary>
    public class Customer {

        /// <summary>
        /// customer's identifier
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// customer's name
        /// </summary>
        public string Name { get; set; }

        public Customer() { }

        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="id">customer id</param>
        /// <param name="name">customer name </param>
        public Customer(ulong id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Customer object</returns>
        public override string ToString()
        {
            return Name;
        }


    }
}
