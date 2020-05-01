using System.Collections.Generic;

namespace Johoot.Data
{
    public class Player
    {
        public long Id { get; set; }
        public string Nick { get; set; }
        public List<int> Points { get; set; }
    }
}