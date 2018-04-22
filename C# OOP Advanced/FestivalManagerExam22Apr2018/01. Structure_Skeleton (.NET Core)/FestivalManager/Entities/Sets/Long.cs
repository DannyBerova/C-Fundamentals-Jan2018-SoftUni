namespace FestivalManager.Entities.Sets
{
    using System;

    public  class Long : Set
    {
        public Long(string name)
            : base(name, TimeSpan.FromMinutes(60))
        {
            this.Name = name;
        }
    }
}
