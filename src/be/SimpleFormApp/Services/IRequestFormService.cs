using SimpleFormApp.Models;

namespace SimpleFormApp.Services;
public interface IRequestFormService
{
    Task<RequestForm> Create(CreateRequestForm createRequestForm, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
    Task<RequestForm?> Get(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<RequestForm>> GetAll(CancellationToken cancellationToken);
    Task<RequestForm> Update(Guid id, UpdateRequestForm updateRequest, CancellationToken cancellationToken);
}