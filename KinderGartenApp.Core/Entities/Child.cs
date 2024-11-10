using KinderGartenApp.Core.Primitives;
using KinderGartenApp.Core.Enumarations;

namespace KinderGartenApp.Core.Entities
{
	public class Child : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public GradeLevel GradeLevel { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }

        private Child(Guid id, string? firstName, string? lastName, DateTime birthDate, GradeLevel gradeLevel, int parentId) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            GradeLevel = gradeLevel;
            ParentId = parentId;
        }

        public static Child Create(Guid id, string? firstName, string? lastName, DateTime birthDate, GradeLevel gradeLevel, int parentId)
        {
            return new(id, firstName, lastName, birthDate, gradeLevel, parentId);
        }
    }
}