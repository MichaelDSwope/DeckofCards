using DeckofCards.Models;

public interface IDeckOfCardsService{    Task<string> CreateNewDeckAsync();    Task<List<Card>> GetCardsAsync(string deckId);}