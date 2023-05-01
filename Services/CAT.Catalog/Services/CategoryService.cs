using AutoMapper;
using CAT.Catalog.Dtos;
using CAT.Catalog.Models;
using CAT.Catalog.Settings;
using MongoDB.Driver;
using Shared.Dtos;

namespace CAT.Catalog.Services
{
    public class CategoryService: ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;

		private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();

            if(category == null)
            {
                return Response<CategoryDto>.Fail("NOT FOUND: Category", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var newCategory = _mapper.Map<Category>(categoryCreateDto);

            newCategory.CreatedTime = DateTime.Now;

            await _categoryCollection.InsertOneAsync(newCategory);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(newCategory), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var updateCategory = _mapper.Map<Category>(categoryUpdateDto);

            updateCategory.UpdatedTime = DateTime.Now;

            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == categoryUpdateDto.Id, updateCategory);

            if (result == null)
            {
                return Response<NoContent>.Fail("NOT FOUND: Category", 404);
            }

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _categoryCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("NOT FOUND: Category", 404);
            }
        }

    
    }
}

