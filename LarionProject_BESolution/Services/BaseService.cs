using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {
        protected readonly LarionDatabaseContext _context;
        protected readonly IMapper _mapper;
        public BaseService (LarionDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
