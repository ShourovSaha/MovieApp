using MovieApp.Core.Entities.Base;

namespace MovieApp.Core.Entities
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
    }
}