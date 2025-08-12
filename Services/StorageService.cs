using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using dnd3._5App.Models;
using Microsoft.JSInterop;

namespace dnd3._5App.Services;

/// <summary>
/// Simple wrapper around browser localStorage for persisting characters.
/// </summary>
public class StorageService
{
    private readonly IJSRuntime _js;
    private const string StoreName = "characters";

    public StorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<List<Character>> GetCharactersAsync()
    {
        var json = await _js.InvokeAsync<string>("localStorage.getItem", StoreName);
        if (string.IsNullOrWhiteSpace(json)) return new List<Character>();
        return JsonSerializer.Deserialize<List<Character>>(json) ?? new List<Character>();
    }

    public async Task<Character?> GetCharacterAsync(string id)
    {
        var chars = await GetCharactersAsync();
        return chars.FirstOrDefault(c => c.Id == id);
    }

    public async Task SaveCharacterAsync(Character c)
    {
        var chars = await GetCharactersAsync();
        var idx = chars.FindIndex(x => x.Id == c.Id);
        if (idx >= 0) chars[idx] = c; else chars.Add(c);
        var json = JsonSerializer.Serialize(chars);
        await _js.InvokeVoidAsync("localStorage.setItem", StoreName, json);
    }

    public async Task DeleteCharacterAsync(string id)
    {
        var chars = await GetCharactersAsync();
        chars.RemoveAll(c => c.Id == id);
        var json = JsonSerializer.Serialize(chars);
        await _js.InvokeVoidAsync("localStorage.setItem", StoreName, json);
    }
}
