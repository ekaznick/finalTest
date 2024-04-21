namespace finalTest.Models

{
    public interface IEntertainmentRepository
    {
        List<Entertainer> Entertainers { get; }
        public void AddEntertainer(Entertainer entertainer);
        Entertainer GetEntertainer(int id);
        public void UpdateEntertainer(Entertainer entertainer);
        public void DeleteEntertainer(Entertainer entertainer);
    }
}
