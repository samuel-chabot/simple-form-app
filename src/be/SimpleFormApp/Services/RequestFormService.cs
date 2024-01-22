using Microsoft.EntityFrameworkCore;
using SimpleFormApp.Database;
using SimpleFormApp.Models;

namespace SimpleFormApp.Services;

public class RequestFormService : IRequestFormService
{
    private readonly ApplicationContext _db;

    public RequestFormService(ApplicationContext db)
    {
        this._db = db;
    }

    public async Task<IEnumerable<RequestForm>> GetAll(CancellationToken cancellationToken)
    {
        var records = await _db.RequestForms.ToListAsync(cancellationToken);
        return records.Select(x => x.Into());
    }

    public async Task<RequestForm?> Get(Guid id, CancellationToken cancellationToken)
    {
        var record = await _db.RequestForms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return record?.Into();
    }

    public async Task<RequestForm> Create(CreateRequestForm createRequestForm, CancellationToken cancellationToken)
    {
        var record = new RequestFormRecord()
        {
            ApplicationArea = createRequestForm.ApplicationArea,
            Tag = new Tag() { Tags = createRequestForm.Tags },
            Title = createRequestForm.Title,
            Description = createRequestForm.Description,
            ContactEmail = createRequestForm.ContactEmail,
            DateCreated = DateTime.UtcNow,
            Resolved = createRequestForm.Resolved,
            VideoUrl = createRequestForm.VideoUrl,
            DateTime = createRequestForm.DateTime,
        };

        _db.RequestForms.Add(record);
        await _db.SaveChangesAsync(cancellationToken);

        return record.Into();
    }

    public async Task<RequestForm> Update(Guid id, UpdateRequestForm updateRequest, CancellationToken cancellationToken)
    {
        var record = await _db.RequestForms.FirstAsync(x => x.Id == id, cancellationToken);

        record.ApplicationArea = updateRequest.ApplicationArea;
        record.Tag = new Tag() { Tags = updateRequest.Tags };
        record.Title = updateRequest.Title;
        record.Description = updateRequest.Description;
        record.ContactEmail = updateRequest.ContactEmail;
        record.Resolved = updateRequest.Resolved;
        record.VideoUrl = updateRequest.VideoUrl;
        record.DateTime = updateRequest.DateTime;
        record.DateCreated = DateTime.UtcNow;

        await _db.SaveChangesAsync(cancellationToken);

        return record.Into();
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _db.RequestForms.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        return result == 1;
    }
}
