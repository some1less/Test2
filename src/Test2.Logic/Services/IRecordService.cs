using Test2.DAL.models;
using Test2.Logic.DTO;

namespace Test2.Logic.Services;

public interface IRecordService
{
    Task<IEnumerable<RecordDTO?>> GetAllRecordsAsync();
    Task<Record> CreateRecordAsync(CreateRecordDTO dto);

}