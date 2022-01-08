using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;
using Tahaluf.Portal.Core.Repositry;
using Tahaluf.Portal.Core.Services;

namespace Tahaluf.Portal.Infra.Services
{
    public class MARKSService : IMARKStService
    {
        private readonly IMARKSRepository MARKSRepository;
        public MARKSService(IMARKSRepository mARKSRepository)
        {
            MARKSRepository = mARKSRepository;
        }

        public List<MARKS> GetAll()
        {
            return MARKSRepository.GetAll();
        }
      
    }
}
