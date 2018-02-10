using RealEstateAgency.Model;
using System;
using System.Collections.Generic;

namespace RealEstateAgency.UI.Wrapper
{
    public class EstateWrapper : ModelWrapper<Estate>
    {
        public EstateWrapper(Estate model) : base(model)
        {
        }

        public int Id { get { return Model.EstateID; } }

        public string EstateName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public double EstateSpace
        {
            get { return Model.EstateSpace; }
            set
            {
                SetValue(value);
            }
        }

        public string EstateAdress
        {
            get { return GetValue<string>(); }
            set
            {
                SetValue(value);
            }
        }

        public double EstateCostOfSale
        {
            get { return Model.EstateCostOfSale; }
            set
            {
                SetValue(value);
            }
        }

        protected override IEnumerable<string> ValidateProprty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(EstateName):
                    if (string.Equals(EstateName, "Person",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Person can not be Estate";
                    }
                    break;
            }
        }
    }
}
