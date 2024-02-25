using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class CardItemRepository:GenericRepository<CardItem>,ICardItemRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public CardItemRepository(BlackSwanManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CardItem> GetCardItem(int id)
        {
            var cardItem = await _dbContext.cardItems.FirstOrDefaultAsync(x => x.id == id);
            return cardItem;
        }

        public async Task<List<CardItem>> GetListCardItems()
        {
            var lstCardItem = await _dbContext.cardItems.ToListAsync();
            return lstCardItem;
        }
    }
}
