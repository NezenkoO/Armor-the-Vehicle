using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IChunkReclaimer
{
    public void Reclaim(Chunk chunk);
}
