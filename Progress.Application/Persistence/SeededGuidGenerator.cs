namespace Progress.Application.Persistence
{
    public class SeededGuidGenerator
    {
        private readonly Random random;

        public SeededGuidGenerator(int seed)
        {
            random = new Random(seed);
        }

        public Guid GetNext()
        {
            return Guid.Parse(string.Format("{0:X4}{1:X4}-{2:X4}-{3:X4}-{4:X4}-{5:X4}{6:X4}{7:X4}",
                random.Next(0, 0xffff), random.Next(0, 0xffff),
                random.Next(0, 0xffff),
                random.Next(0, 0xffff) | 0x4000,
                random.Next(0, 0x3fff) | 0x8000,
                random.Next(0, 0xffff), random.Next(0, 0xffff), random.Next(0, 0xffff)));
        }
    }
}
