using System.Collections.Generic;
using System.Linq;

namespace AoC2015_9
{
    public class Network : Dictionary<string, Location>
    {
        public static Network Parse(IEnumerable<string> data)
        {
            var locations = new Network();

            foreach (var line in data)
            {
                var rd = RouteStep.Parse(line);

                if (!locations.ContainsKey(rd.From))
                {
                    locations.Add(rd.From, new Location(rd.From));
                }

                if (!locations.ContainsKey(rd.To))
                {
                    locations.Add(rd.To, new Location(rd.To));
                }

                locations[rd.From]
                    .AddDestination(rd.To, rd.Distance, locations);
                locations[rd.To]
                    .AddDestination(rd.From, rd.Distance, locations);
            }

            return locations;
        }


        public Route FindLoop(bool shortest)
        {
            // We are assuming the graph is fully connected, in which case, 
            // go to the closest unvisited neighbor, then the neighbors closest or furthest unvisited neighbor, then the neighbors, neighbors
            // closest unvisited neighbor etc. until we have no more unvisited neighbors left, at which we will have traversed every
            // location once and only once and used the shortest route to do
            var route = (Route)null;
            var distance = shortest ? int.MaxValue : int.MinValue;

            foreach (var start in this.Values)
            {
                var currentRoute = WalkRoute(start, shortest);

                if (shortest 
                    ? currentRoute.Distance() < distance
                    : currentRoute.Distance() > distance)
                {
                    distance = currentRoute.Distance();
                    route = currentRoute;
                }
            }

            return route;
        }

        private Route WalkRoute(Location start, bool shortest)
        {
            List<Destination> Neighbors(IEnumerable<Destination> destinations)
            {
                return (shortest
                    ? destinations.OrderBy(d => d.Distance)
                    : destinations.OrderByDescending(d => d.Distance)).ToList();
            }

            var route = new Route();
            var neighbors = Neighbors(start.Destinations.Unvisited(route));

                var currentLoc = start;

            while (neighbors.Any())
            {
                var closestNeighbor = neighbors.First();

                route.Add(new RouteStep(currentLoc.Name, closestNeighbor.Location.Name, closestNeighbor.Distance));

                currentLoc = closestNeighbor.Location;
                neighbors = Neighbors(currentLoc.Destinations.Unvisited(route));
            }

            return route;
        }
    }


    public class Location
    {
        public readonly Destinations Destinations = new Destinations();

        public Location(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void AddDestination(string name, int distance, Dictionary<string, Location> locations)
        {
            if (!locations.ContainsKey(name))
            {
                var location = new Location(name);
                location.AddDestination(Name, distance, locations);

            }

            Destinations.Add(locations[name], distance);

        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class Destinations : Dictionary<Location, int>
    {
        public IEnumerable<Destination> Unvisited(
            Route currentRoute)
            => this.Where(d =>
                    currentRoute.All(r => r.From != d.Key.Name && r.To != d.Key.Name))
                .Select(r => new Destination() { Location = r.Key, Distance = r.Value });
    }
    public class Destination
    {
        public Location Location { get; set; }
        public int Distance { get; set; }
    }

    public class Routes : List<Route>
    {

    }
    public class Route : List<RouteStep>
    {
        public int Distance()
        {
            return this.Sum(rd => rd.Distance);
        }
    }
    public class RouteStep
    {
        public static RouteStep Parse(string line)
        {
            var split = line.Split(' ');

            return new RouteStep(split[0], split[2], int.Parse(split[4]));
        }

        public RouteStep(string @from, string to, int distance)
        {
            From = @from;
            To = to;
            Distance = distance;
        }

        public string From { get; set; }
        public string To { get; set; }
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{From}-{To}";
        }
    }

}