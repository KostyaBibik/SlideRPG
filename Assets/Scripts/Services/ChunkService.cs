using System.Collections.Generic;
using Views;

namespace Services
{
    public class ChunkService
    {
        private readonly List<ChunkView> _chunks = new List<ChunkView>();
        public ChunkView[] Chunks => _chunks.ToArray();
        
        public void AddChunkToService(ChunkView chunk)
        {
            _chunks.Add(chunk);
        }

        public void RemoveChunkFromService(ChunkView chunk)
        {
            if (_chunks.Contains(chunk))
            {
                _chunks.Remove(chunk);
            }
        }
    }
}