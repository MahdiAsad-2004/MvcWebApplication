

namespace OrganicShop.Domain.Dtos.Combo
{
    public sealed class ComboDto<Entity> where Entity : IAggregateRoot
    {
        public string Text { get; set; }

        public string Value { get; set; }
    }
}
