using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL : IRatingBL
    {
        IRatingDL ratingDL;
        public RatingBL(IRatingDL ratingDL)
        {
            this.ratingDL = ratingDL;
        }
        public async Task RatingPost(Rating value)
        {
            await ratingDL.RatingPost(value);
        }
    }
}
