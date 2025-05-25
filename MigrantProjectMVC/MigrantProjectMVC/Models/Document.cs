namespace MigrantProjectMVC.Models
{
    [Serializable]
    public class Document
    {
        public string Name { get; set; }

        public override bool Equals(object? otherObject)
        {
            if(otherObject.GetType() != GetType())
                return false;
            
            Document other = (Document)otherObject;
            return Equals(other);
        }
        
        public virtual bool Equals(Document other)
        {
            return Name == other.Name;
        }
    }
}