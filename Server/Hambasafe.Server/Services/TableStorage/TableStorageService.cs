using System;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Hambasafe.Server.Services.TableStorage
{
    public class TableStorageService : ITableStorageService
    {
        public void Save(string connectionString, string tableName,params TableEntity[] toSave)
        {
            CloudTable table = GetTable(connectionString, tableName);

            if (toSave.Length > 1)
            {
                TableBatchOperation batchOperation = new TableBatchOperation();
                foreach (TableEntity entity in toSave)
                {
                    batchOperation.InsertOrReplace(entity);
                }
                Execute(table, () => table.ExecuteBatch(batchOperation));
            }
            else if (toSave.Length == 1)
            {
                TableOperation insertOperation= TableOperation.InsertOrReplace(toSave.First());
                Execute(table, () => table.Execute(insertOperation));
               
            }
        }

       private void Execute(CloudTable table, Action toExecute )
        {
            try
            {
                toExecute();
            }
            catch (StorageException error)
            {
                if (error.RequestInformation.HttpStatusCode == 404)
                {
                    table.CreateIfNotExistsAsync();
                    toExecute();
                }
                else
                {
                    throw;
                }
            }
        }

        private static CloudTable GetTable(string connectionString, string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
           
            return table;
        }

        public T Get<T>(string connectionString, string tableName, string partitionKey, string rowKey) where T : TableEntity
        {
            CloudTable table = GetTable(connectionString, tableName);
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            table.CreateIfNotExists();
            TableResult retrievedResult = table.Execute(retrieveOperation);

            return (T) retrievedResult.Result;
        }

        public T[] GetAll<T>(string connectionString, string tableName, string partitionKey) where T : TableEntity, new()
        {
            CloudTable table = GetTable(connectionString, tableName);
            TableQuery<T> query = new TableQuery<T>();
            if (!string.IsNullOrWhiteSpace(partitionKey))
            {
                query.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            }

            table.CreateIfNotExists();

            T[] result = table.ExecuteQuery(query).ToArray();

            return result;
        }

        public void Delete<T>(string connectionString, string tableName, string partitionKey, string rowKey) where T : TableEntity
        {
            CloudTable table = GetTable(connectionString, tableName);
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            table.CreateIfNotExists();

            TableResult retrievedResult = table.Execute(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                TableOperation deleteOperation = TableOperation.Delete((ITableEntity) retrievedResult.Result);
                table.Execute(deleteOperation);
            }
        }
    }
}