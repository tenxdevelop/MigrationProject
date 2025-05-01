namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class CountryModel
    {
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(CountryModel))
                return false;
            
            var otherCountry = obj as CountryModel;
            
            return Name.Equals(otherCountry.Name);
        }
    }
}