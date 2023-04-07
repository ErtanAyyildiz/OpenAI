using Microsoft.EntityFrameworkCore;

namespace OpenAI.DataAccess.Concretes
{
    public class OAContext: DbContext
    {
        public OAContext(DbContextOptions<OAContext> options) : base(options)
        {

        }
    }
}
