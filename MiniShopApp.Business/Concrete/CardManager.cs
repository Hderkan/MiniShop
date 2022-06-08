using MiniShopApp.Business.Abstract;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShopApp.Business.Concrete
{
    public class CardManager : ICardService
    {
        private ICardRepository _cardRepository;

        public CardManager(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public Card GetCardByUserId(string userId)
        {
            return _cardRepository.GetCardByUserId(userId);
        }

        public void InitializeCard(string userId)
        {
            var card = new Card() { UserId = userId };
            _cardRepository.Create(card);
        }
    }
}
