using Microsoft.WindowsAzure.Storage.Table;

namespace Hambasafe.Server.Services.TableStorage
{
    public interface ITableStorageService
    {
        void Save(string connectionString, string tableName, params TableEntity[] toSave);
        T Get<T>(string connectionString, string tableName, string partitionKey, string rowKey) where T : TableEntity;
        T[] GetAll<T>(string connectionString, string tableName, string partitionKey) where T : TableEntity, new();
        void Delete<T>(string connectionString, string tableName, string partitionKey, string rowKey) where T : TableEntity;
    }
}