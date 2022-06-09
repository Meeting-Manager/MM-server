using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
       Task RatingPost(Rating value);

    }
}