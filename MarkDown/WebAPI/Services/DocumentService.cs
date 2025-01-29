using MarkDown.DataBase.models;
using MarkDown.DataBase.repository;

namespace WebAPI.Services
{
    public class DocumentService
    {
        public readonly DocumentsRepository _documentsRepository;
        public DocumentService(
            DocumentsRepository documentsRepository) 
        {
            _documentsRepository = documentsRepository;
        }

        public async Task Create(Documents document) 
        {
            await _documentsRepository.Add(document);
        }

        public async Task<Documents> GetById(Guid id) 
        {
            return await _documentsRepository.GetById(id);
        }

        public async Task<List<Documents>> GetByUserId(Guid userid)
        {
            return await _documentsRepository.GetByUserId(userid);
        }
    }
}
