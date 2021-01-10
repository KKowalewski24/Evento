using System;

namespace EventoCore.Domain {

    public abstract class BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        public Guid Id { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/
        protected BaseEntity() {
            Id = Guid.NewGuid();
        }

        protected BaseEntity(Guid id) {
            Id = id;
        }

        protected bool Equals(BaseEntity other) {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((BaseEntity)obj);
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public override string ToString() {
            return $"{nameof(Id)}: {Id}";
        }

    }

}
