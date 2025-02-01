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

        public async Task<List<string>> GetById(Guid id)
        {
            var documentEntity = await _dbContext.Documents
               .AsNoTracking()
               .Where(x => x.UserId == id)
               .Select(x => x.NameFile)
               .ToListAsync();
            return documentEntity;
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

        public async Task Add(Guid userId, string name, string text)
        {
            var documentEntity = new Documents
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                NameFile = name,
                Text = text,
            };

            await _dbContext.AddAsync(documentEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveDocument(Guid userId, string nameFile)
        {
            await _dbContext.Documents
                .Where(c => c.UserId == userId && c.NameFile == nameFile)
                .ExecuteDeleteAsync();
        }
    }
}
