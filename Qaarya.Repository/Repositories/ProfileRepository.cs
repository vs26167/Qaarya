using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qaarya.Data.DataModel;
using Qaarya.Repository.Interfaces;
using Qaarya.Repository.Repository;

namespace Qaarya.Repository.Repositories
{
    public class ProfileRepository : Repository<QaaryaProfile>, IProfileRepository
    {
    }
}
