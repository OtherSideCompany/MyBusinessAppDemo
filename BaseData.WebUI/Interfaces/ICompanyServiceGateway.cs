using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.WebUI.Interfaces
{
   public interface ICompanyServiceGateway
   {
      Task SaveLogoAsync(int domainObjectId, byte[] logoBytes);
      Task<byte[]?> GetLogoAsync(int domainObjectId);
   }
}
