using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{

    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

}
