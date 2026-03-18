using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Application.RepositoryInterfaces
{
   public interface ICompanyRepository
   {
      Task SetLogoAsync(int domainObjectId, byte[] logoBytes);
      Task<byte[]> GetLogoAsync(int domainObjectId);
   }
}
