namespace KinderGartenApp.Core.Entities
{
	public class Child
	{
        public Guid Id { get; set; }


        public string FullName { get; set; } = "";

        public DateTime BirthDate { get; set; }

        public int ParentId { get; set; }
        
        public Padre Parent { get; set; } = new();
    }
}