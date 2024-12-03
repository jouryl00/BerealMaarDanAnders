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
            _connection.CreateTableAsync<Models.User>().Wait();
            _connection.CreateTableAsync<Models.Theme>().Wait();
        }

        //ASSIGNMENT TASKS
        public async Task<List<Models.Assignment>> GetAssignmentsAsync()
        {
            return await _connection.Table<Models.Assignment>().ToListAsync();
        }
        //deze nog uitzoeken hoe en wat
        public async Task<Assignment> GetAssignmentByThemeAsync(int themeId)
        {
            return await _connection.Table<Models.Assignment>().Where(a => a.ThemeId == themeId).FirstOrDefaultAsync();
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

        //USER TASKS
        public async Task<List<Models.User>> GetUsersAsync()
        {
            return await _connection.Table<Models.User>().ToListAsync();
        }
        //use for profile page
        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _connection.Table<Models.User>().Where(u => u.Name == name).FirstOrDefaultAsync();
        }
        public async Task Create(User user)
        {
            await _connection.InsertAsync(user);
        }
        public async Task Update(User user)
        {
            await _connection.UpdateAsync(user);
        }
        public async Task Delete(User user)
        {
            await _connection.DeleteAsync(user);


        }
    }
}
