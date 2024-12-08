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
            _connection.CreateTableAsync<Models.Photo>().Wait();
            _connection.CreateTableAsync<Models.PhotoRating>().Wait();
        }
        //THEME TASKS
        public async Task<List<Models.Theme>> GetThemesAsync()
        {
            return await _connection.Table<Models.Theme>().ToListAsync();
        }
        public async Task InsertThemeAsync(List<Theme> themes)
        {
            foreach (var theme in themes)
            {
                await _connection.InsertAsync(theme);
            }
        }
        public async Task<Theme> GetThemeByIdAsync(int id)
        {
            return await _connection.Table<Theme>().FirstOrDefaultAsync(t => t.Id == id);
        }

        //ASSIGNMENT TASKS
        public async Task<List<Models.Assignment>> GetAssignmentsAsync()
        {
            var assignments = await _connection.Table<Assignment>().ToListAsync();
            foreach (var assignment in assignments)
            {
                assignment.Theme = await GetThemeByIdAsync(assignment.ThemeId);
            }
            return assignments;
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
