namespace Accounts.Application.RepositoryInterfaces
{
   public interface IBusinessPartnerRepository
   {
      Task<int?> GetMaxClientNumberAsync();
      Task<int?> GetMaxProviderNumberAsync();
      Task<bool> IsClientAsync(int businessPartnerId);
      Task<bool> IsPurchaseAsync(int businessPartnerId);
      Task SetRoleAsync(int businessPartnerId, string role);
      Task<IEnumerable<int>> GetTypeIdsAsync(int businessPartnerId);
      Task SetTypesAsync(int businessPartnerId, List<int> typeIds);
   }
}
