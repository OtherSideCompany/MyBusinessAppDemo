using BusinessAppFramework.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Application.Interfaces
{
   public interface ICompanyService
   {
      Task SetLogoAsync(int domainObjectId, byte[] logoBytes);
      Task<byte[]> GetLogoAsync(int domainObjectId);
   }
}
