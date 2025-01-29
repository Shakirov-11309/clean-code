using MarkDown.DataBase.models;
using Microsoft.EntityFrameworkCore;

namespace MarkDown.DataBase.repository
{
    public class DocumentsRepository
    {
        private readonly MyDbContext _dbContext;

        public DocumentsRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Documents>> GetDocuments()
        {
            return await _dbContext.Documents
                .ToListAsync();
        }

        public async Task<Documents> GetById(Guid id)
        {
            var documentEntity = await _dbContext.Documents
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id);
            var document = Documents.Create(documentEntity.Id, documentEntity.UserId, documentEntity.NameFile, documentEntity.Text, documentEntity.Users);
            return document;
        }

        public async Task<List<Documents>> GetByUserId(Guid userId)
        {
            var documentEntity = await _dbContext.Documents
               .AsNoTracking()
               .Where(x => x.UserId == userId)
               .ToListAsync();
            var document = documentEntity
                .Select( dbEntity => Documents.Create(dbEntity.Id, dbEntity.UserId, dbEntity.NameFile, dbEntity.Text, dbEntity.Users))
                .ToList();
            return document;
        }

        public async Task Add(Documents documents)
        {
            var documentEntity = new Documents
            {
                Id = documents.Id,
                UserId = documents.UserId,
                NameFile = documents.NameFile,
                Text = documents.Text,
            };

            await _dbContext.AddAsync(documentEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveDocumentByNameFile(string nameFile)
        {
            await _dbContext.Documents
                .Where(c => c.NameFile == nameFile)
                .ExecuteDeleteAsync();
        }
    }
}
