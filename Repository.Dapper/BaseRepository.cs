using Repository.Dapper.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dapper
{
    public class BaseRepository
    {
        protected IDatabaseHelper _Helper;
        public BaseRepository(IDatabaseHelper databaseHelper)
        {
            _Helper = databaseHelper;
        }
    }
}
