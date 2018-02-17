using System;
using WebSuiteDDD.SharedKernel.Domain;

namespace WebSuiteDemo.Loadtesting.Domain
{
    /// <summary>
    /// The Location of a LoadTest Agent.
    /// </summary>
    public class Location : ValueObjectBase<Location>
    {
        /// <summary>
        /// The name of the city where the agent is located.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// The name of the country where the agent is located.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Private constructor required by EntityFramework.
        /// </summary>
        private Location() { }

        /// <summary>
        /// Constructor of the location.
        /// </summary>
        /// <param name="city">The name of the city.</param>
        /// <param name="country">The name of the country.</param>
        public Location(string city, string country)
        {
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException("city");
            if (string.IsNullOrEmpty(country)) throw new ArgumentNullException("country");
            City = city;
            Country = country;
        }

        /// <summary>
        /// Define the Location with a new City name.
        /// </summary>
        /// <param name="city">The new city name.</param>
        /// <returns>A new location with this city name.</returns>
        public Location WithCity(string city)
        {
            return new Location(city, this.Country);
        }

        /// <summary>
        /// Define the Location with a new Country name.
        /// </summary>
        /// <param name="country">The new country name.</param>
        /// <returns>A new location with this country name.</returns>
        public Location WithCountry(string country)
        {
            return new Location(this.City, country);
        }

        /// <summary>
        /// The comparision between 2 Location object.
        /// </summary>
        /// <param name="other">The second Location object.</param>
        /// <returns>
        ///     <c>True</c> if they are identical ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(Location other)
        {
            return this.City.Equals(other.City, StringComparison.InvariantCultureIgnoreCase)
                && this.Country.Equals(other.Country, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// The comparision between the Location and another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        ///     <c>True</c> if they are identical ; otherwise, <c>False</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Location)) return false;
            return this.Equals((Location)obj);
        }

        /// <summary>
        /// The HashCode of the Location.
        /// </summary>
        /// <returns>The city and country Location hashcode concatenated.</returns>
        public override int GetHashCode()
        {
            return this.City.GetHashCode() + this.Country.GetHashCode();
        }
    }
}
