using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using parcial2Examen.Model;
using SQLite;
using parcial2Examen.Extensions;

namespace parcial2Examen.Data
{
    public class DataB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        static bool initialized = false;

        public DataB()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GasModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(GasModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<GasModel>> GetAllTasksAsync()
        {
            return Database.Table<GasModel>().ToListAsync();
        }

        public Task<List<GasModel>> GetTasksNotDoneAsync()
        {
            return Database.QueryAsync<GasModel>($"SELECT * FROM [{typeof(GasModel).Name}] WHERE [Done] = 0");
        }

        public Task<GasModel> GetTaskAsync(int id)
        {
            return Database.Table<GasModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTaskAsync(GasModel item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteTaskAsync(GasModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}