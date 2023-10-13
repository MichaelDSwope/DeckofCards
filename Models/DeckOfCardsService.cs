namespace DeckofCards.Models
{
    public class DeckOfCardsService : IDeckOfCardsService
    {

        public async Task<string> CreateNewDeckAsync()
        {
            string apiUrl = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    GenerateDeckResponse generateDeckResponse = await client.GetFromJsonAsync<GenerateDeckResponse>(apiUrl);
                    if (generateDeckResponse == null)
                    {
                        return null;
                    }
                    return generateDeckResponse.deck_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return null;

        }




        //draw 5 cards
        //https://deckofcardsapi.com/api/deck/<<deck_id>>/draw/?count=2
        public async Task<List<Card>> GetCardsAsync(string deckId)
        {
            string apiUrl = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=5";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    DrawDeckResponse generateDeckResponse = await client.GetFromJsonAsync<DrawDeckResponse>(apiUrl);
                    return generateDeckResponse.cards;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return null;
        }
    }

    //make call api to generate a new deck. capture deck id returned
    //https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1



    

        //return 5 cards


    

}
