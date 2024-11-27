using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudfototut.Models;
using SQLite;

namespace crudfototut
{
    public class LocalDbTut
    {
        private const string DB_NAME = "crudfototut.db";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbTut()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Models.Assignment>().Wait();
        }
        public async Task<List<Models.Assignment>> GetAssignmentsAsync()
        {
            return await _connection.Table<Models.Assignment>().ToListAsync();
        }
        public async Task<Assignment> GetAssignmentByThemeAsync(string theme)
        {
            return await _connection.Table<Models.Assignment>().Where(a => a.Theme == theme).FirstOrDefaultAsync();
        }
        public async Task Create(Assignment assignment)
        {
            await _connection.InsertAsync(assignment);
        }
        public async Task Update(Assignment assignment)
        {
            await _connection.UpdateAsync(assignment);
        }
        public async Task Delete(Assignment assignment)
        {
            await _connection.DeleteAsync(assignment);
        }
    }
}
