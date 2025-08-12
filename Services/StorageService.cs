using dnd3._5App.Models;
using TG.Blazor.IndexedDB;
using System.Linq;

namespace dnd3._5App.Services;

/// <summary>
/// Simple wrapper around IndexedDB. Fallback to in-memory list when unavailable.
/// </summary>
public class StorageService
{
    private readonly IndexedDBManager _db;
    private readonly List<Character> _memory = new();
    private const string StoreName = "characters";

    public StorageService(IndexedDBManager db)
    {
        _db = db;
    }

    public async Task<List<Character>> GetCharactersAsync()
    {
        try
        {
            var recs = await _db.GetRecords<Character>(StoreName);
            return recs.ToList();
        }
        catch
        {
            return _memory;
        }
    }

    public async Task SaveCharacterAsync(Character c)
    {
        try
        {
            var record = new StoreRecord<Character> { Storename = StoreName, Data = c };
            await _db.AddRecord(record);
        }
        catch
        {
            var idx = _memory.FindIndex(x => x.Id == c.Id);
            if (idx >= 0) _memory[idx] = c; else _memory.Add(c);
        }
    }

    public async Task DeleteCharacterAsync(string id)
    {
        try
        {
            await _db.DeleteRecord(StoreName, id);
        }
        catch
        {
            _memory.RemoveAll(c => c.Id == id);
        }
    }
}
