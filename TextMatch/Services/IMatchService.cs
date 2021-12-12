using System.Collections.Generic;
using TextMatch.Models;

namespace TextMatch.Services
{
    public interface IMatchService
    {
        IEnumerable<int> AllIndicesOf(TextString textString);
        
    }
}