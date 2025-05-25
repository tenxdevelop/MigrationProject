namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class CountryModel
    {
        public string Name { get; set; }

        public override bool Equals(object? otherObject)
        {
            if (otherObject.GetType() != typeof(CountryModel))
                return false;
            
            var otherCountry = otherObject as CountryModel;
            
            return Name.Equals(otherCountry.Name);
        }
    }
}